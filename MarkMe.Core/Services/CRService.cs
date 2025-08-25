using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI;
using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services.Interface;
using System.Threading.Tasks;
using Azure;

namespace MarkMe.Core.Services
{
    public class CRService(ICRRepository _repo, IStudentRepository _sRepo) : ICRService
    {
        private static readonly string clerkApiKey = "sk_test_aPUnDwY5R5dPCfQWnu1wJAu3MWBNfos1hGNHuwCvpK"; // Replace with your Clerk secret key
        private static readonly ClerkBackendApi clerkClient = new ClerkBackendApi(bearerAuth: clerkApiKey);
        public async Task<IEnumerable<CRDTO>> GetAllAsync()
        {
            var crs = await _repo.GetAllAsync();
            return crs;
        }

        public async Task<CRDTO> AddAsync(AddUpdateCRDTO obj, string currentUserEmail)
        {
            try
            {
                var stu = await _sRepo.GetStudentAsync(obj.StudentId);
                if (stu is not null ? await CreateClerkUserAsync(stu.Email, stu.FirstName, stu.LastName, new Guid().ToString()) : false)
                {
                    var cr = await _repo.AddAsync(obj, currentUserEmail);
                    return cr;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;

        }

        public async Task UpdateAsync(AddUpdateCRDTO obj, string email)
        {
            await _repo.UpdateAsync(obj, email);
        }

        public async Task<CRDTO?> GetAsync(int studentId)
        {
            var cr = await _repo.GetAsync(studentId);
            return cr;
        }

        public async Task<IEnumerable<CRDTO>> ToggleActive(int studentId, bool isDisabled)
        {
            return await _repo.ToggleActive(studentId, isDisabled);
        }

        public async Task<bool> DeleteAsync(int studentId)
        {
            var isDeleted = await DeleteClerkUserAsync((await _sRepo.GetStudentAsync(studentId)).Email);
            return isDeleted ? await _repo.DeleteAsync(studentId) : false;
        }

        public async Task<bool> CreateClerkUserAsync(string email, string firstName, string lastName, string password)
        {
            string randomTwoDigit = new Random().Next(10, 99).ToString();
            var newUserRequest = new CreateUserRequestBody()
            {
                EmailAddress = new List<string> { email },
                FirstName = firstName,
                LastName = lastName,
                Password = $"paSSword@{randomTwoDigit}{Guid.NewGuid():N}",
                Username = $"{(string.IsNullOrEmpty(firstName) ? "" : firstName.Substring(0, 1).ToLower())}{lastName?.ToLower()}{randomTwoDigit}",
                SkipPasswordChecks = false,
                SkipPasswordRequirement = false,
                PublicMetadata = new Dictionary<string, object>() {
                    { "roles", "cr" },
                }
            };

            try
            {
                var response = await clerkClient.Users.CreateAsync(newUserRequest);
                return true;
            }
            catch (Clerk.BackendAPI.Models.Errors.ClerkErrors ex)
            {
            }
            return false;
        }

        public async Task<bool> DeleteClerkUserAsync(string email)
        {
            bool deleted = false;
            try
            {
                var usrs = await clerkClient.Users.ListAsync();
                usrs.UserList?.ForEach((user) =>
                {
                    if (user.EmailAddresses?.FirstOrDefault(x => x.EmailAddressValue == email) is not null)
                    {
                        clerkClient.Users.DeleteAsync(user.Id).GetAwaiter().GetResult();
                        deleted =  true;
                    }
                });
            }
            catch (Clerk.BackendAPI.Models.Errors.ClerkErrors ex)
            {
                deleted = false;
            }
            return deleted;
        }
    }
}

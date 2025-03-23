using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI;
using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services.Interface;

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

        public async Task<CRDTO> AddAsync(AddUpdateCRDTO obj)
        {
            try
            {
                var stu = await _sRepo.GetStudentAsync(obj.StudentId);
                if (stu is not null ? await CreateClerkUserAsync(stu.Email, stu.FirstName, stu.LastName, new Guid().ToString()) : false)
                {
                    var cr = await _repo.AddAsync(obj);
                    return cr;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;

        }

        public async Task UpdateAsync(AddUpdateCRDTO obj)
        {
            await _repo.UpdateAsync(obj);
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
            int randomTwoDigit = Convert.ToInt32(new Random().Next(99));
            var newUserRequest = new CreateUserRequestBody()
            {
                EmailAddress = new List<string> { email },
                FirstName = firstName,
                LastName = lastName,
                Password = "pASSWORD@#122" + Guid.NewGuid(),
                Username = $"{firstName.ToLower().ToArray().FirstOrDefault()}{lastName.ToLower()}{randomTwoDigit}",
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
                usrs.UserList?.ForEach(async (user) =>
                {
                    if (user.EmailAddresses?.FirstOrDefault(x => x.EmailAddressValue == email) is not null)
                    {
                        await clerkClient.Users.DeleteAsync(user.Id);
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

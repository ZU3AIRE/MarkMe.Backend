using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Core.Services.Interface;
using MarkMe.Database.Entities;
using MarkMe.Database.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;

namespace MarkMe.Core.Services
{
    public class StudentService(IStudentRepository _studRepo,
                IConfiguration _configuration,
                HttpClient _httpClient) : IStudentService
    {
        public async Task<StudentDTO> AddAsync(CreateStudentDTO obj)
        {
            var student = new StudentDTO
            {
                CollegeRollNo = obj.CollegeRollNo,
                UniversityRollNo = obj.UniversityRollNo,
                RegistrationNo = obj.RegistrationNo,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                Session = obj.Session,
                Section = obj.Section,
                Email = obj.Email
            };
            var stcd = await _studRepo.AddStudentAsync(student);
            return stcd;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _studRepo.DeleteStudentAsync(id);
        }

        public async Task<StudentDTO?> GetAsync(int id)
        {
            return await _studRepo.GetStudentAsync(id);
        }

        public async Task<IEnumerable<StudentDTO>> GetAllAsync()
        {
            return await _studRepo.GetAllStudentsAsync();
        }

        public Task<IEnumerable<StudentDTO>> GetCRNomineesAsync()
        {
            return _studRepo.GetCRNomineesAsync();
        }

        public async Task<StudentDTO> UpdateAsync(StudentDTO updatedObj)
        {
            var updated = await _studRepo.UpdateStudentAsync(updatedObj.StudentId, updatedObj);
            return updated;
        }
        public async Task<bool> BulkDeleteAsync(IEnumerable<int> ids)
        {
            return await _studRepo.BulkDeleteStudentsAsync(ids);
        }


        public async Task<IEnumerable<StudentDataModel>> GetStudentsNameAsync()
        {
            var APIurl = _configuration["FaceApi:BaseUrl"];
            try
            {
                var response = await _httpClient.GetAsync($"{APIurl}api/faces/gallery");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var faceGallery = JsonConvert.DeserializeObject<FaceGallery>(content);
                    var studentIds = faceGallery.Students
                        .Select(s => s.StudentId)
                        .Where(id => !string.IsNullOrWhiteSpace(id) && id.All(char.IsDigit))
                        .ToArray();

                    var students = await _studRepo.GetStudentsNameAsync(studentIds);
                    return students;
                }
            }

            catch (Exception ex)
            {
                // Log the exception (ex) as needed
                throw new ApplicationException("Error fetching students from Face API", ex);
            }
            return Enumerable.Empty<StudentDataModel>();
        }
    }
}

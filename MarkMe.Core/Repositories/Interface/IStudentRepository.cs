using MarkMe.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkMe.Core.Repositories.Interface
{
    public interface IStudentRepository
    {
        Task<StudentDTO> GetStudentAsync(int Id);
        Task<IEnumerable<StudentDTO>> GetAllStudentsAsync();
        Task<IEnumerable<StudentDTO>> GetCRNomineesAsync();
        Task<StudentDTO> AddStudentAsync(StudentDTO student);
        Task<StudentDTO> UpdateStudentAsync(int id, StudentDTO student);
        Task<bool> DeleteStudentAsync(int id);
        Task<IEnumerable<StudentDataModel>> GetStudentsNameAsync();
    }
}

using MarkMe.Database.Entities;

namespace MarkMe.Core.Services.Interface
{
    public interface IStudentService
    {
        Task<Student?> Get(int id);
        Task<IEnumerable<Student>> GetAll();
        Task Update(int id, Student updatedObj);
        Task Delete(int id);
        Task<Student> Add(Student obj);
    }
}

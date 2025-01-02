using MarkMe.Core.Interface;
using MarkMe.Database.Entities;
using MarkMe.Database.Interface;

namespace MarkMe.Core
{
    public class StudentService(IDatabase _database) : IStudent
    {
        public async Task<Student> Add(Student obj)
        {
            var sql = "INSERT INTO Students (CollegeRollNo, UniversityRollNo, RegistrationNo, FirstName, LastName, Session, Section, IsDeleted) " +
                "VALUES (@CollegeRollNo, @UniversityRollNo, @RegistrationNo, @FirstName, @LastName, @Session, @Section, @IsDeleted); " +
                "SELECT SCOPE_IDENTITY()";

            obj.StudentId = await _database.QuerySingleAsync<int>(sql, new
            {
                obj.CollegeRollNo,
                obj.UniversityRollNo,
                obj.RegistrationNo,
                obj.FirstName,
                obj.LastName,
                obj.Session,
                obj.Section,
                obj.IsDeleted,
            });
            return obj;
        }

        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Students WHERE StudentId = @Id";
            await _database.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Student?> Get(int id)
        {
            var sql = "SELECT * FROM Students WHERE StudentId = @Id";
            return await _database.QuerySingleAsync<Student>(sql, new { Id = id });
        }

        public Task<IEnumerable<Student>> GetAll()
        {
            var sql = "SELECT * FROM Students";
            return _database.QueryAsync<Student>(sql);
        }

        public Task Update(int id, Student updatedObj)
        {
            var sql = "UPDATE Students " +
                      "SET " +
                        "CollegeRollNo = @CollegeRollNo, UniversityRollNo = @UniversityRollNo, RegistrationNo = @RegistrationNo, " +
                        "FirstName = @FirstName, LastName = @LastName, Session = @Session, Section = @Section, IsDeleted = @IsDeleted " +
                      "WHERE StudentId = @Id";
            return _database.ExecuteAsync(sql, new
            {
                updatedObj.CollegeRollNo,
                updatedObj.UniversityRollNo,
                updatedObj.RegistrationNo,
                updatedObj.FirstName,
                updatedObj.LastName,
                updatedObj.Session,
                updatedObj.Section,
                updatedObj.IsDeleted,
                Id = id
            });
        }
    }
}

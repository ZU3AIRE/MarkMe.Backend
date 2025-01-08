using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Database.Interface;

namespace MarkMe.Core.Repositories
{
    public class StudentRepository(IDatabase _database) : IStudentRepository
    {

        public async Task<StudentDTO> AddStudentAsync(StudentDTO obj)
        {
            var sql = "INSERT INTO Students (CollegeRollNo, UniversityRollNo, RegistrationNo, FirstName, LastName, Session, Section, IsDeleted) " +
                "VALUES (@CollegeRollNo, @UniversityRollNo, @RegistrationNo, @FirstName, @LastName, @Session, @Section, 0); " +
                "SELECT SCOPE_IDENTITY()";

            obj.StudentId = await _database.QuerySingleAsync<int>(sql, parameters: obj);
            return obj;
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            try
            {
                var sql = "UPDATE Students SET IsDeleted = 1 WHERE StudentId = @Id";
                await _database.ExecuteAsync(sql, new { Id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<StudentDTO?> GetStudentAsync(int id)
        {
            var sql = "SELECT * FROM Students WHERE StudentId = @Id AND IsDeleted = 0";
            return await _database.QuerySingleAsync<StudentDTO>(sql, new { Id = id });
        }

        public Task<IEnumerable<StudentDTO>> GetAllStudentsAsync()
        {
            var sql = "SELECT * FROM Students WHERE IsDeleted = 0";
            return _database.QueryAsync<StudentDTO>(sql);
        }

        public Task<IEnumerable<StudentDTO>> GetCRNomineesAsync()
        {
            var sql = """
                    SELECT * 
                    FROM Students 
                    WHERE NOT EXISTS (
                        SELECT 1 
                        FROM ClassRepresentatives 
                        WHERE ClassRepresentatives.StudentId = Students.StudentId
                    )
                    """;
            return _database.QueryAsync<StudentDTO>(sql);
        }

        public Task<StudentDTO?> UpdateStudentAsync(int id, StudentDTO updatedObj)
        {
            var sql = "UPDATE Students " +
                      "SET " +
                        "CollegeRollNo = @CollegeRollNo, UniversityRollNo = @UniversityRollNo, RegistrationNo = @RegistrationNo, " +
                        "FirstName = @FirstName, LastName = @LastName, Session = @Session, Section = @Section " +
                      " WHERE StudentId = @StudentId";
            return _database.QuerySingleAsync<StudentDTO>(sql, updatedObj);
        }
    }
}

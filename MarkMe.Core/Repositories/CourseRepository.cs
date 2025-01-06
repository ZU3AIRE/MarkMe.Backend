using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Database.Interface;

namespace MarkMe.Core.Repositories
{
    public class CourseRepository(IDatabase _database) : ICourseRepository
    {
        public async Task<CourseDTO> AddAsync(CourseDTO obj)
        {
            var sql = """
                INSERT INTO Courses ([Code] ,[Title] ,[Type] ,[Semester] ,[CreditHours] ,[CreditHoursPerWeek] ,[IsArchived] ,[AssignedTo]) 
                VALUES(@Code, @Title, @Type, @Semester, @CreditHours, @CreditHoursPerWeek, 0, 1);
                SELECT SCOPE_IDENTITY()
             """;

            obj.CourseId = await _database.QuerySingleAsync<int>(sql, parameters: obj);
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var sql = "DELETE Courses Where CourseId = @Id";
                await _database.ExecuteAsync(sql, new { Id = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CourseDTO?> GetAsync(int id)
        {
            var sql = "SELECT * FROM Courses WHERE CourseId = @Id";
            return await _database.QuerySingleAsync<CourseDTO>(sql, new { Id = id });
        }

        public async Task<CourseDTO?> UpdateAsync(int id, CourseDTO updatedObj)
        {
            var sql = """
                        UPDATE Courses
                        SET
                            Code = @Code, 
                            Title = @Title, 
                            Type = @Type, 
                            Semester = @Semester, 
                            CreditHours = @CreditHours, 
                            CreditHoursPerWeek = @CreditHoursPerWeek
                        WHERE CourseId = @CourseId;

                        SELECT * FROM Courses WHERE CourseId = @CourseId;
             """;

            return await _database.QuerySingleAsync<CourseDTO>(sql, updatedObj);
        }

        public async Task<IEnumerable<CourseDTO>> GetAllAsync()
        {
            var sql = "SELECT * FROM Courses";
            return await _database.QueryAsync<CourseDTO>(sql);
        }
    }
}

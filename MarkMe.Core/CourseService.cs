using MarkMe.Core.Interface;
using MarkMe.Database.Entities;
using MarkMe.Database.Interface;

namespace MarkMe.Core
{
    public class CourseService(IDatabase _database) : ICourse
    {
        public async Task<Course> Add(Course obj)
        {
            var sql = "INSERT INTO Courses (Code, Title, Type, Semester, AssignedTo, CreditHours, IsArchived) " +
                "VALUES (@Code, @Title, @Type, @Semester, @AssignedTo, @CreditHours, @IsArchived); " +
                "SELECT SCOPE_IDENTITY()";

            obj.CourseId = await _database.QuerySingleAsync<int>(sql, new
            {
                obj.Code,
                obj.Title,
                obj.Type,
                obj.Semester,
                obj.AssignedTo,
                obj.CreditHours,
                obj.IsArchived,
            });
            return obj;
        }

        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Courses WHERE CourseId = @Id";
            await _database.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Course?> Get(int id)
        {
            var sql = "SELECT * FROM Courses WHERE CourseId = @Id";
            return await _database.QuerySingleAsync<Course>(sql, new { Id = id });
        }

        public async Task Update(int id, Course updatedObj)
        {
            var sql = "UPDATE Courses " +
                      "SET " +
                        "Code = @Code, Title = @Title, Type = @Type, " +
                        "Semester = @Semester, AssignedTo = @AssignedTo, " +
                        "CreditHours = @CreditHours, IsArchived = @IsArchived " +
                      "WHERE CourseId = @Id";
            await _database.ExecuteAsync(sql, new
            {
                updatedObj.Code,
                updatedObj.Title,
                updatedObj.Type,
                updatedObj.Semester,
                updatedObj.AssignedTo,
                updatedObj.CreditHours,
                updatedObj.IsArchived,
                Id = id
            });
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var sql = "SELECT * FROM Courses";
            return await _database.QueryAsync<Course>(sql);
        }
    }
}

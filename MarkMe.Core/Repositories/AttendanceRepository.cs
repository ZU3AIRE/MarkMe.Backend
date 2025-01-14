using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Database.Interface;

namespace MarkMe.Core.Repositories
{
    public class AttendanceRepository(IDatabase _database) : IAttendanceRepository
    {
        public async Task<IEnumerable<AttendanceDataModel>> AddAsync(AttendanceDTO obj)
        {
            var sql = """
                INSERT INTO Attendances (StudentId, CourseId, MarkedBy, DateMarked)
                VALUES (@StudentId, @CourseId, 1, GETDATE())
                """;
            var rowsEffected = await _database.ExecuteAsync(sql, parameters: obj.StudentIds.Select(studentId => new { CourseId = obj.CourseId, StudentId = studentId }));

            // Query Added
            var attendanceDTO = await GetByCourseIdAsync(obj.CourseId);
            return attendanceDTO!;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var sql = "DELETE FROM Attendances WHERE AttendanceId = @AttendanceId";
                await _database.ExecuteAsync(sql, new { AttendanceId = id });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> BulkDeleteAsync(BulkDeleteAttendanceDTO attendanceIds)
        {
            try
            {
                var sql = "DELETE FROM Attendances WHERE AttendanceId IN @AttendanceIds";
                await _database.ExecuteAsync(sql, new { AttendanceIds = attendanceIds.AttendanceIds });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AttendanceDataModel>> GetAllAsync()
        {
            var sql = """
                SELECT a.AttendanceId, a.CourseId, a.StudentId, (s.FirstName + ' ' + s.LastName) AS Name, s.UniversityRollNo, s.CollegeRollNo, c.Code, c.Title, c.Semester, a.DateMarked, (u.FirstName + ' ' + u.LastName ) AS MarkedBy
                    FROM Attendances a
                    INNER JOIN Students s 
                    ON s.StudentId = a.StudentId
                    INNER JOIN Users u 
                    ON a.MarkedBy = u.UserId
                	INNER JOIN Courses c
                	ON a.CourseId = c.CourseId                 
                """;
            var attendance = await _database.QueryAsync<AttendanceDataModel>(sql);
            return attendance;
        }

        public async Task<IEnumerable<AttendanceDataModel?>> GetByCourseIdAsync(int courseId)
        {
            var sql = """
                SELECT a.AttendanceId, a.CourseId, a.StudentId, (s.FirstName + ' ' + s.LastName) AS Name, s.UniversityRollNo, s.CollegeRollNo, c.Code, c.Title, c.Semester, a.DateMarked, (u.FirstName + ' ' + u.LastName ) AS MarkedBy
                    FROM Attendances a
                    INNER JOIN Students s 
                    ON s.StudentId = a.StudentId
                    INNER JOIN Users u 
                    ON a.MarkedBy = u.UserId
                	INNER JOIN Courses c
                	ON a.CourseId = c.CourseId  
                WHERE a.CourseId = @CourseId
                """;
            var attendance = await _database.QueryAsync<AttendanceDataModel>(sql, new { CourseId = courseId });
            return attendance;
        }

        public async Task<AttendanceDataModel> UpdateAsync(int attendanceId, UpdateAttendanceDTO obj)
        {
            var sql = """
                UPDATE Attendances SET CourseId = @CourseId, StudentId = @StudentId, MarkedBy = 2, DateMarked = GETDATE()
                WHERE AttendanceId = @AttendanceId
                """;
            var updated = await _database.ExecuteAsync(sql, new { obj.CourseId, obj.StudentId, AttendanceId = attendanceId });
            var attend = await GetByIdAsync(attendanceId);
            return attend!;
        }

        public async Task<AttendanceDataModel?> GetByIdAsync(int attendanceId)
        {
            var sql = """
                SELECT a.AttendanceId, a.CourseId, a.StudentId, (s.FirstName + ' ' + s.LastName) AS Name, s.UniversityRollNo, s.CollegeRollNo, c.Code, c.Title, c.Semester, a.DateMarked, (u.FirstName + ' ' + u.LastName ) AS MarkedBy
                    FROM Attendances a
                    INNER JOIN Students s 
                    ON s.StudentId = a.StudentId
                    INNER JOIN Users u 
                    ON a.MarkedBy = u.UserId
                	INNER JOIN Courses c
                	ON a.CourseId = c.CourseId  
                WHERE a.AttendanceId = @attendanceId 
                """;
            var attendance = await _database.QuerySingleAsync<AttendanceDataModel>(sql, new { attendanceId });
            return attendance;
        }
    }
}

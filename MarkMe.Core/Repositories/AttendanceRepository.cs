﻿using MarkMe.Core.DTOs;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Database.Enums;
using MarkMe.Database.Interface;

namespace MarkMe.Core.Repositories
{
    public class AttendanceRepository(IDatabase _database) : IAttendanceRepository
    {
        public async Task<IEnumerable<AttendanceDataModel>> AddAsync(AttendanceDTO obj, string courseTitle, string userEmail)
        {
            // In place of Class Representative Student Id we will use when the login of the CR will be created and then we will use it's id.
            var description = $"Marked Attendance for {courseTitle}.";
            var sql = """
                INSERT INTO Attendances (StudentId, CourseId, MarkedBy, DateMarked, Status)
                VALUES (@StudentId, @CourseId, (Select UserId from Users where Email =@Email), @DateMarked, @AttendanceStatus)

                IF EXISTS(Select * from Users where Email =@Email AND UserId = 3)
                BEGIN
                    INSERT INTO Activities (Description, Date, ClassRepresentativeStudentId, ClassRepresentativeCourseId)
                    Values (@description, @DateMarked, 2, @CourseId)
                END
                """;
            var parameters = obj.StudentIds.Select(studentId => new
            {
                obj.CourseId,
                StudentId = studentId,
                Email = userEmail,
                obj.DateMarked,
                description,
                obj.AttendanceStatus
            });

            var rowsAffected = await _database.ExecuteAsync(sql, parameters);
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
                SELECT a.AttendanceId, a.CourseId, a.StudentId, (s.FirstName + ' ' + s.LastName) AS Name, s.UniversityRollNo, s.CollegeRollNo, c.Code AS CourseCode, c.Title AS CourseTitle, c.Semester, a.DateMarked, (u.FirstName + ' ' + u.LastName ) AS MarkedBy, a.Status
                    FROM Attendances a
                    INNER JOIN Students s 
                    ON s.StudentId = a.StudentId
                    INNER JOIN Users u 
                    ON a.MarkedBy = u.UserId
                	INNER JOIN Courses c
                	ON a.CourseId = c.CourseId
                    ORDER BY a.DateMarked DESC
                """;
            var attendance = await _database.QueryAsync<AttendanceDataModel>(sql);
            return attendance;
        }



        public async Task<IEnumerable<AttendanceDataModel?>> GetByCourseIdAsync(int courseId)
        {
            var sql = """
                SELECT a.AttendanceId, a.CourseId, a.StudentId, (s.FirstName + ' ' + s.LastName) AS Name, s.UniversityRollNo, s.CollegeRollNo, c.Code AS CourseCode, c.Title AS CourseTitle, c.Semester, a.DateMarked, (u.FirstName + ' ' + u.LastName ) AS MarkedBy, a.Status
                    FROM Attendances a
                    INNER JOIN Students s 
                    ON s.StudentId = a.StudentId
                    INNER JOIN Users u 
                    ON a.MarkedBy = u.UserId
                	INNER JOIN Courses c
                	ON a.CourseId = c.CourseId  
                WHERE a.CourseId = @CourseId
                ORDER BY a.DateMarked DESC
                """;
            var attendance = await _database.QueryAsync<AttendanceDataModel>(sql, new { CourseId = courseId });
            return attendance;
        }

        public async Task<AttendanceDataModel> UpdateAsync(int attendanceId, UpdateAttendanceDTO obj)
        {
            var sql = """
                UPDATE Attendances SET CourseId = @CourseId, MarkedBy = 2, DateMarked = @DateMarked, Status = @Status
                WHERE AttendanceId = @AttendanceId
                """;
            var updated = await _database.ExecuteAsync(sql, new { obj.CourseId, AttendanceId = attendanceId,DateMarked = obj.DateMarked ,Status = obj.AttendanceStatus });
            var attend = await GetByIdAsync(attendanceId);
            return attend!;
        }

        public async Task<AttendanceDataModel?> GetByIdAsync(int attendanceId)
        {
            var sql = """
                SELECT a.AttendanceId, a.CourseId, a.StudentId, (s.FirstName + ' ' + s.LastName) AS Name, s.UniversityRollNo, s.CollegeRollNo, c.Code AS CourseCode, c.Title AS CourseTitle, c.Semester, a.DateMarked, (u.FirstName + ' ' + u.LastName ) AS MarkedBy, a.Status
                    FROM Attendances a
                    INNER JOIN Students s 
                    ON s.StudentId = a.StudentId
                    INNER JOIN Users u 
                    ON a.MarkedBy = u.UserId
                	INNER JOIN Courses c
                	ON a.CourseId = c.CourseId  
                WHERE a.AttendanceId = @attendanceId
                ORDER BY a.DateMarked DESC
                """;
            var attendance = await _database.QuerySingleAsync<AttendanceDataModel>(sql, new { attendanceId });
            return attendance;
        }

        public async Task<IEnumerable<CoursesDTO>> GetCRCourses(string email)
        {
            var sql = """
                SELECT c.CourseId, c.Title AS CourseName, c.Code AS CourseCode FROM ClassRepresentatives cr
                INNER JOIN Courses c ON cr.CourseId = c.CourseId
                WHERE StudentId = (SELECT StudentId FROM Students WHERE Email = @Email AND IsDeleted = 0);
                """;
            var coursesCR = await _database.QueryAsync<CoursesDTO>(sql, new { Email = email });
            return coursesCR;
        }

        public async Task<IEnumerable<CoursesDTO>> GetTutorCoursesAsync(string email)
        {
            var sql = """
                Select CourseId, Code AS CourseCode, Title AS CourseName from Courses Where AssignedTo = (Select UserId from Users where Email =@Email)
                """;
            return await _database.QueryAsync<CoursesDTO>(sql, new { Email = email });
        }

        public async Task<IEnumerable<ValidStudents>> GetValidStudents(List<string> rollNos)
        {
            var sql = """
                SELECT StudentId, CollegeRollNo AS RollNo FROM Students 
                WHERE CollegeRollNo IN @RollNo
                """;
            var validStudents = await _database.QueryAsync<ValidStudents>(sql, new { RollNo = rollNos });
            return validStudents;
        }

        public async Task<IEnumerable<dynamic>> GetAttendancebyPromt(string sql)
        {
            var result = await _database.QueryAsync<dynamic>(sql);

            return result;
        }

        public async Task<IEnumerable<AttendanceDataModel>> GetAttendanceByDateAsync(DateTime date)
        {
            var sql = """
            SELECT a.AttendanceId, a.CourseId, a.StudentId, (s.FirstName + ' ' + s.LastName) AS Name, s.UniversityRollNo, s.CollegeRollNo, c.Code AS CourseCode, c.Title AS CourseTitle, c.Semester, a.DateMarked, (u.FirstName + ' ' + u.LastName ) AS MarkedBy, a.Status
            FROM Attendances a
            INNER JOIN Students s ON s.StudentId = a.StudentId
            INNER JOIN Users u ON a.MarkedBy = u.UserId
            INNER JOIN Courses c ON a.CourseId = c.CourseId
            WHERE CONVERT(date, a.DateMarked) = @Date
            ORDER BY a.DateMarked DESC
            """;
            return await _database.QueryAsync<AttendanceDataModel>(sql, new { Date = date });
        }

        public async Task<IEnumerable<AttendanceDataModel>> GetAttendanceByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var sql = """
            SELECT a.AttendanceId, a.CourseId, a.StudentId, (s.FirstName + ' ' + s.LastName) AS Name, s.UniversityRollNo, s.CollegeRollNo, c.Code AS CourseCode, c.Title AS CourseTitle, c.Semester, a.DateMarked, (u.FirstName + ' ' + u.LastName ) AS MarkedBy, a.Status
            FROM Attendances a
            INNER JOIN Students s ON s.StudentId = a.StudentId
            INNER JOIN Users u ON a.MarkedBy = u.UserId
            INNER JOIN Courses c ON a.CourseId = c.CourseId
            WHERE CONVERT(DATE, a.DateMarked) BETWEEN @StartDate AND @EndDate
            ORDER BY a.DateMarked DESC
            """;
            return await _database.QueryAsync<AttendanceDataModel>(sql, new { StartDate = startDate, EndDate = endDate });
        }
    }
}

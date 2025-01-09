using MarkMe.Core.DTOs;
using MarkMe.Core.HelpingModels;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Database.Interface;

namespace MarkMe.Core.Repositories
{
    public class CRRepository(IDatabase _database) : ICRRepository
    {
        public async Task<CRDTO> AddAsync(AddUpdateCRDTO obj)
        {
            var sql = """
                INSERT INTO ClassRepresentatives (StudentId, CourseId, IsDeleted, NominatedBy) 
                VALUES(@StudentId, @CourseId, 0, 1);
             """;

            var rowsAffected = await _database.ExecuteAsync(sql, parameters: obj.CourseIds.Select(courseId => new { StudentId = obj.StudentId, CourseId = courseId }));

            // Query Added
            var crDTO = await GetAsync(obj.StudentId);
            return crDTO!;
        }

        public async Task UpdateAsync(AddUpdateCRDTO obj)
        {
            var deleted = await _database.ExecuteAsync("DELETE FROM ClassRepresentatives WHERE StudentId = @StudentId", new { obj.StudentId });
            var sql = """
                INSERT INTO ClassRepresentatives (StudentId, CourseId, IsDeleted, NominatedBy) 
                VALUES(@StudentId, @CourseId, 0, 1);
             """;

            var rowsAffected = await _database.ExecuteAsync(sql, parameters: obj.CourseIds.Select(courseId => new { obj.StudentId, CourseId = courseId }));
        }

        public async Task<IEnumerable<CRDTO>> GetAllAsync()
        {
            const string sql = """ 
					SELECT
						Students.StudentId, 
						Students.FirstName, 
						Students.LastName, 
						Courses.CourseId, 
						Courses.Title AS CourseName,
						Activities.Description AS ActivityDescription,
						Activities.Date AS ActivityDate,
						IsDisabled
					FROM ClassRepresentatives
					LEFT JOIN Students ON Students.StudentId = ClassRepresentatives.StudentId
					LEFT JOIN Courses ON Courses.CourseId = ClassRepresentatives.CourseId
					LEFT JOIN Activities ON Activities.ClassRepresentativeStudentId = ClassRepresentatives.StudentId AND Activities.ClassRepresentativeCourseId = ClassRepresentatives.CourseId 
					""";
            var flatList = await _database.QueryAsync<CRFlatListItem>(sql);
            var crDTOs = flatList
                .GroupBy(x => new { x.FirstName, x.LastName, x.StudentId, x.IsDisabled })
                .Select(g =>
                {
                    return new CRDTO
                    {
                        StudentId = g.Key.StudentId,
                        FirstName = g.Key.FirstName,
                        LastName = g.Key.LastName,
                        IsDisabled = g.Key.IsDisabled,
                        PhoneNumber = "+92-326-4696321", // g.Key.PhoneNumber,
                        Avatar = "https://api.dicebear.com/9.x/notionists/svg?seed=" + g.Key.FirstName + g.Key.LastName + "&scale=200&backgroundColor=039be5,b6e3f4,d1d4f9", // g.Key.Avatar,
                        Courses = g.Select(x => new SelectItem(x.CourseId, x.CourseName)).Distinct().ToList(),
                        Activities = g.Select(x => new ActivityDTO { Description = x.ActivityDescription, Date = x.ActivityDate }).Where(x => x.Date is not null && x.Description is not null).ToList()
                    };
                })
                .ToList();
            return crDTOs;
        }
        
        public async Task<IEnumerable<CRDTO>> ToggleActive(int studentId, bool isDisabled)
        {
            const string sql = """ 
					UPDATE ClassRepresentatives
					SET
						IsDisabled = @isDisabled
					WHERE  
					    ClassRepresentatives.StudentId = @studentId
					""";

            var affectedRows = await _database.ExecuteAsync(sql, new { studentId, isDisabled });
            var all = await GetAllAsync();
            return all;
        }

        public async Task<CRDTO?> GetAsync(int studentId)
        {
            var sql = """ 
					SELECT
						Students.StudentId,
						Students.FirstName, 
						Students.LastName, 
						Courses.CourseId,
						Courses.Title AS CourseName
					FROM ClassRepresentatives
					LEFT JOIN Students ON Students.StudentId = ClassRepresentatives.StudentId
					LEFT JOIN Courses ON Courses.CourseId = ClassRepresentatives.CourseId
					WHERE ClassRepresentatives.StudentId = @StudentId
					""";
            var flatList = await _database.QueryAsync<CREmptyFlatListItem>(sql, new { StudentId = studentId });
            var crDTO = flatList
                .GroupBy(x => new { x.FirstName, x.LastName, x.StudentId, x.IsDisabled })
                .Select(g => new CRDTO
                {
                    StudentId = g.Key.StudentId,
                    FirstName = g.Key.FirstName,
                    LastName = g.Key.LastName,
                    IsDisabled = g.Key.IsDisabled,
                    PhoneNumber = "+92-326-4696321", // g.Key.PhoneNumber,
                    Avatar = "https://api.dicebear.com/9.x/notionists/svg?seed=" + g.Key.FirstName + g.Key.LastName + "&scale=200&backgroundColor=039be5,b6e3f4,d1d4f9", // g.Key.Avatar,
                    Courses = g.Select(x => new SelectItem(x.CourseId, x.CourseName)).Distinct().ToList(),
                    Activities = Enumerable.Empty<ActivityDTO>().ToList()
                })
                .ToList().FirstOrDefault();
            return crDTO;
        }
    }
}

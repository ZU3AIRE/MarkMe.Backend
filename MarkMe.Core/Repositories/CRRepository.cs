using MarkMe.Core.DTOs;
using MarkMe.Core.HelpingModels;
using MarkMe.Core.Repositories.Interface;
using MarkMe.Database.Interface;

namespace MarkMe.Core.Repositories
{
    public class CRRepository(IDatabase _database) : ICRRepository
    {
        public async Task<IEnumerable<CRDTO>> GetAllAsync()
        {
			const string sql = """ 
					SELECT
						Students.FirstName, 
						Students.LastName, 
						Courses.Title AS CourseName,
						Activities.Description AS ActivityDescription,
						Activities.Date AS ActivityDate
					FROM ClassRepresentatives
					LEFT JOIN Students ON Students.StudentId = ClassRepresentatives.StudentId
					LEFT JOIN Courses ON Courses.CourseId = ClassRepresentatives.CourseId
					LEFT JOIN Activities ON Activities.ClassRepresentativeStudentId = ClassRepresentatives.StudentId AND Activities.ClassRepresentativeCourseId = ClassRepresentatives.CourseId 
					""";
            var crList = await _database.QueryAsync<GetAllCRResult>(sql);
            var crDtos = crList
                .GroupBy(x => new { x.FirstName, x.LastName })
                .Select(g => new CRDTO
                {
                    FirstName = g.Key.FirstName,
                    LastName = g.Key.LastName,
                    PhoneNumber = "+92-326-4696321", // g.Key.PhoneNumber,
                    Avatar = "https://api.dicebear.com/9.x/notionists/svg?seed=" + g.Key.FirstName + g.Key.LastName + "&scale=200&backgroundColor=039be5,b6e3f4,d1d4f9", // g.Key.Avatar,
                    Courses = g.Select(x => x.CourseName).Distinct().ToList(),
                    Activities = g.Select(x => new ActivityDTO { Description = x.ActivityDescription, Date = x.ActivityDate }).ToList()
                })
                .ToList();
            return crDtos;
        }
    }
}

﻿using MarkMe.Core.DTOs;
using MarkMe.Database.Entities;

namespace MarkMe.Core.Services.Interface
{
    public interface IStudentService
    {
        Task<StudentDTO?> GetAsync(int id);
        Task<IEnumerable<StudentDTO>> GetAllAsync();
        Task<IEnumerable<StudentDTO>> GetCRNomineesAsync();
        Task<StudentDTO> UpdateAsync(StudentDTO updatedObj);
        Task<bool> DeleteAsync(int id);
        Task<StudentDTO> AddAsync(CreateStudentDTO obj);
        Task<bool> BulkDeleteAsync(IEnumerable<int> ids);
    }
}

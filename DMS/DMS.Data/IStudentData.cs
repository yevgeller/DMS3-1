using DMS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data
{
    public interface IStudentData
    {
        //void AssignStudentToRoom(int studentId, int roomId);
        Task<List<Students_List>> GetPaginatedStudentListAsync(int currentPage, int pageSize);
        Task<List<Students_List>> GetPaginatedStudentListAsync(int currentPage, int pageSize, string sortBy);
    }
}

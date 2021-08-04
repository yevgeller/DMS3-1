using DMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace DMS.Data
{
    public class StudentService : IStudentData
    {
        private readonly DMSDataContext ef;
        public StudentService(DMSDataContext _ef)
        {
            ef = _ef;
        }
        public async Task<List<Students_List>> GetPaginatedStudentListAsync(int currentPage, int pageSize)
        {
            return await ef.Students_List
                .OrderBy(x => x.Student_Id)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<List<Students_List>> GetPaginatedStudentListAsync(int currentPage, int pageSize, string sortBy)
        {
            return await ef.Students_List
                .AsQueryable()
                .OrderBy(sortBy)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}

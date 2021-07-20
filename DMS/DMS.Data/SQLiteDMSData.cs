using Dapper;
using DMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS.Data
{
    public class SQLiteDMSData :  SqLiteBaseRepository, IDMSData
    {
        public void AssignStudentToRoom(int studentId, int roomId)
        {
            using (var cnn = SimpleDbConnection())
            {
                cnn.Open();
                Student student = cnn.Query<Student>(
                    @"SELECT * FROM Student WHERE Student_Id = @Student_Id", 
                    new { Student_Id = studentId }).First();
                var j = 1;
            }
        }
    }
}

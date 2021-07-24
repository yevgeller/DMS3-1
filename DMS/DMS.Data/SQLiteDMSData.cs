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

/*
 * 
 * 
 WITH StudentsPerRoom AS 
	(SELECT Room_Id, COUNT(*) AS SpR FROM Student_Rooms GROUP BY Room_Id),
	TeachersPerRoom AS 
	(SELECT PR.Room_Id, COUNT(*) AS TpR FROM Person_Room PR
	JOIN Person P ON PR.Person_Id = P.Person_Id
	JOIN Person_Type PT ON P.Person_Type_Id = PT.Person_Type_Id
	WHERE PT.Name LIKE '%teacher%'
	GROUP BY PR.Room_ID)
SELECT 
	R.Room_Id, 
	CASE WHEN StuPRo.SpR IS NULL THEN 0 ELSE StuPRo.SpR END AS SpR, 
	CASE WHEN TeaPRo.TpR IS NULL THEN 0 ELSE TeaPRo.TpR END AS TpR
FROM Room R
LEFT OUTER JOIN StudentsPerRoom StuPRo ON R.Room_Id = StuPRo.Room_Id
LEFT OUTER JOIN TeachersPerRoom TeaPRo ON R.Room_Id = TeaPRo.Room_Id
*/
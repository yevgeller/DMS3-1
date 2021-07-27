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
WITH StudentsPerRoom AS 
		(SELECT Room_Id, COUNT(*) AS SpR FROM Student_Rooms GROUP BY Room_Id),
	TeachersPerRoom AS 
		(SELECT PR.Room_Id, COUNT(*) AS TpR FROM Person_Room PR
		JOIN Person P ON PR.Person_Id = P.Person_Id
		JOIN Person_Type PT ON P.Person_Type_Id = PT.Person_Type_Id
		WHERE PT.Name LIKE '%teacher%'
		GROUP BY PR.Room_ID),
	AverageStudentAge AS 
		(SELECT SR.Room_Id, 
		CAST(AVG(CAST(julianday() - 2451544.5 - BornDaysAfterJan12000 AS INTEGER)) AS INTEGER) AS DaysOld
		FROM Student S
		JOIN Student_Rooms SR ON S.Student_Id = SR.Student_Id
		GROUP By SR.Room_Id)
SELECT 
	R.Room_Id, 
	CASE WHEN StuPRo.SpR IS NULL THEN 0 ELSE StuPRo.SpR END AS SpR, 
	CASE WHEN TeaPRo.TpR IS NULL THEN 0 ELSE TeaPRo.TpR END AS TpR,
	CASE WHEN ASA.DaysOld IS NULL THEN 0 ELSE ASA.DaysOld END AS DaysOld
FROM Room R
LEFT OUTER JOIN StudentsPerRoom StuPRo ON R.Room_Id = StuPRo.Room_Id
LEFT OUTER JOIN TeachersPerRoom TeaPRo ON R.Room_Id = TeaPRo.Room_Id
LEFT OUTER JOIN AverageStudentAge ASA ON R.Room_Id = ASA.Room_Id 


for students not in Room age range:
SELECT S.Name, S.Birthdate,
CASE 
	WHEN CAST(julianday() - 2451544.5 - S.BornDaysAfterJan12000 AS INTEGER) > AB.MinDays 
	AND 
	CAST(julianday() - 2451544.5 - S.BornDaysAfterJan12000 AS INTEGER) < AB.MaxDays
	THEN 1 ELSE 0 END AS WithinRange,
CAST(julianday() - 2451544.5 - S.BornDaysAfterJan12000 AS INTEGER) AS DaysOld, AB.MinDays, AB.MaxDays, 
R.Name, AB.Name, 
CAST(julianday() - 2451544.5 - S.BornDaysAfterJan12000 AS INTEGER) - AB.MaxDays AS DaysOver,
AB.MinDays - CAST(julianday() - 2451544.5 - S.BornDaysAfterJan12000 AS INTEGER) AS DaysUnder,

R.Room_Id, S.Student_Id, AB.Age_Bracket_Id
FROM Student S
JOIN Student_Rooms SR ON S.Student_Id = SR.Student_Id
JOIN Room R ON SR.Room_Id = R.Room_Id 
JOIN Age_Bracket AB ON R.Age_Bracket_Id = AB.Age_Bracket_Id
WHERE S.Is_Active = 1 AND R.Is_Active = 1 AND WithinRange = 0
Order By R.Room_Id, DaysOld

--Min Age Per Room 
SELECT S.Student_Id, S.Name, S.Birthdate, S.BornDaysAfterJan12000,
R.Room_Id, R.Name, MinAgePerRoomCalc.MinDaysOld AS DaysOld 
FROM Student S JOIN Student_Rooms SR ON S.Student_Id = SR.Student_Id 
JOIN Room R ON SR.Room_Id = R.Room_Id 
JOIN (
	SELECT R.Room_Id, 
	MIN(CAST(julianday() - 2451544.5 - BornDaysAfterJan12000 AS INTEGER)) AS MinDaysOld
	FROM Student S
	JOIN Student_Rooms SR ON S.Student_Id = SR.Student_Id
	JOIN Room R ON SR.Room_Id = R.Room_Id 
	WHERE S.Is_Active = 1
	GROUP BY R.Room_ID) AS MinAgePerRoomCalc
ON R.Room_id = MinAgePerRoomCalc.Room_Id AND 
(CAST(julianday() - 2451544.5 - S.BornDaysAfterJan12000 AS INTEGER)) = MinAgePerRoomCalc.MinDaysOld
*/
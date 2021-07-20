using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Data
{
    public interface IDMSData
    {
        void AssignStudentToRoom(int studentId, int roomId);
    }
}

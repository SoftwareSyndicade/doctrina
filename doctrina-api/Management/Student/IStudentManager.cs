using System;
namespace doctrine_api.Management.Student
{
    public interface IStudentManager
    {
        public void Register(DataModels.Student student);

        public DataModels.Student Fetch(string studentID);
    }
}


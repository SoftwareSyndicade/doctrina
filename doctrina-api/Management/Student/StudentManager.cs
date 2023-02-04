using System;
using doctrine_api.Services.SQLServer;

namespace doctrine_api.Management.Student
{
    public class StudentManager : IStudentManager
    {
        private readonly DoctrinaStore _store;

        public StudentManager(DoctrinaStore store)
        {
            _store = store;
        }

        public void Register(DataModels.Student student)
        {
            _store.STUDENT.Add(student);
            _store.SaveChanges();
        }

        public DataModels.Student Fetch(string studentID)
        {
            return (from student in _store.STUDENT where student.ID.Equals(studentID) select student).FirstOrDefault();
        }
    }
}


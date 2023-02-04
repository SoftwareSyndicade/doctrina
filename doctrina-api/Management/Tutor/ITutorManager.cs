using System;
namespace doctrine_api.Management.Tutor
{
    public interface ITutorManager
    {
        public void Register(DataModels.Tutor tutor);

        public DataModels.Tutor Fetch(String tutorID);
    }
}


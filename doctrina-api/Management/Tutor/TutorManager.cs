using System;
using doctrine_api.Services.SQLServer;

namespace doctrine_api.Management.Tutor
{
    public class TutorManager : ITutorManager
    {
        private readonly DoctrinaStore _store;

        public TutorManager(DoctrinaStore store)
        {
            _store = store;
        }

        public DataModels.Tutor Fetch(string tutorID)
        {
            return (from tutor in _store.TUTOR where tutor.ID.Equals(tutorID) select tutor).FirstOrDefault();
        }

        public void Register(DataModels.Tutor tutor)
        {
            _store.TUTOR.Add(tutor);
            _store.SaveChanges();
        }
    }
}


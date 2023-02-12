using System;
using doctrine_api.DataModels;
using doctrine_api.Management.Assistance.Request.Models;
using doctrine_api.Services.SQLServer;
using doctrine_api.Constants;

namespace doctrine_api.Management.Assistance.Request
{
    public class AssistanceRequestManager : IAssistanceRequestManager
    {
        private readonly DoctrinaStore _store;

        public AssistanceRequestManager(DoctrinaStore store)
        {
            _store = store;
        }

        public AssistanceRequestSaveStatus Register(AssistanceReuest assistanceReuest)
        {
            AssistanceRequestSaveStatus status = new();

            _store.ASSISTANCE_REQUEST.Add(assistanceReuest);
            status.IS_SAVED = _store.SaveChanges() == 1;

            return status;

        }

        public List<DataModels.AssistanceReuest> Fetch(string profileID, AccountTypes accountType)
        {
            bool isTutor = accountType == AccountTypes.TUTOR;

            var assistanceRequest = (from ar in _store.ASSISTANCE_REQUEST
                                     select ar).ToList();

            if (accountType == AccountTypes.STUDENT)
                assistanceRequest = assistanceRequest.Where(x => x.CREATED_BY.Equals(profileID)).ToList();

            return assistanceRequest;
        }
    }
}


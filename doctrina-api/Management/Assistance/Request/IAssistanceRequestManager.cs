using System;
using doctrine_api.Management.Assistance.Request.Models;
using doctrine_api.Constants;

namespace doctrine_api.Management.Assistance.Request
{
    public interface IAssistanceRequestManager
    {
        public AssistanceRequestSaveStatus Register(DataModels.AssistanceReuest assistanceReuest);
        public List<DataModels.AssistanceReuest> Fetch(string profileID, AccountTypes type);
    }
}


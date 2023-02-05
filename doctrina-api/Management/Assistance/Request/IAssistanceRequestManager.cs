using System;
using doctrine_api.Management.Assistance.Request.Models;

namespace doctrine_api.Management.Assistance.Request
{
    public interface IAssistanceRequestManager
    {
        public AssistanceRequestSaveStatus Register(DataModels.AssistanceReuest assistanceReuest);
    }
}


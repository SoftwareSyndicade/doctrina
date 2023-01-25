using System;
namespace doctrine_api.Utilities
{
    public class UserSecret
    {
        public byte[] SALT { get; set; }
        public string SECRET_HASH { get; set; }
    }
}


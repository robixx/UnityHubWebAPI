﻿namespace UnityHubWebAPI.Common
{
    public class TokenResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}

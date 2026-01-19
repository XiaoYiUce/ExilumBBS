using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ExilumBBS.Models.DTO.Auth
{
    public class LoginPostDTO
    {
        [JsonPropertyName("account_name")]
        public string AccountName { get; set; } = "";

        [JsonPropertyName("passwd")]
        public string Passwd { get; set; } = "";

        [JsonPropertyName("source")]
        public string Source { get; set; } = "";
    }
}

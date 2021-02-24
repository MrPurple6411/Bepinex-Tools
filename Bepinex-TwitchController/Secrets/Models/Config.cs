﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TwitchController
{
    class Config
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("bot_access_token")]
        public string BotAccessToken { get; set; }

        [JsonPropertyName("bot_refresh_token")]
        public string BotRefreshToken { get; set; }

        [JsonPropertyName("username_token")]
        public string UsernameToken { get; set; }

        [JsonPropertyName("username_id")]
        public string UsernameId { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("bot_name")]
        public string BotName { get; set; }

        [JsonPropertyName("events")]
        public List<ConfigEventInfo> EventInfoList { get; set; }
    }

    public class ConfigEventInfo
    {
        [JsonPropertyName("event")]
        public string EventName { get; set; }

        [JsonPropertyName("bit_cost")]
        public int BitCost { get; set; }

        [JsonPropertyName("cooldown")]
        public int Cooldown { get; set; }
    }
}
﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using UnityEngine;

namespace TwitchController
{
    public class Secrets
    {

        private static string _configFilePath = null;
        private static string ConfigFilePath { get => _configFilePath ?? (_configFilePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TwitchConfig.txt")); }


        public string client_id;
        public string access_token;
        public string api_token;
        public string nick_id;
        public string username;
        public string botname;
        public List<ConfigEventInfo> eventConfigList = new List<ConfigEventInfo>();

        public Secrets(string customConfigPath = null)
        {
            _configFilePath = customConfigPath;

            if (!File.Exists(ConfigFilePath))
            {
                File.WriteAllText(ConfigFilePath, JsonSerializer.Serialize(new Config(), new JsonSerializerOptions() { AllowTrailingCommas = true, WriteIndented = true }));
                Application.Quit();
            }

            Config config = JsonSerializer.Deserialize<Config>(File.ReadAllText(ConfigFilePath));
            client_id = config.ClientId;
            access_token = config.BotAccessToken;
            api_token = config.UsernameToken;
            nick_id = config.UsernameId;
            username = config.Username;
            botname = config.BotName;
            if (config.EventInfoList != null)
            {
                eventConfigList = config.EventInfoList;
            }
        }
    }
}
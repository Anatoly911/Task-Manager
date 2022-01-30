using System;
using System.Configuration;
using System.IO;
using System.Text.Json;

namespace Task_Manager
{
    internal class SaveData
    {
        public static void Save() // Сохранение данных в текстовый документ
        {
            Configuration roaming = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoaming);
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = roaming.FilePath };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("UserName", Console.ReadLine());
            config.Save();
            var userName = config.AppSettings.Settings["UserName"].Value;
            config.AppSettings.Settings["UserName"].Value = $"{userName}";
            config.Save();
            string User = userName;
            string json = JsonSerializer.Serialize(User);
            File.WriteAllText("config.json", json);
        }
    }
}

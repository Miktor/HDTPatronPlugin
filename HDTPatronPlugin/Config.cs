#region

using System.IO;
using Hearthstone_Deck_Tracker;

#endregion

namespace HDTPatronPlugin
{
    public class Config
    {
        #region Constants

        private static Config _instance;

        #endregion

        #region Properties

        public static Config Instance => _instance ?? Load();
        private static string FilePath => Path.Combine(Hearthstone_Deck_Tracker.Config.Instance.ConfigDir, "TwitchPlugin.xml");

        #endregion

        #region Methods

        public static T GetConfigItem<T>(string name)
        {
            var prop = Instance.GetType().GetProperty(name).GetValue(Instance, null);
            if(prop == null)
            {
                return default(T);
            }
            return (T)prop;
        }

        public static void Save()
        {
            XmlManager<Config>.Save(FilePath, Instance);
        }

        private static Config Load()
        {
            return _instance = File.Exists(FilePath) ? XmlManager<Config>.Load(FilePath) : new Config();
        }

        #endregion
    }
}
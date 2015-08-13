#region

using System;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Plugins;

#endregion

namespace HDTPatronPlugin
{
    public class PatronPlugin : IPlugin
    {
        #region Fields

        private PatronCalculator _patronCalculator;
        private PluginManager _pluginManager;

        #endregion

        #region Properties

        public string Author => "Gladky Dmitry";
        public string ButtonText => "Settings";
        public string Description => "Helps count lethal damage with patron combo";
        public MenuItem MenuItem { get; private set; }
        public string Name => "PatronPlugin";
        public Version Version => typeof(PatronPlugin).Assembly.GetName().Version;
        public static string PatronTag => "PatronCalculatorPlugin";

        #endregion

        #region IPlugin Members

        public void OnLoad()
        {
            Setup();
            if(MenuItem == null)
            {
                GenerateMenuItem();
            }
        }

        public void OnUnload()
        {
            _pluginManager.OnUnload();
        }

        public void OnButtonPress()
        {
            _pluginManager.OpenSettings();
        }

        public void OnUpdate()
        {
        }

        #endregion

        #region Methods

        private void Setup()
        {
            _pluginManager = new PluginManager();
            _patronCalculator = new PatronCalculator();
        }

        private void GenerateMenuItem()
        {
            MenuItem = new MenuItem {Header = "Patron"};
            var settingsMenuItem = new MenuItem {Header = "Settings"};

            settingsMenuItem.Click += (sender, args) => _pluginManager.OpenSettings();

            MenuItem.Items.Add(settingsMenuItem);
        }

       

        #endregion
    }
}
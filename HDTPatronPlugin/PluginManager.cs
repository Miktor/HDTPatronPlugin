#region

using System.Linq;
using System.Windows;
using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Hearthstone;

#endregion

namespace HDTPatronPlugin
{
    public class PluginManager
    {
        #region Fields

        private SettingsWindow _settingsWindow;

        #endregion

        #region Constructors

        public PluginManager()
        {
            if(!DeckList.Instance.AllTags.Contains(PatronPlugin.PatronTag))
            {
                DeckList.Instance.AllTags.Add(PatronPlugin.PatronTag);
                DeckList.Save();
                Helper.MainWindow.ReloadTags();
            }
            DeckManagerEvents.OnDeckSelected.Add(DeckSelected);
        }

        #endregion

        #region Methods

        public void DeckSelected(Deck deck)
        {
            if(CheckDeckIsPatron(deck))
            {
                if(ShowIsDeckIsPatron())
                {
                    deck.Tags.Add(PatronPlugin.PatronTag);
                }
            }
        }

        private bool CheckDeckIsPatron(Deck deck)
        {
            return !deck.Tags.Contains(PatronPlugin.PatronTag) && deck.Class.Equals("Warrior") && deck.Cards.Any(c => !c.IsClassCard && c.Id == "BRM_019");
        }

        private bool ShowIsDeckIsPatron()
        {
            return
                MessageBox.Show("Seems like this deck is Patron deck, would you like enable Patron plugin for this deck?", "Patron Plugin Enable?", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes;
        }

        public void OpenSettings()
        {
            if(_settingsWindow == null)
            {
                _settingsWindow = new SettingsWindow();
                _settingsWindow.Closed += (sender1, args1) => { _settingsWindow = null; };
                _settingsWindow.Show();
            }
            else
            {
                _settingsWindow.Activate();
            }
        }

        public void OnUnload()
        {
            _settingsWindow?.Close();
        }

        #endregion
    }
}
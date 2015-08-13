#region

using Hearthstone_Deck_Tracker.API;

#endregion

namespace HDTPatronPlugin
{
    internal class PatronCalculator
    {
        #region Constructors

        public PatronCalculator()
        {
            GameEvents.OnGameStart.Add(Start);
            GameEvents.OnGameEnd.Add(End);
        }

        #endregion

        #region Methods

        public void Start()
        {
        }

        public void End()
        {
        }

        #endregion
    }
}
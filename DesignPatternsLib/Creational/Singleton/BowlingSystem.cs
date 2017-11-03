using System;

namespace DesignPatternsLib
{
    public class BowlingSystem
    {
        private static BowlingSystem _instance;
        public static BowlingSystem Instance
        {
            get {
                if (_instance == null)
                    _instance = new BengansBowlingSystem();
                return _instance;
            }
        }
        protected BowlingSystem()
        {
        }
        public virtual void ArrangeTournament()
        {
        }
    }
}

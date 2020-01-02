using System;

namespace RollForContent.Common
{
    public class GlobalRandom
    {
        private readonly Random instance;

        public Random Instance { get { return this.instance; } }

        public GlobalRandom()
        {
            this.instance = new Random();
        }
    }
}

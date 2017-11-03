using DesignPatternsLib;
using System;
using Xunit;

namespace DesignPatternsTestsLib
{
    public class SingletonTests
    {
        [Fact]
        public void Can_Create_BowlingSystem()
        {
            var bowlingSystem1 = BowlingSystem.Instance;
            var bowlingSystem2 = BowlingSystem.Instance;
            BowlingSystem toTestFor = (BowlingSystem)bowlingSystem1;
            bowlingSystem1.ArrangeTournament();
            Assert.Equal(bowlingSystem1, toTestFor);
        }
    }
}

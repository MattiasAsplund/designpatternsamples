using DesignPatternsLib.Structural.Adapter;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DesignPatternsTestsLib
{
    public class AdapterTests
    {
        private ITestOutputHelper _helper;
        public AdapterTests(ITestOutputHelper helper)
        {
            _helper = helper;
        }
        [Fact]
        public void Can_Say_Hello_In_English()
        {
            IEnglish english = new EnglishSpeaker();
            _helper.WriteLine(english.hello());
            var adapter = new SwedishAdapter(new SwedishSpeaker());
            _helper.WriteLine(adapter.hello());
        }
    }
}

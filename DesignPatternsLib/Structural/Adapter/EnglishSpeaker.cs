using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Structural.Adapter
{
    public class EnglishSpeaker : IEnglish
    {
        public string hello()
        {
            return "hello";
        }
    }
}

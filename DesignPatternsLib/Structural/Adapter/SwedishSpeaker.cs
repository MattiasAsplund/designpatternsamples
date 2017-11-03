using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Structural.Adapter
{
    public class SwedishSpeaker : ISwedish
    {
        public string hej()
        {
            return "hej";
        }
    }
}

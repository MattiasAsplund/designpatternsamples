using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsLib.Structural.Adapter
{
    public class SwedishAdapter : IEnglish
    {
        private ISwedish _swedish;
        public SwedishAdapter(ISwedish swedish)
        {
            _swedish = swedish;
        }
        public string hello()
        {
            return _swedish.hej();
        }
    }
}

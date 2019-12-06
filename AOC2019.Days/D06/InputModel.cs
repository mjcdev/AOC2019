using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2019.Days.D06
{
    public struct InputModel
    {
        public InputModel(string centre, string orbit)
        {
            Centre = centre;
            Orbit = orbit;
        }

        public string Centre { get; }

        public string Orbit { get; }
    }
}

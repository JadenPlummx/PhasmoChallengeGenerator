using System;
using System.Collections.Generic;
using System.Text;

namespace PhasmoChallengeGenerator
{
    internal class Rule
    {
        // Instance variables.
        int time;
        string action;
        string consequence;

        int SECONDS_PER_MINUTE = 60;
        int DEFAULT_TIME = 900;

        // Constructor.
        public Rule()
        {
            time = DEFAULT_TIME;
            action = "action";
            consequence = "consequence";
        }
    }
}

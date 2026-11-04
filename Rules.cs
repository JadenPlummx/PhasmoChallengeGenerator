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

        // Properties.

        /// <summary>
        /// This returns the remaining time in a readable format.
        /// </summary>
        internal string Time
        {
            get
            {
                int minutes = (int)(time / SECONDS_PER_MINUTE);
                int seconds = (int)(time % SECONDS_PER_MINUTE);

                // Makes sure the seconds always display two digits.
                return $"{minutes}:{seconds:D2}";
            }
        }

        /// <summary>
        /// This is the action of a Rule, which is the thingamabob that can cause the consequence.
        /// </summary>
        internal string Action
        {
            get
            {
                return action;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Action", "Action cannot be blank.");
                }
                else
                {
                    action = value;
                }
            }
        }
    }
}

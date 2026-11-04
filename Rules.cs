// ============================================================================
// Project Name: PhasmoChallengeGenerator
// Description: Defines the Rule class used to create the phasmophobia challenges.
// Author: Jaden Plummer
// Date: November 1, 2026
// ============================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PhasmoChallengeGenerator
{
    internal class Rules
    {
        // Instance variables.
        int time;
        string action;
        string consequence;

        int SECONDS_PER_MINUTE = 60;
        int DEFAULT_TIME = 900;

        // Constructor.
        public Rules()
        {
            time = DEFAULT_TIME;
            action = "action";
            consequence = "consequence";
        }

        // Parameteriz constructor.
        public Rules(int timeInSeconds, string action, string consequence)
        {
            time = timeInSeconds;
            Action = action;
            Consequence = consequence;
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
        
        /// <summary>
        /// Consequence property.
        /// </summary>
        internal string Consequence
        {
            get
            {
                return consequence;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Consequence", "Consequence cannot be blank.");
                }
                else
                {
                    consequence = value;
                }
            }
        }
    }
}

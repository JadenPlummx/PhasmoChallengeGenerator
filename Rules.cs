// ============================================================================
// Project Name: PhasmoChallengeGenerator
// Description: Defines the Rule class used to create the phasmophobia challenges.
// Author: Jaden Plummer
// Date: November 21, 2026
// ============================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PhasmoChallengeGenerator
{
    internal abstract class Rules
    {
        // Instance variables.
        protected int time;
        protected string action;
        protected string consequence;
        protected static int ruleCount = 0;

        // Constants.
        protected const int SECONDS_PER_MINUTE = 60;
        public const int DefaultTime = 900;

        // Properties.

        /// <summary>
        /// This returns the remaining time in a readable format.
        /// </summary>
        public string Time
        {
            get
            {
                int minutes = time / SECONDS_PER_MINUTE;
                int seconds = time % SECONDS_PER_MINUTE;

                // Makes sure the seconds always display two digits.
                return $"{minutes}:{seconds:D2}";
            }
        }

        /// <summary>
        /// This returns the remaining time in seconds.
        /// </summary>
        public int SecondsRemaining
        {
            get
            {
                return time;
            }
        }

        /// <summary>
        /// This gets or sets the action for the rule.
        /// </summary>
        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidRuleException("Action cannot be blank.");
                }

                action = value;
            }
        }

        /// <summary>
        /// This gets or sets the consequence for the rule.
        /// </summary>
        public string Consequence
        {
            get
            {
                return consequence;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InvalidRuleException("Consequence cannot be blank.");
                }

                consequence = value;
            }
        }

        /// <summary>
        /// This checks whether the rule is currently disabled.
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// This returns the total number of rules created.
        /// </summary>
        public static int Count
        {
            get
            {
                return ruleCount;
            }
        }

        // Constructor.
        public Rules(int timeInSeconds, string action, string consequence)
        {
            if (timeInSeconds <= 0)
            {
                throw new InvalidRuleException("Time must be greater than zero.");
            }

            // Set the values using the properties.
            Action = action;
            Consequence = consequence;
            time = timeInSeconds;

            IsDisabled = false;

            // Keeps track of how many rule objects have been created.
            ruleCount++;
        }

        /// <summary>
        /// This returns the full text of the rule on screen.
        /// </summary>
        public override string ToString()
        {
            return $"{Action}, {Consequence}";
        }

        // Changes the time once per second.
        public void TimerTick()
        {
            if (time > 0 && !IsDisabled)
            {
                time--;
            }
        }

        // Checks whether the challenge timer has expired.
        public bool IsExpired()
        {
            return time == 0;
        }
    }
}

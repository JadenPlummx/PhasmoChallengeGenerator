// ============================================================================
// Project Name: PhasmoChallengeGenerator
// Description: This handles severity based challenges for investigators who are nosy and want
//              to know how difficult their challenges will be.
// Author: Jaden Plummer
// Date: November 24, 2026
// ============================================================================

namespace PhasmoChallengeGenerator
{
    internal class SeverityRules : Rules
    {
        // Instance variables.
        private int actionDifficulty;
        private int consequenceImpact;

        // Properties.

        /// <summary>
        /// This gets or sets how difficult the action is before the ghost gets involved.
        /// </summary>
        public int ActionDifficulty
        {
            get
            {
                return actionDifficulty;
            }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new InvalidRuleException("Keep it between 1 and 10 or the ghosts will devour you");
                }

                actionDifficulty = value;
            }
        }

        /// <summary>
        /// This gets or sets how impactful the consequence will be.
        /// </summary>
        public int ConsequenceImpact
        {
            get
            {
                return consequenceImpact;
            }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new InvalidRuleException("Keep it between 1 and 10 or the ghosts will devour you");
                }

                consequenceImpact = value;
            }
        }

        /// <summary>
        /// This calculates the overall severity of the rule.
        /// </summary>
        public int SeverityLevel
        {
            get
            {
                return (ActionDifficulty + ConsequenceImpact + 1) / 2;
            }
        }

        /// <summary>
        /// This returns the Hunter Rank based on the severity level.
        /// </summary>
        public string HunterRank
        {
            get
            {
                if (SeverityLevel <= 2)
                {
                    return "Rookie Hunter";
                }
                else if (SeverityLevel <= 4)
                {
                    return "Amateur Hunter";
                }
                else if (SeverityLevel <= 6)
                {
                    return "Professional Hunter";
                }
                else if (SeverityLevel <= 8)
                {
                    return "Expert Hunter";
                }
                else
                {
                    return "Master Hunter";
                }
            }
        }

        /// <summary>
        /// This returns the image that matches the Hunters Rank.
        /// </summary>
        public string RankImage
        {
            get
            {
                if (SeverityLevel <= 2)
                {
                    return "pack://application:,,,/Images/Rank1.jpg";
                }
                else if (SeverityLevel <= 4)
                {
                    return "pack://application:,,,/Images/Level2.jpg";
                }
                else if (SeverityLevel <= 6)
                {
                    return "pack://application:,,,/Images/Level3.jpg";
                }
                else if (SeverityLevel <= 8)
                {
                    return "pack://application:,,,/Images/Level4.jpg";
                }
                else
                {
                    return "pack://application:,,,/Images/Level5.jpg";
                }
            }
        }

        // Constructor.
        public SeverityRules(int timeInSeconds, string action, string consequence,
            int actionDifficulty, int consequenceImpact)
            : base(timeInSeconds, action, consequence)
        {
            ActionDifficulty = actionDifficulty;
            ConsequenceImpact = consequenceImpact;
        }
    }
}

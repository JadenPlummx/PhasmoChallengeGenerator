// ============================================================================
// Project Name: PhasmoChallengeGenerator
// Description: This is regular ghost hunting challenges for investigators
// Author: Jaden Plummer
// Date: November 23, 2026
// ============================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PhasmoChallengeGenerator
{
    internal class StandardRules : Rules
    {
        // Spooky Constructor.
        public StandardRules(int timeInSeconds, string action, string consequence)
            : base(timeInSeconds, action, consequence)
        {
        }
    }
}

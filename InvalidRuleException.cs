// ============================================================================
// Project Name: PhasmoChallengeGenerator
// Description: Defines a custom exception for invalid rules.
// Author: Jaden Plummer
// Date: November 23, 2026
// ============================================================================

using System;
using System.Collections.Generic;
using System.Text;

namespace PhasmoChallengeGenerator
{
    internal class InvalidRuleException : Exception
    {
        private string message;

        /// <summary>
        /// Initializes a new custom exception for invalid rule information.
        /// </summary>
        
        /// <summary>
        /// This will hopefully creates a new custom exception for invalid rule information.
        /// </summary>
        public InvalidRuleException(string messageValue) : base(messageValue)
        {
            message = "Invalid Rule: " + messageValue;
        }

        /// <summary>
        /// Gets the formatted error message for the invalid rule.
        /// </summary>
        public override string Message => message;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Substrate.NetApi.Exceptions
{
    /// <summary>
    /// Unable to reconnect to the blockchain
    /// </summary>
    public class UnableToReconnectException : Exception
    {
        /// <summary>
        /// Nb retry before throw this exception
        /// </summary>
        public int NbRetryAttempts { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="nbRetryAttempts">Nb retry before give up :D</param>
        public UnableToReconnectException(string message, int nbRetryAttempts) : base(message) {
            NbRetryAttempts = nbRetryAttempts;
        }
    }
}

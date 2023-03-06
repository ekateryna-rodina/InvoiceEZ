using System;
namespace InvoiceEZ.Common.Logging
{
	public interface ILogger
	{
        /// <summary>
        /// Logs the information
        /// </summary>
        /// <param name="message"></param>
        void LogInformation(string message);
        /// <summary>
        /// Logs the warning
        /// </summary>
        /// <param name="message"></param>
        void LogWarning(string message);
        /// <summary>
        /// Logs the error
        /// </summary>
        /// <param name="message"></param>
        void LogError(string message);
    }
}


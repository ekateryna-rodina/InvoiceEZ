﻿using System;
namespace InvoiceEZ.Common.Logging
{
	public class ConsoleLogger : ILogger
	{
        public void LogInformation(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"WARNING: {message}");
        }

        public void LogError(string message)
        {
            Console.Error.WriteLine($"ERROR: {message}");
        }
    }
}


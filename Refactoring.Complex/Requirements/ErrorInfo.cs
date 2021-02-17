using System;

namespace Refactoring.Complex.Requirements
{
    public class ErrorInfo
    {
        public string Key { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorInfo(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            ErrorMessage = errorMessage;
        }

        public ErrorInfo(string key, string errorMessage)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (string.IsNullOrEmpty(errorMessage))
                throw new ArgumentNullException(nameof(errorMessage));

            Key = key;
            ErrorMessage = errorMessage;
        }
    }
}

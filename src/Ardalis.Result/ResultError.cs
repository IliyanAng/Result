namespace Ardalis.Result
{
    public class ResultError
    {
        public ResultError()
        {
        }

        public ResultError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public ResultError(string identifier, string errorMessage, string errorCode, ValidationSeverity severity)
        {
            Identifier = identifier;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
            Severity = severity;
        }

        public string Identifier { get; set; }

        public string ErrorCode { get; set; }
        public ValidationSeverity Severity { get; set; } = ValidationSeverity.Warning;
        public string ErrorMessage { get; set; }
    }
}

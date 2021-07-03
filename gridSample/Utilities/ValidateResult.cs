namespace Utilities
{
    public class ValidateResult
    {
        public ResultType Status { get; private set; }

        public string Message { get; private set; }

        private ValidateResult()
        {
        }

        public static ValidateResult CreateSuccess()
        {
            return new ValidateResult() { Status = ResultType.Success };
        }

        public static ValidateResult CreateError(string message)
        {
            return new ValidateResult() { Status = ResultType.Error, Message = message };
        }

        public static ValidateResult CreateCancel()
        {
            return new ValidateResult() { Status = ResultType.Cancel };
        }
    }
}

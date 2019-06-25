namespace hacker2019_bester.Handler
{
    public class ValidationException : BaseException
    {
        public ValidationException(string message) : base("000002", message)
        {
        }
    }
}

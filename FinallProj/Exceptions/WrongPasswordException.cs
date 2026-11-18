namespace FinallProj.Exceptions
{
    internal class WrongPasswordException : Exception
    {
        public WrongPasswordException(string message) : base(message)
        {
        }
    }
}

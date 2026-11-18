namespace FinallProj.Exceptions
{
    internal class DuplicateUsernameException : Exception
    {
        public DuplicateUsernameException(string message) : base(message)
        {
        }
    }
}

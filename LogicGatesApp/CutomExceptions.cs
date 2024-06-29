namespace LogicGatesApp
{
    public class IncorrectFileFormatException : Exception
    {
        public IncorrectFileFormatException()
        {
        }

        public IncorrectFileFormatException(string message)
            : base(message)
        {
        }

        public IncorrectFileFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

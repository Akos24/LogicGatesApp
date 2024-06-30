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

    public class IncorrectGateInputException : Exception
    {
        public IncorrectGateInputException()
        {
        }

        public IncorrectGateInputException(string message)
            : base(message)
        {
        }

        public IncorrectGateInputException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class IncorrectRegisterLengthException: Exception
    {
        public IncorrectRegisterLengthException()
        {
        }

        public IncorrectRegisterLengthException(string message)
            : base(message)
        {
        }

        public IncorrectRegisterLengthException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

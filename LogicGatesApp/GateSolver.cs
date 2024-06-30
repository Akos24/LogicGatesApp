using Microsoft.Win32;

namespace LogicGatesApp
{
    public static class GateSolver
    {
        public static string SolveNOTGate(string registerOne)
        {
            if (registerOne.Length != 5)
                throw new IncorrectRegisterLengthException("All registers length must be 5 characters.");

            char[] newRegisterValues = new char[registerOne.Length];

            for (int i = 0; i < registerOne.Length; i++)
            {
                if (registerOne[i] == 'E')
                {
                    newRegisterValues[i] = 'E';
                    continue;
                }
                newRegisterValues[i] = registerOne[i] == '1' ? '0' : '1';
            }

            return new string(newRegisterValues);
        }

        public static string SolveTwoParameterGate(string logicalGate, string registerOne, string registerTwo)
        {
            if (registerOne.Length != 5 || registerTwo.Length != 5)
                throw new IncorrectRegisterLengthException("All registers length must be 5 characters.");

            char[] newRegisterValues = new char[registerOne.Length];

            for (int i = 0; i < registerOne.Length; i++)
            {
                char regOneChar = registerOne[i];
                char regTwoChar = registerTwo[i];

                switch (logicalGate)
                {
                    case "AND":
                        newRegisterValues[i] = AndGate(regOneChar, regTwoChar);
                        break;
                    case "OR":
                        newRegisterValues[i] = OrGate(regOneChar, regTwoChar);
                        break;
                    case "NAND":
                        newRegisterValues[i] = NandGate(regOneChar, regTwoChar);
                        break;
                    case "NOR":
                        newRegisterValues[i] = NorGate(regOneChar, regTwoChar);
                        break;
                    case "XOR":
                        newRegisterValues[i] = XorGate(regOneChar, regTwoChar);
                        break;
                    case "XNOR":
                        newRegisterValues[i] = XnorGate(regOneChar, regTwoChar);
                        break;
                    default:
                        newRegisterValues[i] = 'E';
                        break;
                }
            }

            return new string(newRegisterValues);
        }

        private static char AndGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == '1' && b == '1') ? '1' : '0';
        }

        private static char OrGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == '1' || b == '1') ? '1' : '0';
        }

        private static char NandGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == '1' && b == '1') ? '0' : '1';
        }

        private static char NorGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == '0' && b == '0') ? '1' : '0';
        }

        private static char XorGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == b) ? '0' : '1';
        }

        private static char XnorGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == b) ? '1' : '0';
        }
    }
}

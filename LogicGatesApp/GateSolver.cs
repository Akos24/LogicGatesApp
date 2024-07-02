namespace LogicGatesApp
{
    public static class GateSolver
    {
        /// <summary>
        /// Solves the NOT gate for the given register.
        /// The NOT gate inverts each bit of the register.
        /// </summary>
        /// <param name="registerOne">The input register to invert.</param>
        /// <returns>A new register with each bit inverted.</returns>
        /// <exception cref="IncorrectRegisterLengthException">Thrown when the input register length is not 5 characters.</exception>
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

        /// <summary>
        /// Solves a two-parameter logic gate for the given registers.
        /// The specific gate type determines how the registers are combined.
        /// </summary>
        /// <param name="logicalGate">The type of logic gate to apply (e.g., AND, OR, NAND, etc.).</param>
        /// <param name="registerOne">The first input register.</param>
        /// <param name="registerTwo">The second input register.</param>
        /// <returns>A new register with the result of the logic gate operation.</returns>
        /// <exception cref="IncorrectRegisterLengthException">Thrown when either input register length is not 5 characters.</exception>
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

        /// <summary>
        /// Computes the result of an AND gate operation for two characters.
        /// </summary>
        /// <param name="a">The first input character ('0', '1', or 'E').</param>
        /// <param name="b">The second input character ('0', '1', or 'E').</param>
        /// <returns>The result of the AND operation, or 'E' if either input is 'E'.</returns>
        private static char AndGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == '1' && b == '1') ? '1' : '0';
        }

        /// <summary>
        /// Computes the result of an OR gate operation for two characters.
        /// </summary>
        /// <param name="a">The first input character ('0', '1', or 'E').</param>
        /// <param name="b">The second input character ('0', '1', or 'E').</param>
        /// <returns>The result of the OR operation, or 'E' if either input is 'E'.</returns>
        private static char OrGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == '1' || b == '1') ? '1' : '0';
        }

        /// <summary>
        /// Computes the result of a NAND gate operation for two characters.
        /// </summary>
        /// <param name="a">The first input character ('0', '1', or 'E').</param>
        /// <param name="b">The second input character ('0', '1', or 'E').</param>
        /// <returns>The result of the NAND operation, or 'E' if either input is 'E'.</returns>
        private static char NandGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == '1' && b == '1') ? '0' : '1';
        }

        /// <summary>
        /// Computes the result of a NOR gate operation for two characters.
        /// </summary>
        /// <param name="a">The first input character ('0', '1', or 'E').</param>
        /// <param name="b">The second input character ('0', '1', or 'E').</param>
        /// <returns>The result of the NOR operation, or 'E' if either input is 'E'.</returns>
        private static char NorGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == '0' && b == '0') ? '1' : '0';
        }

        /// <summary>
        /// Computes the result of an XOR gate operation for two characters.
        /// </summary>
        /// <param name="a">The first input character ('0', '1', or 'E').</param>
        /// <param name="b">The second input character ('0', '1', or 'E').</param>
        /// <returns>The result of the XOR operation, or 'E' if either input is 'E'.</returns>
        private static char XorGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == b) ? '0' : '1';
        }

        /// <summary>
        /// Computes the result of an XNOR gate operation for two characters.
        /// </summary>
        /// <param name="a">The first input character ('0', '1', or 'E').</param>
        /// <param name="b">The second input character ('0', '1', or 'E').</param>
        /// <returns>The result of the XNOR operation, or 'E' if either input is 'E'.</returns>
        private static char XnorGate(char a, char b)
        {
            if (a == 'E' || b == 'E') return 'E';
            return (a == b) ? '1' : '0';
        }
    }
}
using LogicGatesApp;

public static class LogicGatesManager
{
    /// <summary>
    /// Array of valid logic gates.
    /// </summary>
    public static string[] ValidLogicGates = { "AND", "OR", "NOT", "NAND", "NOR", "XOR", "XNOR" };

    /// <summary>
    /// Checks if a string is a valid register.
    /// A valid register has a length of 5 and contains only '0', '1', or 'E'.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns>True if the string is a valid register, otherwise false.</returns>
    public static bool IsRegister(string str)
    {
        return str.Length == 5 && str.All(c => c == '0' || c == '1' || c == 'E');
    }

    /// <summary>
    /// Checks if a string is a valid logic gate.
    /// A valid logic gate is one of the strings in the ValidLogicGates array.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns>True if the string is a valid logic gate, otherwise false.</returns>
    public static bool IsLogicGate(string str)
    {
        return ValidLogicGates.Contains(str);
    }

    /// <summary>
    /// Checks if a logic gate is a two-parameter gate.
    /// A two-parameter gate is any logic gate except "NOT".
    /// </summary>
    /// <param name="str">The logic gate to check.</param>
    /// <returns>True if the logic gate is a two-parameter gate, otherwise false.</returns>
    public static bool IsTwoParameterGate(string str)
    {
        return IsLogicGate(str) && str != "NOT";
    }

    /// <summary>
    /// Solves a series of logic gates expressions.
    /// The input is an array of logic gates and registers.
    /// The method returns the final result of the logical expression.
    /// </summary>
    /// <param name="logicGates">An array of logic gates and registers.</param>
    /// <returns>The final result of the logical expression.</returns>
    /// <exception cref="IncorrectGateInputException">Thrown when the logical gate expression is not solvable.</exception>
    public static string SolveLogicGates(string[] logicGates)
    {
        List<string> unsolvedExpressions = new List<string>();
        int i = 0;

        // Iterates through the logic gates and registers.
        while (i < logicGates.Length)
        {
            // If the current gate is "NOT" and the next item is a register, solve it.
            if (i < logicGates.Length - 1 && logicGates[i] == "NOT" && IsRegister(logicGates[i + 1]))
            {
                unsolvedExpressions.Add(SolveLogicalExpression(logicGates[i], logicGates[i + 1]));
                i += 2;
            }
            // If the current gate is a two-parameter gate and the next two items are registers, solve it.
            else if (i < logicGates.Length - 2 && IsTwoParameterGate(logicGates[i]) && IsRegister(logicGates[i + 1]) && IsRegister(logicGates[i + 2]))
            {
                unsolvedExpressions.Add(SolveLogicalExpression(logicGates[i], logicGates[i + 1], logicGates[i + 2]));
                i += 3;
            }
            // Otherwise, add the current item to the unsolved expressions.
            else
            {
                unsolvedExpressions.Add(logicGates[i]);
                i++;
            }
        }

        // If no progress is made in solving expressions, throw an exception.
        if (unsolvedExpressions.Count == logicGates.Length)
            throw new IncorrectGateInputException("Logical gate expression is not solvable.");

        // If there are still multiple unsolved expressions, recursively solve them.
        if (unsolvedExpressions.Count > 1)
        {
            return SolveLogicGates(unsolvedExpressions.ToArray());
        }

        // Return the final solved expression.
        return unsolvedExpressions[0];
    }

    /// <summary>
    /// Solves a single logical expression for a one-parameter gate.
    /// The method returns the result of the NOT gate applied to the given register.
    /// </summary>
    /// <param name="logicalGate">The logical gate to apply.</param>
    /// <param name="registerOne">The register to apply the gate to.</param>
    /// <returns>The result of the logical operation.</returns>
    public static string SolveLogicalExpression(string logicalGate, string registerOne)
    {
        switch (logicalGate)
        {
            case "NOT":
                return GateSolver.SolveNOTGate(registerOne);
            default:
                return "EEEEE";
        }
    }

    /// <summary>
    /// Solves a single logical expression for a two-parameter gate.
    /// The method returns the result of the specified gate applied to the two given registers.
    /// </summary>
    /// <param name="logicalGate">The logical gate to apply.</param>
    /// <param name="registerOne">The first register to apply the gate to.</param>
    /// <param name="registerTwo">The second register to apply the gate to.</param>
    /// <returns>The result of the logical operation.</returns>
    public static string SolveLogicalExpression(string logicalGate, string registerOne, string registerTwo)
    {
        if (IsTwoParameterGate(logicalGate))
        {
            return GateSolver.SolveTwoParameterGate(logicalGate, registerOne, registerTwo);
        }

        return "EEEEE";
    }
}
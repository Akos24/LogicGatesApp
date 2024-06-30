using LogicGatesApp;

public static class LogicGatesManager
{
    public static string[] ValidLogicGates = { "AND", "OR", "NOT", "NAND", "NOR", "XOR", "XNOR" };

    public static bool IsRegister(string str)
    {
        return str.Length == 5 && str.All(c => c == '0' || c == '1' || c == 'E');
    }

    public static bool IsLogicGate(string str)
    {
        return ValidLogicGates.Contains(str);
    }

    public static bool IsTwoParameterGate(string str)
    {
        return IsLogicGate(str) && str != "NOT";
    }

    public static string SolveLogicGates(string[] logicGates)
    {
        List<string> unsolvedExpressions = new List<string>();
        int i = 0;

        while (i < logicGates.Length)
        {
            if (i < logicGates.Length - 1 && logicGates[i] == "NOT" && IsRegister(logicGates[i + 1]))
            {
                unsolvedExpressions.Add(SolveLogicalExpression(logicGates[i], logicGates[i + 1]));
                i += 2;
            }
            else if (i < logicGates.Length - 2 && IsTwoParameterGate(logicGates[i]) && IsRegister(logicGates[i + 1]) && IsRegister(logicGates[i + 2]))
            {
                unsolvedExpressions.Add(SolveLogicalExpression(logicGates[i], logicGates[i + 1], logicGates[i + 2]));
                i += 3;
            }
            else
            {
                unsolvedExpressions.Add(logicGates[i]);
                i++;
            }
        }

        if (unsolvedExpressions.Count == logicGates.Length)
            throw new IncorrectGateInputException("Logical gate expression is not solvable.");

        if (unsolvedExpressions.Count > 1)
        {
            return SolveLogicGates(unsolvedExpressions.ToArray());
        }

        return unsolvedExpressions[0];
    }

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

    public static string SolveLogicalExpression(string logicalGate, string registerOne, string registerTwo)
    {
        if (IsTwoParameterGate(logicalGate))
        {
            return GateSolver.SolveTwoParameterGate(logicalGate, registerOne, registerTwo);
        }

        return "EEEEE";
    }
}
namespace LogicGatesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] logicGates = RegisterManager.LoadRegisters("./input.txt");
            PrintArray(logicGates);

            Console.WriteLine(LogicGatesManager.SolveLogicGates(logicGates));
        }

        static void PrintArray<T>(T[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        static void PrintDict<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }
        }
    }
}

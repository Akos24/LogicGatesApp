namespace LogicGatesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] logicalGates = RegisterManager.LoadRegisters("./input.txt");
            LogicGatesManager logicGatesManager = new LogicGatesManager(logicalGates);


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

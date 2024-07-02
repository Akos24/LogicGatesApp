namespace LogicGatesApp
{
    /// <summary>
    /// Entry point and utility methods for the LogicGatesApp application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            // Load logic gates from "./input.txt"
            string[] logicGates = RegisterManager.LoadRegisters("./input.txt");

            // Print loaded logic gates
            PrintArray(logicGates);

            // Solve and print the result of logic gate operations
            Console.WriteLine(LogicGatesManager.SolveLogicGates(logicGates));
        }

        /// <summary>
        /// Prints elements of an array to the console.
        /// </summary>
        /// <typeparam name="T">Type of elements in the array.</typeparam>
        /// <param name="array">Array to print.</param>
        static void PrintArray<T>(T[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        /// <summary>
        /// Prints key-value pairs of a dictionary to the console.
        /// </summary>
        /// <typeparam name="TKey">Type of dictionary keys.</typeparam>
        /// <typeparam name="TValue">Type of dictionary values.</typeparam>
        /// <param name="dict">Dictionary to print.</param>
        static void PrintDict<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value}");
            }
        }
    }
}

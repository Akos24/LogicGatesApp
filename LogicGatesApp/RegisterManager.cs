namespace LogicGatesApp
{
    public static class RegisterManager
    {
        /// <summary>
        /// Loads logical gates from the specified file, determines used registers,
        /// creates a dictionary of register values, and replaces logical gates with register values.
        /// </summary>
        /// <param name="fileName">The file name from which to read the data.</param>
        /// <returns>An updated array of logical gates containing digital values of registers.</returns>
        public static string[] LoadRegisters(string fileName)
        {
            // Load logical gates
            string[] logicalGates = ReadGates(fileName);

            // Determine used registers
            char[] usedRegisters = DetermineUsedRegisters(logicalGates);

            // Create register dictionary based on values found in the file
            Dictionary<char, string> registerValues = CreateRegisterDictionary(fileName, usedRegisters);

            // Replace logical gates with register values
            string[] newLogicalGates = ReplaceArrayWithDictionaryValues(logicalGates, registerValues);

            return newLogicalGates;
        }

        /// <summary>
        /// Reads the first line from the specified file containing logical gates.
        /// </summary>
        /// <param name="fileName">The file name from which to read the data.</param>
        /// <returns>Array of logical gates.</returns>
        public static string[] ReadGates(string fileName)
        {
            // Read the first line and split by spaces
            string[] gates = File.ReadAllLines(fileName)[0].Split(' ');
            return gates;
        }

        /// <summary>
        /// Determines and returns an array of used registers found in the logical gates.
        /// </summary>
        /// <param name="logicalGates">Array of logical gates.</param>
        /// <returns>Array of used registers.</returns>
        public static char[] DetermineUsedRegisters(string[] logicalGates)
        {
            List<char> usedRegisters = new List<char>();
            foreach (string s in logicalGates)
            {
                if (s.Length == 1 && char.IsLetter(s[0]))
                {
                    usedRegisters.Add(s[0]);
                }
            }

            return usedRegisters.ToArray();
        }

        /// <summary>
        /// Creates a dictionary containing registers and their digital signals based on the specified file.
        /// </summary>
        /// <param name="fileName">The file name from which to read the data.</param>
        /// <param name="usedRegisters">Array of used registers.</param>
        /// <returns>Dictionary of registers with their digital signals.</returns>
        public static Dictionary<char, string> CreateRegisterDictionary(string fileName, char[] usedRegisters)
        {
            Dictionary<char, string> registerDictionary = new Dictionary<char, string>();
            HashSet<char> usedRegistersSet = new HashSet<char>(usedRegisters);

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                bool isFirstLine = true;

                while ((line = sr.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        isFirstLine = false;
                        continue; // Skip the first line
                    }

                    string strippedLine = line.Trim();
                    string[] splitLine = strippedLine.Split(' ');

                    // Check if the line format is correct
                    if (splitLine.Length != 2)
                    {
                        throw new IncorrectFileFormatException("File format is invalid.");
                    }

                    char registerChar = splitLine[0][0];

                    // Check if registerChar is a valid register and is in the used registers set
                    if (char.IsLetter(registerChar) && usedRegistersSet.Contains(registerChar))
                    {
                        string value = ConvertToDigitalSignal(splitLine[1]);
                        registerDictionary[registerChar] = value;
                    }
                }
            }

            return registerDictionary;
        }

        /// <summary>
        /// Converts input signals to digital signals according to specified conversion rules.
        /// </summary>
        /// <param name="signal">Input signal string.</param>
        /// <returns>Digital signal string.</returns>
        public static string ConvertToDigitalSignal(string signal)
        {
            // Check if the input signal length is correct
            if (signal.Length != 10) throw new IncorrectFileFormatException("File format is invalid.");

            List<string> splitSignals = new List<string>();

            // Split the signal into two-character segments
            for (int i = 0; i < signal.Length; i += 2)
            {
                splitSignals.Add($"{signal[i]}.{signal[i + 1]}");
            }

            List<char> digitalValues = new List<char>();

            foreach (string splitSignal in splitSignals)
            {
                double value;
                try
                {
                    // Try to parse the segment into a double
                    value = double.Parse(splitSignal, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    digitalValues.Add('E'); // Add 'E' in case of format exception
                    continue;
                }

                // Convert the value to digital value based on specified rules
                if (value >= 0.0 && value <= 0.8)
                {
                    digitalValues.Add('0');
                }
                else if (value >= 2.7 && value <= 5.0)
                {
                    digitalValues.Add('1');
                }
                else
                {
                    digitalValues.Add('E');
                }
            }

            return new string(digitalValues.ToArray());
        }

        /// <summary>
        /// Replaces elements in the input array with their corresponding values from the dictionary if they exist.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <param name="dictionary">Dictionary containing digital values of registers.</param>
        /// <returns>Updated array containing digital values of registers.</returns>
        public static string[] ReplaceArrayWithDictionaryValues(string[] array, Dictionary<char, string> dictionary)
        {
            string[] result = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length == 1 && dictionary.ContainsKey(array[i][0]))
                {
                    result[i] = dictionary[array[i][0]];
                }
                else
                {
                    result[i] = array[i];
                }
            }

            return result;
        }
    }
}
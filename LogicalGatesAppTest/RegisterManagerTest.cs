using LogicGatesApp;
using NUnit.Framework;

namespace LogicGatesAppTest
{
    public class RegisterManagerTest
    {
        [Test]
        public void LoadRegisters_Test()
        {
            string[] result = RegisterManager.LoadRegisters("./test_file_1.txt");

            Assert.That(result, Is.EqualTo(new string[] { "NOT", "AND", "00E11", "OR", "0101E", "NOT", "00000" }));
        }

        [Test]
        public void ReadGates_Test()
        {
            string[] result = RegisterManager.ReadGates("./test_file_1.txt");

            Assert.That(result, Is.EqualTo(new string[] { "NOT", "AND", "C", "OR", "A", "NOT", "B" }));
        }

        [Test]
        public void DetermineUsedRegisters_Test()
        {
            string[] logicGates = { "NOT", "AND", "C", "OR", "A", "NOT", "B" };
            char[] result = RegisterManager.DetermineUsedRegisters(logicGates);

            Assert.That(result, Is.EqualTo(new char[] { 'C', 'A', 'B' }));
        }

        [Test]
        public void CreateRegisterDictionary_Test()
        {
            string fileName = "./test_file_1.txt";
            char[] usedRegisters = { 'C', 'A', 'B' };

            Dictionary<char, string> result = RegisterManager.CreateRegisterDictionary(fileName, usedRegisters);

            Assert.That(result, Is.EqualTo(new Dictionary<char, string>
            {
                { 'C', "00E11" },
                { 'B', "00000" },
                { 'A', "0101E" }
            }));
        }

        [Test]
        public void ConvertToDigitalSignal_Test()
        {
            string signal = "0205094150";

            string result = RegisterManager.ConvertToDigitalSignal(signal);

            Assert.That(result, Is.EqualTo("00E11"));
        }

        [Test]
        public void ReplaceArrayWithDictionaryValues_Test()
        {
            string[] array = { "NOT", "AND", "C", "OR", "A", "NOT", "B" };
            Dictionary<char, string> dictionary = new Dictionary<char, string>
            {
                { 'C', "00E11" },
                { 'B', "00000" },
                { 'A', "0101E" }
            };

            string[] result = RegisterManager.ReplaceArrayWithDictionaryValues(array, dictionary);

            Assert.That(result, Is.EqualTo(new string[] { "NOT", "AND", "00E11", "OR", "0101E", "NOT", "00000" }));
        }
    }
}
using LogicGatesApp;
using NUnit.Framework;

namespace LogicGatesAppTest
{
    [TestFixture]
    public class RegisterManagerTest
    {
        [Test]
        public void TestReadGates_ValidFile_ReturnsGates()
        {
            // Arrange
            string testFilePath = "test_file.txt";
            File.WriteAllText(testFilePath, "AND 10101 11011\n");

            // Act
            string[] result = RegisterManager.ReadGates(testFilePath);

            // Assert
            Assert.That(result, Is.EqualTo(new string[] { "AND", "10101", "11011" }));

            // Clean up
            File.Delete(testFilePath);
        }

        [Test]
        public void TestDetermineUsedRegisters_ValidGates_ReturnsUsedRegisters()
        {
            // Arrange
            string[] logicGates = { "A", "B", "AND", "C", "D" };

            // Act
            char[] result = RegisterManager.DetermineUsedRegisters(logicGates);

            // Assert
            Assert.That(result, Is.EqualTo(new char[] { 'A', 'B', 'C', 'D' }));
        }

        [Test]
        public void TestCreateRegisterDictionary_ValidFile_ReturnsRegisterDictionary()
        {
            // Arrange
            string testFilePath = "test_file.txt";
            File.WriteAllText(testFilePath, "NOR A B\nA 0028033517\nB 0001020304\n");

            char[] usedRegisters = { 'A', 'B' };

            // Act
            Dictionary<char, string> result = RegisterManager.CreateRegisterDictionary(testFilePath, usedRegisters);

            // Assert
            var expectedDictionary = new Dictionary<char, string>
            {
                { 'A', "0101E" },
                { 'B', "00000" }
            };

            Assert.That(result, Is.EquivalentTo(expectedDictionary));

            // Clean up
            File.Delete(testFilePath);
        }

        [Test]
        public void TestConvertToDigitalSignal_ValidSignal_ReturnsDigitalSignal()
        {
            // Arrange
            string signal = "0028033517";

            // Act
            string result = RegisterManager.ConvertToDigitalSignal(signal);

            // Assert
            Assert.That(result, Is.EqualTo("0101E"));
        }

        [Test]
        public void TestReplaceArrayWithDictionaryValues_ValidInput_ReturnsUpdatedArray()
        {
            // Arrange
            string[] array = { "A", "B", "AND", "C" };
            var dictionary = new Dictionary<char, string>
            {
                { 'A', "10101" },
                { 'B', "11011" }
            };

            // Act
            string[] result = RegisterManager.ReplaceArrayWithDictionaryValues(array, dictionary);

            // Assert
            Assert.That(result, Is.EqualTo(new string[] { "10101", "11011", "AND", "C" }));
        }

        [Test]
        public void TestLoadRegisters_ValidFile_ReturnsUpdatedGates()
        {
            // Arrange
            string testFilePath = "test_file.txt";
            File.WriteAllText(testFilePath, "AND A B\nA 5000353000\nB 0050270050\n");

            // Act
            string[] result = RegisterManager.LoadRegisters(testFilePath);

            // Assert
            Assert.That(result, Is.EqualTo(new string[] { "AND", "10110", "01101" }));

            // Clean up
            File.Delete(testFilePath);
        }

        [Test]
        public void TestReadGates_InvalidFile_ThrowsException()
        {
            // Arrange
            string testFilePath = "invalid_file.txt";

            // Act & Assert
            Assert.That(() => RegisterManager.ReadGates(testFilePath), Throws.TypeOf<FileNotFoundException>());
        }

        [Test]
        public void TestCreateRegisterDictionary_InvalidLineFormat_ThrowsException()
        {
            // Arrange
            string testFilePath = "test_file.txt";
            File.WriteAllText(testFilePath, "AND 10101 11011\nA 5.0 0.0 3.3 5.0\n");

            char[] usedRegisters = { 'A' };

            // Act & Assert
            Assert.That(() => RegisterManager.CreateRegisterDictionary(testFilePath, usedRegisters), Throws.TypeOf<IncorrectFileFormatException>());

            // Clean up
            File.Delete(testFilePath);
        }

        [Test]
        public void TestConvertToDigitalSignal_InvalidLength_ThrowsException()
        {
            // Arrange
            string signal = "5.00.03.3";

            // Act & Assert
            Assert.That(() => RegisterManager.ConvertToDigitalSignal(signal), Throws.TypeOf<IncorrectFileFormatException>());
        }

        [Test]
        public void TestReplaceArrayWithDictionaryValues_ElementNotInDictionary_RemainsUnchanged()
        {
            // Arrange
            string[] array = { "C", "AND", "D" };
            var dictionary = new Dictionary<char, string>
            {
                { 'A', "10101" },
                { 'B', "11011" }
            };

            // Act
            string[] result = RegisterManager.ReplaceArrayWithDictionaryValues(array, dictionary);

            // Assert
            Assert.That(result, Is.EqualTo(new string[] { "C", "AND", "D" }));
        }
    }
}
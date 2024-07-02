using LogicGatesApp;
using NUnit.Framework;

namespace LogicGatesAppTest
{
    [TestFixture]
    public class LogicGatesManagerTest
    {
        [Test]
        public void TestIsRegister_ValidRegister_ReturnsTrue()
        {
            // Arrange
            string validRegister = "10101";

            // Act
            bool result = LogicGatesManager.IsRegister(validRegister);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestIsRegister_InvalidRegister_ReturnsFalse()
        {
            // Arrange
            string invalidRegister = "101011";

            // Act
            bool result = LogicGatesManager.IsRegister(invalidRegister);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestIsLogicGate_ValidLogicGate_ReturnsTrue()
        {
            // Arrange
            string validLogicGate = "AND";

            // Act
            bool result = LogicGatesManager.IsLogicGate(validLogicGate);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestIsLogicGate_InvalidLogicGate_ReturnsFalse()
        {
            // Arrange
            string invalidLogicGate = "XYZ";

            // Act
            bool result = LogicGatesManager.IsLogicGate(invalidLogicGate);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestIsTwoParameterGate_ValidTwoParameterGate_ReturnsTrue()
        {
            // Arrange
            string validTwoParameterGate = "AND";

            // Act
            bool result = LogicGatesManager.IsTwoParameterGate(validTwoParameterGate);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void TestIsTwoParameterGate_NotGate_ReturnsFalse()
        {
            // Arrange
            string notGate = "NOT";

            // Act
            bool result = LogicGatesManager.IsTwoParameterGate(notGate);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void TestSolveLogicGates_SimpleNotGate()
        {
            // Arrange
            string[] logicGates = { "NOT", "10101" };

            // Act
            string result = LogicGatesManager.SolveLogicGates(logicGates);

            // Assert
            Assert.That(result, Is.EqualTo("01010"));
        }

        [Test]
        public void TestSolveLogicGates_SimpleAndGate()
        {
            // Arrange
            string[] logicGates = { "AND", "10101", "11011" };

            // Act
            string result = LogicGatesManager.SolveLogicGates(logicGates);

            // Assert
            Assert.That(result, Is.EqualTo("10001"));
        }

        [Test]
        public void TestSolveLogicGates_ComplexGate()
        {
            // Arrange
            string[] logicGates = { "AND", "10101", "OR", "00110", "01010" };

            // Act
            string result = LogicGatesManager.SolveLogicGates(logicGates);

            // Assert
            Assert.That(result, Is.EqualTo("00100"));
        }

        [Test]
        public void TestSolveLogicGates_InvalidGate_ThrowsException()
        {
            // Arrange
            string[] logicGates = { "NOT", "10101", "11011" };

            // Act & Assert
            Assert.That(() => LogicGatesManager.SolveLogicGates(logicGates), Throws.TypeOf<IncorrectGateInputException>());
        }

        [Test]
        public void TestSolveLogicGates_UnsolvableExpression_ThrowsException()
        {
            // Arrange
            string[] logicGates = { "AND", "10101", "11011", "NOT" };

            // Act & Assert
            Assert.That(() => LogicGatesManager.SolveLogicGates(logicGates), Throws.TypeOf<IncorrectGateInputException>());
        }
    }
}

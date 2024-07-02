using LogicGatesApp;
using NUnit.Framework;

namespace LogicGatesAppTest
{
    public class GateSolverTest
    {
        [Test]
        public void TestSolveNOTGate_ValidRegister_ReturnsInvertedRegister()
        {
            // Arrange
            string inputRegister = "10101";

            // Act
            string result = GateSolver.SolveNOTGate(inputRegister);

            // Assert
            Assert.That(result, Is.EqualTo("01010"));
        }

        [Test]
        public void TestSolveNOTGate_RegisterWithInvalidLength_ThrowsException()
        {
            // Arrange
            string inputRegister = "101010"; // Invalid length

            // Act & Assert
            Assert.Throws<IncorrectRegisterLengthException>(() => GateSolver.SolveNOTGate(inputRegister));
        }

        [Test]
        public void TestSolveTwoParameterGate_ANDGate_ReturnsCorrectResult()
        {
            // Arrange
            string logicalGate = "AND";
            string registerOne = "10101";
            string registerTwo = "11011";

            // Act
            string result = GateSolver.SolveTwoParameterGate(logicalGate, registerOne, registerTwo);

            // Assert
            Assert.That(result, Is.EqualTo("10001"));
        }

        [Test]
        public void TestSolveTwoParameterGate_ORGate_ReturnsCorrectResult()
        {
            // Arrange
            string logicalGate = "OR";
            string registerOne = "10101";
            string registerTwo = "11011";

            // Act
            string result = GateSolver.SolveTwoParameterGate(logicalGate, registerOne, registerTwo);

            // Assert
            Assert.That(result, Is.EqualTo("11111"));
        }

        [Test]
        public void TestSolveTwoParameterGate_NandGate_ReturnsCorrectResult()
        {
            // Arrange
            string logicalGate = "NAND";
            string registerOne = "10101";
            string registerTwo = "11011";

            // Act
            string result = GateSolver.SolveTwoParameterGate(logicalGate, registerOne, registerTwo);

            // Assert
            Assert.That(result, Is.EqualTo("01110"));
        }

        [Test]
        public void TestSolveTwoParameterGate_XorGate_ReturnsCorrectResult()
        {
            // Arrange
            string logicalGate = "XOR";
            string registerOne = "10101";
            string registerTwo = "11011";

            // Act
            string result = GateSolver.SolveTwoParameterGate(logicalGate, registerOne, registerTwo);

            // Assert
            Assert.That(result, Is.EqualTo("01110"));
        }

        [Test]
        public void TestSolveTwoParameterGate_InvalidGateType_ReturnsError()
        {
            // Arrange
            string logicalGate = "InvalidGate";
            string registerOne = "10101";
            string registerTwo = "11011";

            // Act
            string result = GateSolver.SolveTwoParameterGate(logicalGate, registerOne, registerTwo);

            // Assert
            Assert.That(result, Is.EqualTo("EEEEE"));
        }

        [Test]
        public void TestSolveTwoParameterGate_RegistersWithInvalidLength_ThrowsException()
        {
            // Arrange
            string logicalGate = "AND";
            string registerOne = "10101";
            string registerTwo = "110110"; // Invalid length

            // Act & Assert
            Assert.Throws<IncorrectRegisterLengthException>(() => GateSolver.SolveTwoParameterGate(logicalGate, registerOne, registerTwo));
        }
    }
}

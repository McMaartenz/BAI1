using Microsoft.VisualBasic;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BAI
{
    [TestFixture]
    public class Opdr3Tests
    {
        [TestCase(1, 100, 100)]  // 100 getallen, keuze uit 100
        [TestCase(100, 100, 1)]  // 1 getal, keuze uit 1
        [TestCase(1, 100, 4)]  // 4 getallen, keuze uit 100
        [TestCase(-10, 20, 30)] // negatieve lower
        [TestCase(-50, -20, 10)] // negatieve upper en lower
        [TestCase(0, 1_000_000, 10_000)]  // Veel getallen
        public void Opdr3_01_SizeOk(int lower, int upper, int count)
        {
            // Arrange
            Stack<int> stack;
            int expected = count;

            // Act
            stack = BAI_Afteken1.Opdr3RandomNumbers(lower, upper, count);
            int actual = stack.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 100, 100)]  // 100 getallen, keuze uit 100
        [TestCase(100, 100, 1)]  // 1 getal, keuze uit 1
        [TestCase(1, 100, 4)]  // 4 getallen, keuze uit 100
        [TestCase(-10, 20, 30)] // negatieve lower
        [TestCase(-50, -20, 10)] // negatieve upper en lower
        [TestCase(0, 1_000_000, 10_000)]  // Veel getallen
        public void Opdr3_02_UniqueNumbers(int lower, int upper, int count)
        {
            // Arrange
            Stack<int> stack;
            int expected = count;

            // Act
            stack = BAI_Afteken1.Opdr3RandomNumbers(lower, upper, count);
            int actual = stack.Distinct().Count<int>();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestCase(1, 100, 100)]  // 100 getallen, keuze uit 100
        [TestCase(100, 100, 1)]  // 1 getal, keuze uit 1
        [TestCase(1, 100, 4)]  // 4 getallen, keuze uit 100
        [TestCase(-10, 20, 30)] // negatieve lower
        [TestCase(-50, -20, 10)] // negatieve upper en lower
        [TestCase(0, 1_000_000, 10_000)]  // Veel getallen
        public void Opdr3_03_BoundsOk(int lower, int upper, int count)
        {
            // Arrange
            Stack<int> stack;
            int expected = 0;

            // Act
            stack = BAI_Afteken1.Opdr3RandomNumbers(lower, upper, count);
            var out_bounds = stack.Where<int>(num => num < lower || num > upper);
            int actual = out_bounds.Count<int>();

            // Assert
            Assert.AreEqual(expected, actual);
        }


        //
        // Als deze test faalt, dan is de complexiteit van de oplossing verkeerd. Door
        // minder lusjes te gebruiken of betere datastructuren, kun je er voor zorgen
        // dat de test wel binnen 5 seconden slaagt.
        //
        [Test, Timeout(5000)]
        public void Opdr3_04_ComplexityOk()
        {
            // Act
            Stack<int> stack = BAI_Afteken1.Opdr3RandomNumbers(100_000, 500_000, 400_001);  // Veel getallen, elk getal komt 1x voor
        }
    }
}

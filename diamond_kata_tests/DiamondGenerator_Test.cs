using diamond_kata.DiamondGenerator;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace diamond_kata_tests
{
    public class DiamondGenerator_Test
    {
        [Theory]
        [InlineData('A', new string[] { "A" })]
        [InlineData('B', new string[] { " A ", "B B", " A " })]
        [InlineData('C', new string[] { "  A  ", " B B ", "C   C", " B B ", "  A  " })]
        public void DiamondGenerator_Small_Cases_Passes(char input, string[] expected)
        {
            // arrange 
            IDiamondGenerator generator = new DiamondGenerator();

            // act
            string[] output = generator.CreateDiamond(input);

            // assert 
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData('1')]
        [InlineData('@')]
        [InlineData(' ')]
        [InlineData('\0')] // Null character
        public void DiamondGenerator_Invalid_Input_Throws_Exception(char invalidInput)
        {
            // arrange
            IDiamondGenerator generator = new DiamondGenerator();

            // assert
            Assert.Throws<ArgumentException>(() => generator.CreateDiamond(invalidInput));
        }

        [Fact]
        public void DiamondGenerator_Lowercase_Input()
        {
            // arrange
            IDiamondGenerator generator = new DiamondGenerator();
            string[] expected = ["A"];

            // act
            string[] output = generator.CreateDiamond('a');

            // assert
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData('A', 1)]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        [InlineData('Z', 51)]
        public void DiamondGenerator_Validates_Line_Lengths(char inputChar, int expectedSize)
        {
            // arrange
            IDiamondGenerator generator = new DiamondGenerator();

            // act
            string[] diamond = generator.CreateDiamond(inputChar);

            // assert
            Assert.Equal(expectedSize, diamond.Length); // checking length of string[]

            // all lines should have the same char count
            foreach (var line in diamond)
            {
                Assert.Equal(expectedSize, line.Length);
            }
        }

        [Theory]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        [InlineData('Z', 51)]
        public void DiamondGenerator_Validates_First_Last_Lines(char inputChar, int expectedSize)
        {
            // arrange
            IDiamondGenerator generator = new DiamondGenerator();

            // act
            string[] diamond = generator.CreateDiamond(inputChar);

            // assert
            int midpoint = (expectedSize - 1) / 2;

            // the first/last should be 'A' centered
            Assert.Equal('A', diamond[0][midpoint]);
            Assert.Equal('A', diamond[expectedSize - 1][midpoint]);

            var hashSet_FirstLine = diamond[0].ToHashSet();
            Assert.True(hashSet_FirstLine.Count == 2);
            Assert.Contains('A', hashSet_FirstLine);
            Assert.Contains(' ', hashSet_FirstLine);

            var hashSet_LastLine = diamond[expectedSize - 1].ToHashSet();
            Assert.True(hashSet_LastLine.Count == 2);
            Assert.Contains('A', hashSet_LastLine);
            Assert.Contains(' ', hashSet_LastLine);
        }

        [Theory]
        [InlineData('B', 3)]
        [InlineData('C', 5)]
        [InlineData('Z', 51)]
        public void DiamondGenerator_Validates_Middle_Line(char inputChar, int expectedSize)
        {
            // arrange
            IDiamondGenerator generator = new DiamondGenerator();

            // act
            string[] diamond = generator.CreateDiamond(inputChar);

            // assert
            int characterIndex = inputChar - 'A';

            // the mid line should be inputChar
            Assert.Equal(inputChar, diamond[characterIndex][0]);
            Assert.Equal(inputChar, diamond[characterIndex][expectedSize - 1]);

            var hashSet_MidLine = diamond[characterIndex].ToHashSet();
            Assert.True(hashSet_MidLine.Count == 2);
            Assert.Contains(inputChar, hashSet_MidLine);
            Assert.Contains(' ', hashSet_MidLine);
        }
    }
}

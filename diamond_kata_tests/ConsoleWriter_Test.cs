using diamond_kata.OutputWriter;

namespace diamond_kata_tests
{
    public class ConsoleWriter_Test
    {
        [Theory]
        [InlineData(new string[] { "A" }, "A\r\n")]
        [InlineData(new string[] { " A ", "B B", " A " }, " A \r\nB B\r\n A \r\n")]
        [InlineData(new string[] { }, "")]
        public void WriteToConsole_Various_Cases_Test(string[] diamond, string expectedOutput)
        {
            // arrange
            IOutputWriter writer = new ConsoleWriter();
            StringWriter stringWriter = new ();
            Console.SetOut(stringWriter);

            // act
            writer.Write(diamond);

            // assert
            string output = stringWriter.ToString();
            Assert.Equal(expectedOutput, output);
        }
    }
}

namespace diamond_kata.OutputWriter
{
    internal class ConsoleWriter : IOutputWriter
    {
        public void Write(string[] diamond)
        {
            foreach(string line in diamond)
            {
                Console.WriteLine(line);
            }
        }
    }
}

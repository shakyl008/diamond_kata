namespace diamond_kata.DiamondGenerator
{
    internal class DiamondGenerator : IDiamondGenerator
    {
        private readonly char _whiteSpaceChar = ' ';

        public string[] CreateDiamond(char inputChar)
        {
            inputChar = ValidateAndNormalizeInput(inputChar);

            if (inputChar == 'A')
            {
                return new[] { "A" };
            }

            int characterIndex = GetCharacterIndex(inputChar);
            string[] diamond = new string[characterIndex * 2 + 1];

            diamond[0] = GenerateLine('A', characterIndex);
            for (int i = 1; i < characterIndex; i++)
            {
                diamond[i] = GenerateLine((char)('A' + i), characterIndex - i);
            }

            diamond[characterIndex] = GenerateLine(inputChar, 0);

            for (int i = characterIndex + 1; i < diamond.Length; i++)
            {
                diamond[i] = diamond[diamond.Length - 1 - i];
            }

            return diamond;
        }

        private char ValidateAndNormalizeInput(char inputChar)
        {
            inputChar = char.ToUpper(inputChar);

            if (!char.IsLetter(inputChar) || inputChar < 'A' || inputChar > 'Z')
            {
                throw new ArgumentException("Input must be a letter between A and Z.");
            }

            return inputChar;
        }

        private int GetCharacterIndex(char inputChar)
        {
            return inputChar - 'A';
        }

        private string GenerateLine(char letter, int leadingSpaces)
        {
            if (letter == 'A')
            {
                return new string(_whiteSpaceChar, leadingSpaces) + letter + new string(_whiteSpaceChar, leadingSpaces);
            }

            int innerSpaces = (letter - 'A') * 2 - 1;
            return new string(_whiteSpaceChar, leadingSpaces) + letter + new string(_whiteSpaceChar, innerSpaces) + letter + new string(_whiteSpaceChar, leadingSpaces);
        }
    }
}

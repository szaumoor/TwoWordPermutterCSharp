namespace TwoWordPermutterCSharp
{
    internal static class Io
    {
        private const char FirstWordMark = '#';
        private const char SecondWordMark = '*';
        private const string CommentMark = "//";

        public static List<Word> GetWordsFromFile(string path)
        {
            return [.. File.ReadLines(path)
                .Where(LineIsValid)
                .Select(GetWord)
                .Order()];
        }

        private static bool LineIsValid(string line)
        {
            line = line.Trim();
            return line.Length > 0 && !line.StartsWith(CommentMark);
        }

        private static Word GetWord(string word)
        {
            var lastChar = word[^1];
            return lastChar switch
            {
                FirstWordMark => new Word(word[..^1], WordType.FirstWord),
                SecondWordMark => new Word(word[..^1], WordType.SecondWord),
                _ => new Word(word, WordType.AnyOrderWord)
            };
        }
    }
}

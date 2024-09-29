namespace TwoWordPermutterCSharp
{
    internal static class Permutator
    {
        public static List<string> GeneratePermutations ( List<Word> words, int charLimit )
        {
            var wordsLength = words.Count;
            List<string> permutations = [];
            var permCount = 0;

            var nonSecondWords = words.Where(w => w.Type != WordType.SecondWord).ToList();
            foreach (var word in nonSecondWords)
            {
                var combinations = words
                    .Where(secondWord => !secondWord.Equals(word))
                    .Where(secondWord => secondWord.Type != WordType.FirstWord)
                    .Where(secondWord => NotAlliteration(word.Content, secondWord.Content))
                    .Select(secondWord => word.Content + secondWord)
                    .Where(str => str.Length <= charLimit)
                    .ToList();
                if (combinations.Count == 0) continue;

                permutations.Add($"Permutations starting with {word}\n------------------------------------");
                permutations.AddRange(combinations);
                permCount += combinations.Count;
                permutations.Add("\n");
            }
            permutations.Add($"------------------------------------\nA total of {permCount} valid permutations were discovered");
            return permutations;
        }

        private static bool NotAlliteration(string firstWord, string secondWord)
        {
            firstWord = firstWord.ToUpper();
            secondWord = secondWord.ToUpper();
            return firstWord[0] != secondWord[0] && firstWord[^1] !=  secondWord[0];
        }
    }
}

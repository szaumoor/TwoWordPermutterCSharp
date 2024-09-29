namespace TwoWordPermutterCSharp
{
    internal enum WordType
    {
        AnyOrderWord, FirstWord, SecondWord
    }

    internal class Word(string content, WordType type) : IComparable<Word>
    {
        public WordType Type { get; } = type;
        public string Content { get; } = content ?? throw new ArgumentNullException(nameof(content));

        public override bool Equals(object? obj)
        {
            if ( this == obj ) return true;
            if ( obj == null || GetType() != obj.GetType() ) return false;
            var word = obj as Word;
            return Content.Equals(word.Content);
        }

        public override int GetHashCode() => HashCode.Combine(Content, Type);
        public override string ToString() => Content;
        public int CompareTo(Word? other) => content.CompareTo(other.Content);
    }
}

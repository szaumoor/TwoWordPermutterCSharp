using TwoWordPermutterCSharp;

Console.Write("Enter a file path: ");
var file = Console.ReadLine();

if (!File.Exists(file))
{
    Console.WriteLine("File could not be found!");
    return;
}

Console.Write("Enter a limit: ");
var limit = int.TryParse(Console.ReadLine(), out var intLimit );
if (!limit)
{
    Console.WriteLine("Invalid input (not an integer)!");
    return;
}

if (intLimit < 0)
{
    Console.WriteLine("Invalid input (not a positive integer)!");
    return;
}

var combinations = Permutator.GeneratePermutations(Io.GetWordsFromFile(file), intLimit);
File.WriteAllLines(Path.GetFileNameWithoutExtension(file) + "_output.txt", combinations);
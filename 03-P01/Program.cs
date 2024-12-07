//mul\(\d{1,3}\,\d{1,3}\)
using System.Text.RegularExpressions;

string multiplicationPattern = @"mul\(\d{1,3}\,\d{1,3}\)";
string valuesPattern = @"\d{1,3}";

// Get the current directory of the application
string rootPath = AppDomain.CurrentDomain.BaseDirectory;

// Specify the file name (assumes the file is in the root folder)
string fileName = "input.txt";
string filePath = Path.Combine(rootPath, fileName);

var input = File.ReadAllText(filePath);

var multiplications = Regex.Matches(input, multiplicationPattern).ToList();

var result = 0;
foreach (Match multiplication in multiplications)
{
    var valuesToMultiply = Regex.Matches(multiplication.Value, valuesPattern);
    result += (int.Parse(valuesToMultiply.ElementAt(0).Value) * int.Parse(valuesToMultiply.ElementAt(1).Value));

}
Console.WriteLine($"Result of the sum of all multiplications:{result}");
Console.ReadLine();

using System.Text.RegularExpressions;
using Advent_of_Code_2024.Helpers;

namespace Advent_of_Code_2024.Day03;

public class Day03
{
    private readonly string _multiplicationPattern = @"mul\(\d{1,3}\,\d{1,3}\)";
    private readonly string _valuesPattern = @"\d{1,3}";

    private const string _multiplicationPatternPart02 = @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)";

    public void Part01()
    {
        var input = FileHelper.ReadFromTxtFile("input.txt", nameof(Day03));

        var multiplications = Regex.Matches(input, _multiplicationPattern).ToList();
        var result = 0;
        foreach (Match multiplication in multiplications)
        {
            var valuesToMultiply = Regex.Matches(multiplication.Value, _valuesPattern).ToList().Select(m => int.Parse(m.Value));
            result += valuesToMultiply.ElementAt(0) * valuesToMultiply.ElementAt(1);
        }

        OutputHelper.DisplayResultMessage("Day 03 - Part 01", result);
    }

    public void Part02()
    {
        const string enable = "do()";
        const string disable = "don't()";

        var input = GetInput();

        var sum = 0;
        var enabled = true;

        var matches = Regex.Matches(input, _multiplicationPatternPart02).ToList();

        foreach (Match match in matches)
        {
            var matchValue = match.ToString();
            switch (matchValue)
            {
                case enable:
                    enabled = true;
                    break;
                case disable:
                    enabled = false;
                    break;
                default:
                    {
                        if (enabled)
                        {
                            var x = int.Parse(match.Groups[1].Value);
                            var y = int.Parse(match.Groups[2].Value);
                            sum += x * y;
                        }

                        break;
                    }
            }
        }

        var result = sum;

        OutputHelper.DisplayResultMessage("Day 03 - Part 02", result);

    }

    private string GetInput()
    {
        return FileHelper.ReadFromTxtFile("input.txt", nameof(Day03));
    }
}

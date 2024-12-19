using System;

namespace Advent_of_Code_2024.Helpers;

public class OutputHelper
{
    public static void DisplayResultMessage(string challengeName, int result)
    {
        Console.WriteLine($" {challengeName} - result is: {result}");
        Console.WriteLine("#####");
    }
}

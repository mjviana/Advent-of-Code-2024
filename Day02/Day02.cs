using System;
using Advent_of_Code_2024.Business;

namespace Advent_of_Code_2024.Day02;

public class Day02 : IPuzzle
{
    internal class Report(string line)
    {
        public string Line { get; } = line;
        public IReadOnlyList<int> Levels { get; } = line.Split(" ").Select(int.Parse).ToList();
    }

    public void Part01()
    {
        var reports = GetReports();

        int numberOfValidReports = reports.Select(report => Differences(report.Levels)).Count(IsSafe);

        Console.WriteLine($" Day02 Part 01 - Number of valid reports: {numberOfValidReports}");
        Console.WriteLine("#####");
    }

    public void Part02()
    {
        var reports = GetReports();

        int numberOfValidReports = 0;
        foreach (var report in reports)
        {
            var differences = Differences(report.Levels);
            if (IsSafe(differences))
            {
                numberOfValidReports++;
                continue;
            }

            var isSafe = false;
            for (var i = 0; !isSafe && i < report.Levels.Count; i++)
            {
                var newReport = new List<int>(report.Levels);
                newReport.RemoveAt(i);
                differences = Differences(newReport);
                isSafe = IsSafe(differences);
            }
            if (isSafe) numberOfValidReports++;
        }

        Console.WriteLine($" Day02 Part 02 - Number of valid reports: {numberOfValidReports}");
        Console.WriteLine("#####");
    }

    private static List<string> GetLevels(string report)
    {
        return [.. report.Split(" ")];
    }

    private static IReadOnlyList<int> Differences(IReadOnlyList<int> levels)
    {
        List<int> differences = [];

        for (int i = 0; i < levels.Count - 1; i++)
        {
            var diff = levels[i + 1] - levels[i];
            differences.Add(diff);
        }

        var originalSize = levels.Count;
        var diffSize = differences.Count;

        return differences;
    }

    private static bool IsSafe(IReadOnlyCollection<int> differences) =>
        differences.All(difference => difference is >= 1 and <= 3) ||
        differences.All(difference => difference is <= -1 and >= -3);

    private static List<Report> GetReports()
    {
        // Get the folder name from the class name
        string folderName = nameof(Day02); // This will give "Day02"

        // Build the file path
        string rootPath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(rootPath, folderName, "input.txt");

        // Read all lines, treating them as levels and create list of reports
        return File.ReadAllLines(filePath).Select(l => new Report(l)).ToList();
    }
}

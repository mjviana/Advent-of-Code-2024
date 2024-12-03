// Get the current directory of the application
string rootPath = AppDomain.CurrentDomain.BaseDirectory;

// Specify the file name (assumes the file is in the root folder)
string fileName = "input.txt";
string filePath = Path.Combine(rootPath, fileName);

var input = File.ReadAllText(filePath);

var reports = input.Split("\r\n");

int numberOfValidReports = 0;

foreach (var report in reports)
{
    var levels = report.Split(" ");

    bool allIncrease = false;
    bool allDecrease = false;

    // todo: go through each element of numbers and compare it with the next one and apply the rules to check if is a valid report 
    // rule #1 - levels should all increase or decrease
    // rule #2 - Two adjacent levels differ by at least one at most three 

    if (levels.Length > 2)
    {
        // Determine if the sequence is increasing or decreasing
        bool isIncreasing = int.Parse(levels[1]) > int.Parse(levels[0]);
        bool isValidReport = true;

        for (int i = 0; i < levels.Length - 1; i++)
        {
            var val1 = int.Parse(levels[i]);
            var val2 = int.Parse(levels[i + 1]);
            int diff = int.Parse(levels[i + 1]) - int.Parse(levels[i]);

            // Checking rule #1 -  levels should all increase or decrease
            if ((isIncreasing && diff <= 0) || (!isIncreasing && diff >= 0))
            {
                isValidReport = false;
                continue;
            }

            // Checking rule #2 - Two adjacent levels differ by at least one at most three 
            if (Math.Abs(diff) < 1 || Math.Abs(diff) > 3)
            {
                isValidReport = false;
                continue;
            }

        }
        if (isValidReport)
            numberOfValidReports++;
    }
}

System.Console.WriteLine($"Number of valid reports: {numberOfValidReports}");
Console.ReadLine();


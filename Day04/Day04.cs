using Advent_of_Code_2024.Business;
using Advent_of_Code_2024.Helpers;

namespace Advent_of_Code_2024.Day04
{
    enum Directions
    {
        Straight = 0,
        Up = -1,
        Down = 1,
        Left = -1,
        Right = 1
    }

    public class Day04 : IPuzzle
    {
        const string Keyword = "XMAS";
        List<string> input = new();
        int rows = 0;
        int columns = 0;
        public void Part01()
        {
            input = FileHelper.ReadLinesFromTxtFile("input.txt", nameof(Day04)).ToList();
            rows = input.Count;
            columns = input[0].Length;

            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    count += CountWithDirections(i, j, Directions.Right, Directions.Straight, Keyword);
                    count += CountWithDirections(i, j, Directions.Left, Directions.Straight, Keyword);
                    count += CountWithDirections(i, j, Directions.Straight, Directions.Down, Keyword);
                    count += CountWithDirections(i, j, Directions.Straight, Directions.Up, Keyword);
                    count += CountWithDirections(i, j, Directions.Right, Directions.Down, Keyword);
                    count += CountWithDirections(i, j, Directions.Right, Directions.Up, Keyword);
                    count += CountWithDirections(i, j, Directions.Left, Directions.Down, Keyword);
                    count += CountWithDirections(i, j, Directions.Left, Directions.Up, Keyword);
                }
            }

            OutputHelper.DisplayResultMessage("Day 04 - Part 01", count);

        }

        public void Part02()
        {
            throw new NotImplementedException();
        }

        private int CountWithDirections(int rowPosition, int columnPosition, Directions rowDirection, Directions columnDirection, string keyword)
        {
            for (int i = 0; i < keyword.Length; i++)
            {
                // Make sure that it's inside the input bounds
                if (rowPosition < 0 || rowPosition >= rows) return 0;
                if (columnPosition < 0 || columnPosition >= columns) return 0;

                // Check for keyword
                if (input[rowPosition][columnPosition] != keyword[i]) return 0;

                rowPosition += (int)rowDirection;
                columnPosition += (int)columnDirection;
            }

            return 1;
        }
    }
}
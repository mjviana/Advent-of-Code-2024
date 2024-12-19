namespace Advent_of_Code_2024.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Reads all lines of text from a specified .txt file located in the application's base directory or in a folder inside the application's base directory.
        /// </summary>
        /// <param name="fileName">The name of the .txt file to read (including the file extension).</param>
        /// <param name="folderName">
        /// (Optional) The name of a subfolder within the base directory where the file is located. 
        /// If not provided or empty, the method assumes the file is in the base directory.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of strings, where each element represents a line of text from the file.
        /// </returns>
        public static IEnumerable<string> ReadLinesFromTxtFile(string fileName, string? folderName = null)
        {
            // Build the file path
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(rootPath, !string.IsNullOrWhiteSpace(folderName) ? folderName : string.Empty, fileName);

            return File.ReadAllLines(filePath);
        }

        /// <summary>
        /// Reads the entire content of a specified .txt file located in the application's base directory 
        /// or within a specified subfolder of the base directory.
        /// </summary>
        /// <param name="fileName">
        /// The name of the .txt file to read, including the file extension (e.g., "example.txt").
        /// </param>
        /// <param name="folderName">
        /// (Optional) The name of a subfolder within the application's base directory where the file is located. 
        /// If not provided or is empty, the method assumes the file is located directly in the base directory.
        /// </param>
        /// <returns>
        /// A <see cref="string"/> containing the entire content of the specified file.
        /// </returns>
        public static string ReadFromTxtFile(string fileName, string? folderName = null)
        {
            // Build the file path
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(rootPath, !string.IsNullOrWhiteSpace(folderName) ? folderName : string.Empty, fileName);

            return File.ReadAllText(filePath);
        }
    }
}

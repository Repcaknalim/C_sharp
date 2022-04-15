using System.IO;

namespace TryCatchFinally
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstLine = "The first line was not read";
            try
            {
                var lines = File.ReadAllLines(args[0]);
                firstLine = (lines.Length > 0) ? lines[0] : "File is empty";
            }
            catch (IndexOutOfRangeException)
            {
                Console.Error.WriteLine("Insert proper filename");
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Cannot find {0}", args[0]);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.Error.WriteLine("File {0} is not accessable: {1}", args[0], ex.Message);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unable to read the lines from file: {0}", ex);
            }
            finally
            {
                Console.WriteLine(firstLine);
            }
        }
    }
}
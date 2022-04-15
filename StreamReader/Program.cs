using System.IO;

class Program
{
    static void Main()
    {
        var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var reader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}thePlan.txt");
        var writer = new StreamWriter($"{folder}{Path.DirectorySeparatorChar}email.txt");

        writer.WriteLine("From: Kot");
        writer.WriteLine("To: Dog");

        while(!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            writer.WriteLine($"Kot -> {line}");
        }

        writer.WriteLine();
        writer.WriteLine("MEOW");

        writer.Close();
        reader.Close();
    }
}
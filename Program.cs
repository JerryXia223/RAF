using System;
using System.IO;
using System.Text.Json;


[Serializable]
public class Event
{
    public int EventNumber { get; set; }
    public string Location { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        // Create an Event object and assign values to its properties
        Event myEvent = new Event
        {
            EventNumber = 1,
            Location = "Calgary"
        };

        // Serialize the object to a file
        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        // Serialize Object to JSON File
        string jsonString = JsonSerializer.Serialize(myEvent);
        File.WriteAllText("event.json", jsonString);

        // Deserialize Object from JSON File
        string jsonFromFile = File.ReadAllText("event.json");
        Event deserializedEvent = JsonSerializer.Deserialize<Event>(jsonFromFile);

        // Display values on the console
        Console.WriteLine($"Event Number: {deserializedEvent.EventNumber}");
        Console.WriteLine($"Location: {deserializedEvent.Location}");

        static void ReadFromFile()
        {
            using (StreamWriter writer = new StreamWriter("event.txt", append: true))
            {
                writer.Write("Hackathon");
            }

            using (FileStream fileStream = new FileStream("event.txt", FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    Console.WriteLine("\nIn Word: " + reader.ReadToEnd());

                    fileStream.Seek(0, SeekOrigin.Begin);
                    Console.WriteLine("The First Character is: \"" + (char)reader.Read() + "\"");

                    fileStream.Seek(fileStream.Length / 2, SeekOrigin.Begin);
                    Console.WriteLine("The Middle Character is: \"" + (char)reader.Read() + "\"");

                    fileStream.Seek(-1, SeekOrigin.End);
                    Console.WriteLine("The Last Character is: \"" + (char)reader.Read() + "\"");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; // For JSON serialization

class JournalApp
{
    // JournalEntry class stores the data for each journal entry
    public class JournalEntry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }
        public string Mood { get; set; }
        public List<string> Tags { get; set; }

        public JournalEntry(string prompt, string response, string mood, List<string> tags)
        {
            Date = DateTime.Now.ToShortDateString();
            Prompt = prompt;
            Response = response;
            Mood = mood;
            Tags = tags ?? new List<string>();
        }
    }

    public class Journal
    {
        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public void AddNewEntry()
        {
            string[] prompts = {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };

            Random random = new Random();
            string randomPrompt = prompts[random.Next(prompts.Length)];

            Console.WriteLine($"Prompt: {randomPrompt}");
            Console.Write("Your response: ");
            string response = Console.ReadLine();
            Console.Write("How did you feel today (mood)? ");
            string mood = Console.ReadLine();
            Console.Write("Enter tags separated by commas (e.g., happy, productive): ");
            string tagsInput = Console.ReadLine();
            List<string> tags = new List<string>(tagsInput.Split(','));

            JournalEntry entry = new JournalEntry(randomPrompt, response, mood, tags);
            entries.Add(entry);
        }

        public void ShowEntries()
        {
            if (entries.Count == 0)
            {
                Console.WriteLine("No entries yet!");
                return;
            }

            foreach (var entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine($"Mood: {entry.Mood}");
                Console.WriteLine($"Tags: {string.Join(", ", entry.Tags)}");
                Console.WriteLine("-----------------------------------------------------");
            }
        }

        public void SaveEntriesToCsv(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in entries)
                {
                    string tags = string.Join(";", entry.Tags);
                    writer.WriteLine($"\"{entry.Date}\",\"{entry.Prompt}\",\"{entry.Response}\",\"{entry.Mood}\",\"{tags}\"");
                }
            }
            Console.WriteLine($"Entries have been saved to {filename}");
        }

        public void LoadEntriesFromCsv(string filename)
        {
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                entries.Clear();

                foreach (var line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 5)
                    {
                        string date = parts[0].Trim('"');
                        string prompt = parts[1].Trim('"');
                        string response = parts[2].Trim('"');
                        string mood = parts[3].Trim('"');
                        List<string> tags = new List<string>(parts[4].Trim('"').Split(';'));

                        entries.Add(new JournalEntry(prompt, response, mood, tags) { Date = date });
                    }
                }
                Console.WriteLine("Entries have been loaded.");
            }
            else
            {
                Console.WriteLine("The specified file does not exist.");
            }
        }

        public void SaveEntriesToJson(string filename)
        {
            string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
            File.WriteAllText(filename, json);
            Console.WriteLine($"Entries have been saved to {filename}");
        }

        public void LoadEntriesFromJson(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                entries = JsonConvert.DeserializeObject<List<JournalEntry>>(json);
                Console.WriteLine("Entries have been loaded.");
            }
            else
            {
                Console.WriteLine("The specified file does not exist.");
            }
        }
    }

    public static void Main()
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to your Journal App!");
            Console.WriteLine("1. Add a new entry");
            Console.WriteLine("2. View journal entries");
            Console.WriteLine("3. Save journal to CSV");
            Console.WriteLine("4. Load journal from CSV");
            Console.WriteLine("5. Save journal to JSON");
            Console.WriteLine("6. Load journal from JSON");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddNewEntry();
                    break;
                case "2":
                    journal.ShowEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save journal (CSV): ");
                    string csvFilename = Console.ReadLine();
                    journal.SaveEntriesToCsv(csvFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load journal (CSV): ");
                    string loadCsvFilename = Console.ReadLine();
                    journal.LoadEntriesFromCsv(loadCsvFilename);
                    break;
                case "5":
                    Console.Write("Enter filename to save journal (JSON): ");
                    string jsonFilename = Console.ReadLine();
                    journal.SaveEntriesToJson(jsonFilename);
                    break;
                case "6":
                    Console.Write("Enter filename to load journal (JSON): ");
                    string loadJsonFilename = Console.ReadLine();
                    journal.LoadEntriesFromJson(loadJsonFilename);
                    break;
                case "7":
                    Console.WriteLine("Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}

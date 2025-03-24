using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private static readonly string[] prompts =
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry(string response, string mood, string tags)
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Length)];
        JournalEntry entry = new JournalEntry(prompt, response, mood, tags);
        entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("No journal entries available.");
        }
        else
        {
            foreach (var entry in entries)
            {
                Console.WriteLine(entry);
            }
        }
    }

    public void SaveJournalCsv(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date,Prompt,Mood,Tags,Response");
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.ToCsvString());
            }
        }
    }

    public void SaveJournalJson(string filename)
    {
        string json = JsonConvert.SerializeObject(entries, Formatting.Indented);
        File.WriteAllText(filename, json);
    }

    public void LoadJournalCsv(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 5)
            {
                JournalEntry entry = new JournalEntry(parts[1], parts[4], parts[2], parts[3]);
                entry.Date = parts[0];
                entries.Add(entry);
            }
        }
    }

    public void LoadJournalJson(string filename)
    {
        string json = File.ReadAllText(filename);
        entries = JsonConvert.DeserializeObject<List<JournalEntry>>(json);
    }
}

using System;

public class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Mood { get; set; }
    public string Tags { get; set; }

    public JournalEntry(string prompt, string response, string mood, string tags)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToShortDateString();
        Mood = mood;
        Tags = tags;
    }

    public override string ToString()
    {
        return $"{Date} - Prompt: {Prompt} - Mood: {Mood} - Tags: {Tags} - Response: {Response}";
    }

    public string ToCsvString()
    {
        return $"\"{Date}\",\"{Prompt}\",\"{Mood}\",\"{Tags}\",\"{Response}\"";
    }
}

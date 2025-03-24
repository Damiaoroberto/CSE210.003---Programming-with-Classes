//Add all Exceeding Requirements

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Journal Program Menu");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to CSV");
            Console.WriteLine("4. Save Journal to JSON");
            Console.WriteLine("5. Load Journal from CSV");
            Console.WriteLine("6. Load Journal from JSON");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please respond to the prompt:");
                    Console.WriteLine("What was the best part of your day?");
                    string response = Console.ReadLine();

                    Console.WriteLine("How did you feel today (mood)?");
                    string mood = Console.ReadLine();

                    Console.WriteLine("Enter any tags for this entry (comma separated):");
                    string tags = Console.ReadLine();

                    journal.AddEntry(response, mood, tags);
                    break;

                case "2":
                    journal.DisplayJournal();
                    Console.WriteLine("\nPress Enter to return to the menu.");
                    Console.ReadLine();
                    break;

                case "3":
                    Console.Write("Enter filename to save the journal as CSV: ");
                    string saveCsvFile = Console.ReadLine();
                    journal.SaveJournalCsv(saveCsvFile);
                    Console.WriteLine("Journal saved to CSV!");
                    Console.ReadLine();
                    break;

                case "4":
                    Console.Write("Enter filename to save the journal as JSON: ");
                    string saveJsonFile = Console.ReadLine();
                    journal.SaveJournalJson(saveJsonFile);
                    Console.WriteLine("Journal saved to JSON!");
                    Console.ReadLine();
                    break;

                case "5":
                    Console.Write("Enter filename to load the journal from CSV: ");
                    string loadCsvFile = Console.ReadLine();
                    try
                    {
                        journal.LoadJournalCsv(loadCsvFile);
                        Console.WriteLine("Journal loaded from CSV!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error loading the journal file.");
                    }
                    Console.ReadLine();
                    break;

                case "6":
                    Console.Write("Enter filename to load the journal from JSON: ");
                    string loadJsonFile = Console.ReadLine();
                    try
                    {
                        journal.LoadJournalJson(loadJsonFile);
                        Console.WriteLine("Journal loaded from JSON!");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error loading the journal file.");
                    }
                    Console.ReadLine();
                    break;

                case "7":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}

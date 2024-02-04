using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Title: {entry.Title}\nDate: {entry.Date}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\nLocation: {entry.Location}\n");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                sw.WriteLine($"{entry.Date}|{entry.Title}|{entry.Prompt}|{entry.Response}|{entry.Location}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string[] parts = sr.ReadLine().Split('|');
                    if (parts.Length >= 4)
                    {
                        string title = parts[1];
                        string prompt = parts[2];
                        string response = parts[3];
                        string date = parts[0];
                        string location = (parts.Length == 5) ? parts[4] : "";

                        Entry entry = new Entry(title, prompt, response, date, location);
                        entries.Add(entry);
                    }
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. Creating a new journal.");
        }
    }
}

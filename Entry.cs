public class Entry
{
    public string Title { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Location { get; set; }

    public Entry(string title, string prompt, string response, string date, string location = "")
    {
        Title = title;
        Prompt = prompt;
        Response = response;
        Date = date;
        Location = location;
    }
}

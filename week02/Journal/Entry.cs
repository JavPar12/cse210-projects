public class Entry
{
    public string _date = DateTime.Now.ToShortDateString();
    public string _entry;
    public string _prompt;

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_prompt}");
        Console.WriteLine(_entry);
    }

}

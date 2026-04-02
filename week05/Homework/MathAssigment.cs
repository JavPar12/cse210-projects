// MathAssignment.cs
public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // constructor receives 4 parameters, but only gives 2 to the base (Assignment)
    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}
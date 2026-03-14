public class PromptGenerator
{
    private string[] _prompts =
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "What was the most challenging thing I faced today?",
        "If I had one thing I could do over today, what would it be?",
        "What lesson did today teach me?",
        "What moment today made me feel most at peace?",
        "What did I do today that helped me grow as a person?",
        "What is one small step I took today toward becoming the person I want to be?"

    };

    public string GetRandomPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(0, _prompts.Length);
        string prompt = _prompts[index];

        return prompt;
    }

}

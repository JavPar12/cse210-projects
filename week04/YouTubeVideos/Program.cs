using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video v1 = new Video("How to Learn C#", "Luis", 600);
        v1.AddComment(new Comment("Ana", "Great video!"));
        v1.AddComment(new Comment("Carlos", "Very helpful"));
        v1.AddComment(new Comment("Maria", "Thanks!"));

        // Video 2
        Video v2 = new Video("Workout Routine", "Mike", 900);
        v2.AddComment(new Comment("John", "Nice routine"));
        v2.AddComment(new Comment("Alex", "I will try this"));
        v2.AddComment(new Comment("Sara", "Amazing"));

        // Video 3
        Video v3 = new Video("Travel Vlog", "Sofia", 1200);
        v3.AddComment(new Comment("Luis", "Beautiful place"));
        v3.AddComment(new Comment("Dani", "I want to go there"));
        v3.AddComment(new Comment("Emma", "So cool"));

        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);

        // Mostrar resultados
        foreach (Video v in videos)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine(v.GetVideoInfo());

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine(c.GetCommentInfo());
            }
        }
    }
}

class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public string GetVideoInfo()
    {
        return $"Title: {_title}\nAuthor: {_author}\nLength: {_length} seconds\nComments: {GetCommentCount()}";
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}

class Comment
{
    private string _name;
    private string _text;

    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string GetCommentInfo()
    {
        return $"{_name}: {_text}";
    }
}
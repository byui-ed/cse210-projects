using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; }
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Video 1", "Author 1", 120);
        video1.Comments.Add(new Comment("Commenter 1", "This is a great video!"));
        video1.Comments.Add(new Comment("Commenter 2", "I love this video!"));

        Video video2 = new Video("Video 2", "Author 2", 90);
        video2.Comments.Add(new Comment("Commenter 3", "This is a good video."));
        video2.Comments.Add(new Comment("Commenter 4", "I like this video."));

        Video video3 = new Video("Video 3", "Author 3", 150);
        video3.Comments.Add(new Comment("Commenter 5", "This is a fantastic video!"));
        video3.Comments.Add(new Comment("Commenter 6", "I really love this video!"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.Length} seconds, Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"Name: {comment.Name}, Text: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}

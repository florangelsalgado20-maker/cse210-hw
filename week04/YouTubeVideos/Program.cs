using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string name, string text)
        {
            CommenterName = name;
            CommentText = text;
        }
    }

    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        
        private List<Comment> _comments;

        public Video(string title, string author, int length)
        {
            Title = title;
            Author = author;
            LengthInSeconds = length;
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

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Video 1 - Tu información
            Video video1 = new Video("Welcome to my channel", "Florangel Salgado", 210);
            video1.AddComment(new Comment("Florangel", "I'm very happy to share this code with you"));
            video1.AddComment(new Comment("BYU Student", "Hello BYU"));
            video1.AddComment(new Comment("Classmate", "Great work on this assignment!"));

            // Video 2 - Ejemplo
            Video video2 = new Video("C# Programming Basics", "Code Academy", 450);
            video2.AddComment(new Comment("John", "This tutorial is very helpful!"));
            video2.AddComment(new Comment("Maria", "Thanks for explaining it so clearly"));
            video2.AddComment(new Comment("Carlos", "I finally understand classes now"));
            video2.AddComment(new Comment("Ana", "Can you make more videos like this?"));

            // Video 3 - Ejemplo
            Video video3 = new Video("Object-Oriented Programming", "Tech Teacher", 380);
            video3.AddComment(new Comment("Student1", "Abstraction is so interesting!"));
            video3.AddComment(new Comment("Student2", "This helped me with my homework"));
            video3.AddComment(new Comment("Student3", "Excellent explanation!"));

            // Put videos in a list
            List<Video> videoList = new List<Video> { video1, video2, video3 };

            // Display all videos and their comments
            foreach (Video vid in videoList)
            {
                Console.WriteLine($"Title: {vid.Title}");
                Console.WriteLine($"Author: {vid.Author}");
                Console.WriteLine($"Length: {vid.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {vid.GetCommentCount()}");
                Console.WriteLine("Comments:");

                foreach (Comment c in vid.GetComments())
                {
                    Console.WriteLine($" - {c.CommenterName}: {c.CommentText}");
                }
                
                Console.WriteLine();
            }
        }
    }
}
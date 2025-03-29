using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }  
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        Comments = new List<Comment>();
    }

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main()
    {
        // Create some videos with new names and comments
        Video video1 = new Video("HOW TO PROGRAM - Getting Started!", "Brackeys", 200);
        Video video2 = new Video("Understanding Machine Learning", "Bob Williams", 300);
        Video video3 = new Video("Web Development in JavaScript", "Clara Davis", 180);

        // Add comments to video1
        video1.Comments.Add(new Comment("Lucas", "This video was super helpful, thanks!"));
        video1.Comments.Add(new Comment("Mia", "Great explanation, I learned a lot."));
        video1.Comments.Add(new Comment("Noah", "Looking forward to more tutorials like this!"));
        
        // Add comments to video2
        video2.Comments.Add(new Comment("Olivia", "I finally understand how regression works."));
        video2.Comments.Add(new Comment("Ethan", "Amazing content, would love to see more examples."));
        video2.Comments.Add(new Comment("Sophia", "Very clear explanation, thank you!"));

        // Add comments to video3
        video3.Comments.Add(new Comment("James", "I love how you explained asynchronous programming."));
        video3.Comments.Add(new Comment("Amelia", "This video helped me a lot with front-end frameworks."));
        
        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through videos and display information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            // Display comments for this video
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"  Comment by {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine();  
        }
    }
}

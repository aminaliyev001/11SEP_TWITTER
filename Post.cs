using IncludesNameSpace;
using UserNameSpace;
namespace PostNameSpace;

public class Post : BaseData {
    public int LikeCount {get;set;}
    public int ViewCount {get;set;}

    public Post(string _text, DateTime _datetime,User _fromuser) : base(_text,_datetime,_fromuser) {
        LikeCount = 0;
        ViewCount = 0;
    }
    public override string ToString()
    {
        return base.ToString() + $"\nLike count: {LikeCount}\nView count: {ViewCount}";
    }
    public void DisplayShort() {
        string text_show = "";
        if(Text.Length > 50) {
        text_show = Text.Substring(0,50) + " ...";
        } else {text_show = Text;}
        Console.WriteLine("__________");
        Console.WriteLine($"{text_show}\n\n");
        Console.WriteLine($"Likes: {LikeCount}          {DateTime.ToString("dd-MM-yyyy")}");
    }
    public void Display() {
        Console.WriteLine($"{Text}\n\n");
        Console.WriteLine($"Likes: {LikeCount}              View: {ViewCount}\n{DateTime.ToString("dd-MM-yyyy")}        @{FromUser.Name + " " + FromUser.Surname}");
    }
};
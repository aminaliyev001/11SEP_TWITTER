using IncludesNameSpace;
using PostNameSpace;
namespace UserNameSpace;

public class User : Human {
    public List<Post> posts {get;set;}
    public List<string> likes {get;set;}
    public User(string _name, string _surname, string _username, string _email, string _password) : base(_name, _surname, _username, _email, _password) {
        posts = new List<Post>();
        likes = new List<string>();
    } 
}
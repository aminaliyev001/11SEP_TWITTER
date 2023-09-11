using System.ComponentModel.DataAnnotations;
using NotificationNameSpace;
using UserNameSpace;
namespace IncludesNameSpace;
public abstract class Human {
    public List<Notification> notifications {get;set;} 
    public Guid guid {get;}
    private string name;
    public string Name {get => name; set {if(!string.IsNullOrWhiteSpace(value)) name = value; else throw new Exception("Adinizi duzgun formatda daxil edin :)");}}

    private string surname;
    public string Surname {get => surname; set {if(!string.IsNullOrWhiteSpace(value)) surname = value; else throw new Exception("Soyadanizi duzgun formatda daxil edin :)");}}

    private string username;
    public string Username {get => username; set {if(!string.IsNullOrWhiteSpace(value) && value.Any(char.IsDigit)) username = value; else throw new Exception("Usernamede reqemde istifade olunmalidir :)");}}

    private string email;
    public string Email {get => email; set{
        var email_check = new EmailAddressAttribute();
        if(!string.IsNullOrWhiteSpace(value) && email_check.IsValid(value) == true) email = value; else throw new Exception("E-mail duzgun daxil edilmeyib");}
        }
    private string password;
    public string Password {get => password; set {if(!string.IsNullOrWhiteSpace(value) && value.Length > 7) password = value; else throw new Exception("Password minimum 8 simvoldan ibaret olmalidir");}}
    public Human(string _name,string _surname,string _username, string _email, string _password) {
        guid = Guid.NewGuid();
        Name = _name;
        Surname = _surname;
        Username = _username;
        Email = _email;
        Password = _password;
        notifications = new List<Notification>();
    }
    public override string ToString()
    {
        return $"Full name: {name + " " + surname}\nUsername: {username}\nEmail: {email}\nPassword: {password}";
    }
    public virtual void Display() {
        Console.WriteLine(ToString());
    }
}
public abstract class BaseData {
    public Guid guid {get;private set;} 
    private string text;
    public string Text {get => text; set {if(!string.IsNullOrWhiteSpace(value))text = value;else throw new Exception("Bildirisin text-in duzgun teyin edin zehmet olmasa");}}
    public DateTime DateTime {get; set;}
    private User fromUser;
    public User FromUser {get => fromUser; set {fromUser = value;}}
    public BaseData(string _text, DateTime _datetime,User _fromuser) {
        guid = Guid.NewGuid();
        Text = _text;
        DateTime = _datetime;
        FromUser = _fromuser;
    }
    public override string ToString()
    {
        return $"Text: {text}\nDate and Time: {DateTime}";
    }
}
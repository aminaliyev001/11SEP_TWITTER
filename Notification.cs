using IncludesNameSpace;
using UserNameSpace;
namespace NotificationNameSpace;

public class Notification : BaseData {
    public void setUser(User user) {
        if(user != null)
            FromUser = user;
        else throw new Exception("User bos qala bilmez");
    }
    public Notification(string _text, DateTime _datetime, User _fromUser) : base(_text,_datetime,_fromUser) {
        setUser(_fromUser);
    }
    public override string ToString()
    {
        return base.ToString()+$"\nFrom: {FromUser.Username}";
    }
};
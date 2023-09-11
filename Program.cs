using IncludesNameSpace;
using NotificationNameSpace;
using AdminNameSpace;
using UserNameSpace;
using PostNameSpace;
using MailNameSpace;


List<Admin> admins = new List<Admin> {new Admin("Amin","Aliyev","aminali001","aminaliyev001@gmail.com","amin1234")};
List<User> users = new List<User>() {new User("Amin","Ali","aminali001","aminaliyev001@gmail.com","tonytony10"),
new User("Maga","Ali","maga001","das@gmail.com","maga1234")
};
users[1].posts.Add(new Post("Bugun mence hava kulekli olacag ve bu hamiya yaxsi tesir etmeye biler",DateTime.Now,users[1]));
users[1].posts.Add(new Post("Saat 8:30-den 17:00 e geder mektebde olmag cox yorucudur",DateTime.Now,users[1]));

User ? LoggedUser = null;
Admin ? LoggedAdmin = null;
void my_profile()
{
    my_profile_start:
    Console.Clear();
    Console.WriteLine("===== MY PROFILE =====\n");

    if (LoggedUser == null)
    {
        return;
    }
    Console.WriteLine($"Name: {LoggedUser.Name}");
    Console.WriteLine($"Surname: {LoggedUser.Surname}");
    Console.WriteLine($"Username: {LoggedUser.Username}");
    Console.WriteLine($"Email: {LoggedUser.Email}");

    Console.WriteLine("\n[E] => Edit profile\n[ESC] => Exit");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.E)
    {
        line_edit_name:
        try {
        Console.Clear();
        Console.WriteLine("\nEnter new name (leave blank to keep current):");
        string newName = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newName))
            LoggedUser.Name = newName;
        } catch(Exception e) {
            Console.WriteLine(e.Message);
            Thread.Sleep(2000);
            goto line_edit_name;
        }
        line_edit_Surname:
        try {
        Console.Clear();
        Console.WriteLine("Enter new surname (leave blank to keep current):");
        string newSurname = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newSurname))
            LoggedUser.Surname = newSurname;
        } catch(Exception e) {
            Console.WriteLine(e.Message);
            Thread.Sleep(2000);
            goto line_edit_Surname;
        }
        line_edit_email:
        try{
        Console.WriteLine("Enter new email (leave blank to keep current):");
        string newEmail = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newEmail))
            LoggedUser.Email = newEmail;
        } catch(Exception e) {
            Console.WriteLine(e.Message);
            Thread.Sleep(2000);
            goto line_edit_email;
        }
        Console.WriteLine("Profiliniz xetasiz sekilde redakte olundu!");
        Thread.Sleep(2000);
        goto my_profile_start;
    } else if(key.Key == ConsoleKey.Escape) {
        return;
    } else goto my_profile_start;
}

void my_posts()
{
    Console.Clear();
    Console.WriteLine("===== MY POSTS =====\n");
    if (LoggedUser == null)
    {
        return;
    }
    if (LoggedUser.posts.Count == 0)
    {
        Console.WriteLine("No posts");
    }
    else
    {
        for (int i = 0; i < LoggedUser.posts.Count; i++)
        {
            Console.Write($"[{i + 1}]");
            LoggedUser.posts[i].Display();
        }
    }
    Console.WriteLine("\n[P] => Add Post\n[ESC] => Exit");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.P)
    {
        Add_Post_line:
        Console.Clear();
        Console.WriteLine("\nEnter your post content:");
        string? content = Console.ReadLine();
        try {
        Post newPost = new Post(content,DateTime.Now,LoggedUser);
        LoggedUser.posts.Add(newPost);
        } catch(Exception e) {
            Console.WriteLine(e.Message);
            Thread.Sleep(2000);
            goto Add_Post_line;
        }
        Console.WriteLine("Post Elave edildi!");
        return;
    } else if (key.Key == ConsoleKey.Escape) {
        return;
    }
}
bool CheckUserExists(string _username) {
    if(string.IsNullOrWhiteSpace(_username))
        return false;
    foreach(var us in users) {
        if(us.Username == _username) 
            return true;
    }
    return false;
}
Admin AdminAuth(string _username, string _password) {
    if(string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
    return null;
    foreach(var ad in admins) {
        if(ad.Username == _username && ad.Password == _password) {
                return ad;
        }
    }
    return null;
}
User UserAuth(string _username, string _password) {
    if(string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(_password))
    return null;
    foreach(var ad in users) {
        if(ad.Username == _username && ad.Password == _password) {
                return ad;
        }
    }
    return null;
}
void menu_Adminlogin() {
    line_menu_Adminlogin:
    Console.Clear();
    Console.WriteLine("=====Log in to continue=====\n");

    Console.WriteLine("Username: ");
    string ? username_input = Console.ReadLine();
    Console.WriteLine("Password: ");
    string ? pass_input = Console.ReadLine();

    Admin admin = AdminAuth(username_input,pass_input);
    if(admin != null ){
        LoggedAdmin = admin;
        menu_admin();
        return;
    }
    Console.WriteLine("Username ve passwordu duzgun daxil edin zehmet olmasa");
    Thread.Sleep(1500);
    goto line_menu_Adminlogin;
}
void menu_UserLogin() {
    int sel = 1;
    while(true) {
        Console.Clear();
        Console.WriteLine("=====Choose to continue=====");
        switch(sel) {
            case 1:
            Console.WriteLine("Log in <<");
            Console.WriteLine("Sign up");
            break;
            case 2:
            Console.WriteLine("Log in");
            Console.WriteLine("Sign up <<");
            break;
        }
        ConsoleKeyInfo key = Console.ReadKey();
        if(key.Key == ConsoleKey.DownArrow && sel == 1)
            sel+=1;
        else if(key.Key == ConsoleKey.UpArrow && sel == 2)
            sel -=1;
        else if(key.Key == ConsoleKey.Enter)
            break;
    }
    if(sel == 1) {
    line_menu_UserLogin:
    Console.Clear();
    Console.WriteLine("=====Log in to continue=====\n");

    Console.WriteLine("Username: ");
    string ? username_input = Console.ReadLine();
    Console.WriteLine("Password: ");
    string ? pass_input = Console.ReadLine();
    User? CurrentUser = UserAuth(username_input,pass_input);
    if(CurrentUser != null) {
        LoggedUser = CurrentUser;
        menu_user();
        return;
    }
    Console.WriteLine("Username ve passwordu duzgun daxil edin zehmet olmasa");
    Thread.Sleep(1500);
    goto line_menu_UserLogin;

    } else if(sel == 2) {
        line_signup:
        Console.Clear();
        Console.WriteLine("=====Sign up to continue=====\n");

        Console.WriteLine("Name: ");
        string ? name_ = Console.ReadLine();
        Console.WriteLine("Surname: ");
        string ? surname_ = Console.ReadLine();
        Console.WriteLine("Username: ");
        string ? username_ = Console.ReadLine();
        Console.WriteLine("Email: ");
        string ? email_ = Console.ReadLine();
        Console.WriteLine("Password: ");
        string ? password_ = Console.ReadLine();
        if(CheckUserExists(username_) == false) {
            try {
                User newUser = new(name_,surname_,username_,email_,password_);
                Random random = new Random();
                int number_tesdiq = random.Next(1000, 10000);
                MailSender mail = new("smtp.gmail.com",587,"rideparkuber@gmail.com","ajbbjkamilfrcbau");
                mail.SendMail(email_,"Verify your email",$"Your code is: {number_tesdiq}");
                kod_user:
                Console.Clear();
                Console.WriteLine("Sizin e-maile gelen 4 reqemli sifreni zehmet olmasa tesdiqleyin: ");
                string? input_new_user = Console.ReadLine();
                int kod_email = int.TryParse(input_new_user,out _) ? Convert.ToInt32(input_new_user) : 0; 
                if(kod_email == number_tesdiq) {
                    users.Add(newUser);
                    Console.WriteLine("Tebrikler! Sizin hesab yaradildi");
                    Thread.Sleep(2500);
                    LoggedUser = newUser;
                    menu_user();
                } else {Console.WriteLine("Daxil etdiyiniz sifre yalnisdir :("); Thread.Sleep(2000); goto kod_user; }
            } catch(Exception e) {
                Console.WriteLine(e.Message);
                Thread.Sleep(2000);
                goto line_signup;
            }
            return;
        }
        Console.WriteLine("Bele bir Username movcuddur artig :(");
        Thread.Sleep(2000);
        goto line_signup;
    }
}
void menu_start() {
    int sel = 1;
    while(true) {
    Console.Clear();
    Console.WriteLine("=====Welcome To TWITTER=====\n");
        switch(sel) {
            case 1:
            Console.WriteLine("Log in as an user <<");
            Console.WriteLine("Log in as an admin");
            break;
            case 2:
            Console.WriteLine("Log in as an user");
            Console.WriteLine("Log in as an admin <<");
            break;
        }
        ConsoleKeyInfo key = Console.ReadKey();
        if(key.Key == ConsoleKey.DownArrow && sel == 1)
            sel+=1;
        else if(key.Key == ConsoleKey.UpArrow && sel == 2)
            sel -=1;
        else if(key.Key == ConsoleKey.Enter)
            break;
    }   
    if(sel == 1)
    menu_UserLogin();
    else menu_Adminlogin();
}
void menu_admin()
{
    int SIndex = 0;
    string[] options = { "Notifications", "Users", "Users Posts" };
    while (true)
    {
        Console.Clear();
        Console.WriteLine("===== ADMIN PANEL =====\n");
        for (int i = 0; i < options.Length; i++)
        {
            if (i == SIndex)
            {
                Console.WriteLine($"> {options[i]}");
            }
            else
            {
                Console.WriteLine($"  {options[i]}");
            }
        }
        Console.WriteLine("\n[ESC] => Exit");
        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (SIndex > 0) SIndex--;
                break;

            case ConsoleKey.DownArrow:
                if (SIndex < options.Length - 1) SIndex++;
                break;

            case ConsoleKey.Enter:
                switch (SIndex)
                {
                    case 0:
                        my_notifications(LoggedAdmin);
                        break;
                    case 1:
                        view_users_data();
                        break;
                    case 2:
                        view_users_posts();
                        break;
                }
                break;
            case ConsoleKey.Escape:
                return;
        }
    }
}
void view_users_data()
{
    int SIndex = 0;
    while (true)
    {
        Console.Clear();
        Console.WriteLine("===== USERS =====\n");
        for (int i = 0; i < users.Count; i++)
        {
            if (i == SIndex)
            {
                Console.WriteLine($"> Name: {users[i].Name}");
                Console.WriteLine($"  Surname: {users[i].Surname}");
                Console.WriteLine($"  Username: {users[i].Username}");
                Console.WriteLine($"  Email: {users[i].Email}");
                Console.WriteLine("-----------------------------");
            }
            else
            {
                Console.WriteLine($"  Name: {users[i].Name}");
                Console.WriteLine($"  Surname: {users[i].Surname}");
                Console.WriteLine($"  Username: {users[i].Username}");
                Console.WriteLine($"  Email: {users[i].Email}");
                Console.WriteLine("-----------------------------");
            }
        }
        Console.WriteLine("\n[Enter] => Delete\n[ESC] => Exit");
        ConsoleKeyInfo key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (SIndex > 0) SIndex--;
                break;

            case ConsoleKey.DownArrow:
                if (SIndex < users.Count - 1) SIndex++;
                break;
            case ConsoleKey.Enter:
                Console.WriteLine($"\nEminsiniz ki silmek isdiyirsiniz? {users[SIndex].Username}? (Y/N)");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    users.RemoveAt(SIndex);
                    if (SIndex >= users.Count && SIndex > 0) SIndex--;
                    Console.WriteLine("\nUser silindi");
                    Thread.Sleep(2000);
                }
                break;
            case ConsoleKey.Escape:
                return;
        }
    }
}
void view_users_posts()
{
    Console.Clear();
    Console.WriteLine("===== USERS POSTS =====\n");

    foreach (var user in users)
    {
        Console.WriteLine($"Posts by {user.Username}:");
        foreach (var post in user.posts)
        {
            post.Display();
        }
        Console.WriteLine("-----------------------------");
    }
    Console.WriteLine("\nPress any button to exit");
    Console.ReadKey();
}
List<Post> loadPosts() {
    List<Post> newPosts = new List<Post>();
    if(users.Count == 1) {
        return newPosts;
    } 
    else {
        foreach(var user in users) {
            if(user.posts.Count != 0) {
            if(user.Username != LoggedUser?.Username) {
            foreach(var post in user.posts) {
                newPosts.Add(post);
                }
            }
            }
        }
    }
    return newPosts; 
}
void menu_user() {
    menu_user_starting:
    Console.Clear();
    Console.WriteLine("=====HOME PAGE=====\n\n");
    Console.WriteLine("[E] => EXIT\n[P] => My Profile\n[M] => My Posts\n[N] => Notifications");
    List<Post> posts = new List<Post>();
    posts = loadPosts();
    int count_ = 0;
    if(posts.Count == 0) {
        Console.WriteLine("There are no posts by other users");
    } 
    else {
        count_ = 0;
        foreach(var post in posts) {
                count_+=1;
                Console.WriteLine("#"+count_);
                post.DisplayShort();
                Console.WriteLine("\n");
        }
        Console.WriteLine("\nTo view the post enter its number");
    }
    line_user_meun_user:
    string ? user_input = Console.ReadLine();
    if(user_input == "P" || user_input == "p") {
        Console.WriteLine(user_input);
        my_profile();
        Console.Clear();
        goto menu_user_starting;
    } else if(user_input == "M" || user_input == "m") {
        my_posts();
        Console.Clear();
        goto menu_user_starting;
    } else if(user_input == "N" || user_input == "n") {
        my_notifications(LoggedUser);
        Console.Clear();
        goto menu_user_starting;
    } else if(user_input == "e" || user_input == "E") {
        return;
    }
    else {
        if(int.TryParse(user_input,out _) == true) {
            if(count_ >= Convert.ToInt32(user_input) && 0 < Convert.ToInt32(user_input)) {
                DisplayPost(posts[Convert.ToInt32(user_input)-1]);
                Console.Clear();
                goto menu_user_starting;
            } else {
                Console.WriteLine("Zehmet olmasa postun nomresini duzgun daxil edin: ");
                goto line_user_meun_user;
            }
        } else {
            Console.WriteLine("Zehmet olmasa duzgun daxil edin: ");
            goto line_user_meun_user;
        }
    }
}
void DisplayPost(Post post) {
    MailSender mail_view = new("smtp.gmail.com",587,"rideparkuber@gmail.com","ajbbjkamilfrcbau");
    Notification _view_noti = new($"@{LoggedUser.Username}({LoggedUser.Name + " " + LoggedUser.Surname}) adli istifadeci {post.guid} id-li post-a baxis kecirdi",DateTime.Now,LoggedUser);
    mail_view.SendMail(admins[0].Email,"View",$"@{LoggedUser.Username}({LoggedUser.Name + " " + LoggedUser.Surname}) adli istifadeci {post.guid} id-li post-a baxis kecirdi");

    admins[0].notifications.Add(_view_noti);
    post.FromUser.notifications.Add(_view_noti);

    post.ViewCount+=1;
    Console.Clear();
    post.Display();

    postBackLine:
    if(LoggedUser.likes.Contains(post.guid.ToString()) != true) {
    Console.WriteLine("\n [L] => LIKE\n[ESC] => GO BACK");
    } else Console.WriteLine("\n [L] => UNLIKE\n[ESC] => GO BACK");
    ConsoleKeyInfo key = Console.ReadKey();
    if(key.Key == ConsoleKey.Escape) {
        return;
    } 
    else if(key.Key == ConsoleKey.L) {
        if(LoggedUser.likes.Contains(post.guid.ToString()) != true) {
            MailSender mail_like = new("smtp.gmail.com",587,"rideparkuber@gmail.com","ajbbjkamilfrcbau");
            Notification send_ = new($"@{LoggedUser.Username}({LoggedUser.Name + " " + LoggedUser.Surname}) adli istifadeci {post.guid} id-li post-u like eledi",DateTime.Now,LoggedUser);
            mail_like.SendMail(admins[0].Email,"Like",$"@{LoggedUser.Username}({LoggedUser.Name + " " + LoggedUser.Surname}) adli istifadeci {post.guid} id-li post-a like eledi");

            admins[0].notifications.Add(send_);
            post.FromUser.notifications.Add(send_);

            post.LikeCount+=1;
            LoggedUser.likes.Add(post.guid.ToString());
        } else {
            MailSender mail_unlike = new("smtp.gmail.com",587,"rideparkuber@gmail.com","ajbbjkamilfrcbau");
            mail_unlike.SendMail(admins[0].Email,"Unlike",$"@{LoggedUser.Username}({LoggedUser.Name + " " + LoggedUser.Surname}) adli istifadeci {post.guid} id-li post-a unlike eledi");
            Notification send_ = new($"@{LoggedUser.Username}({LoggedUser.Name + " " + LoggedUser.Surname}) adli istifadeci {post.guid} id-li post-u unlike eledi",DateTime.Now,LoggedUser);

            admins[0].notifications.Add(send_);
            post.FromUser.notifications.Add(send_);

            post.LikeCount-=1;
            LoggedUser.likes.Remove(post.guid.ToString());
        }
    }
    else {
        goto postBackLine;
    }
}
void my_notifications(Human human)
{
    if (human == null)
    {
        return;
    }
    int SIndex = 0;
    while (true)
    {
        Console.Clear();
        Console.WriteLine("===== MY NOTIFICATIONS =====\n");
        if(human.notifications.Count > 0) {
        for (int i = 0; i < human.notifications.Count; i++)
        {
            if (i == SIndex)
            {
                Console.WriteLine($"> {human.notifications[i].Text}");
            }
            else
            {
                Console.WriteLine($"  {human.notifications[i].Text}");
            }
        }
        } else {
        Console.WriteLine("No Notifcations");
        }
        Console.WriteLine("\n[ENTER] => Delete\n[ESC] => Exit");
        ConsoleKeyInfo key = Console.ReadKey();
        if(SIndex < human.notifications.Count) {
        switch (key.Key)
        {
            case ConsoleKey.UpArrow:
                if (SIndex > 0) SIndex--;
                break;

            case ConsoleKey.DownArrow:
                if (SIndex < human.notifications.Count - 1) SIndex++;
                break;

            case ConsoleKey.Enter:
                human.notifications.RemoveAt(SIndex);
                if (SIndex >= human.notifications.Count && SIndex > 0) SIndex--;
                break;

            case ConsoleKey.Escape:
                return;
        }
     } else {
        if(key.Key == ConsoleKey.Escape)
            return;
     }
    }
}

menu_start();
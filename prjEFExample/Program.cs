using prjEFExample.Model;

namespace prjEFExample
{
    internal class Program
    {
        static RwanvigdbContext db = new RwanvigdbContext();
        static void Main(string[] args)
        {
            //TblUser newUser = new TblUser();
            //newUser.Password = "1234";
            //newUser.Username = "Josh";
            //db.TblUsers.Add(newUser);
            //db.SaveChanges();
            List<TblUser> userData = db.TblUsers.ToList();
            foreach (var arg in userData)
            {
                Console.WriteLine("username :"+arg.Username+ " Password: "+
                    arg.Password);
            }
            //TblContact Contact = new TblContact();
            //Contact.PhoneNumber = "1234567654";
            //Contact.FirstName = "R";
            //Contact.LastName = "Bob";
            //Contact.EmailAddress = "bob@gmail.com";
            //Contact.Username = "Josh";
            //db.TblContacts.Add(Contact);
            //db.SaveChanges();

            List<TblContact> con = db.TblContacts.ToList();
            foreach (var arg in con)
            {
                Console.WriteLine("First Name :" + arg.FirstName +
                    " Number: " + arg.PhoneNumber + " User name Password"
                    + arg.UsernameNavigation.Username 
                    +" "+ arg.UsernameNavigation.Password);
            }
            //Update
            TblContact c = (from x in db.TblContacts
                            where x.PersonId == 1
                            select x).First();
            c.PhoneNumber = "123456789";
            c.FirstName = "Reece";
            c.LastName = "Wanvig";
            c.EmailAddress = "Reece@gmail.com";
            db.SaveChanges();

        }
    }
}

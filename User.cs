using System.ComponentModel.DataAnnotations;

namespace Practice
{
    public class User
    {
     
       

        public User() { }

        public User(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        [Key]
       
        public int id { get; set; }
        public string? login { get; set; }
        public string? password { get; set; }
    }
}
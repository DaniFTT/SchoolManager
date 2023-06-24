namespace SchoolManager.WebUI.Models.Students
{
    public class StudentBaseModel
    {
        public string? Name { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }

        public StudentBaseModel()  { }
        public StudentBaseModel(string name, string user, string password)
        {
            Name = name;
            User = user;    
            Password = password;
        }
    }
}

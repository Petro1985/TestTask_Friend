namespace TestTask_Friend.APIStruct;

public class User
{
    public int id { get; set; }
    public string phone { get; set; }
    public string login { get; set; }
    public string password { get; set; } // for records, I don't support openly saving password in database
    public string name { get; set; }
    
    public DateTime birth { get; set; }
    public string tg { get; set; }
    public string email { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace TestTask_Friend.APIStruct;

public class UserRequest
{
    public string Phone { get; set; }
    public string Login { get; set; }
    public string Password { get; set; } // for records, I don't support openly saving password in database
    public string Name { get; set; }
    
    public DateTime Birth { get; set; }
    
    public string? Tg { get; set; }
    public string? Email { get; set; }
}
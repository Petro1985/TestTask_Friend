namespace TestTask_Friend.DAL.Entities;

public class UserEntity
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string Login { get; set; }
    public string Password { get; set; } // for records, I don't support openly saving password in database
    public string Name { get; set; }
    public DateOnly Birth { get; set; }
    public string? Tg { get; set; }
    public string? Email { get; set; }
}
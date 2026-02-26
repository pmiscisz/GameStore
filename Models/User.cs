namespace GameStore.Models
{
    public class User
    {
        public enum Permission
        {
            Admin = 0,
            User = 1
        }
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Permission UserPermission { get; set; }
    }
}

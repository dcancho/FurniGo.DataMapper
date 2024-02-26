namespace FurniGo.DataMapper.Shared.Resources
{
    /// <summary>
    /// DTO for saving a user resource.
    /// </summary>
    public class SaveUserResource
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}

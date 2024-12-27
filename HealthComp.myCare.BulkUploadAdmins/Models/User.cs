namespace HealthComp.myCare.BulkUploadAdmins.Models;

public class User
{
    public bool Active { get; set; }
    public string Email { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public IList<GroupRole> GroupRoles { get; set; } = [];
    public int RoleId { get; set; }
}
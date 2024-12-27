namespace HealthComp.myCare.BulkUploadAdmins.Models;

public class GroupRole
{
    public bool CanAccessAllGroups { get; set; }
    public string GroupName { get; set; } = default!;
    public string GroupNumber { get; set; } = default!;
    public int Id { get; set; }
    public int RoleId { get; set; }
}
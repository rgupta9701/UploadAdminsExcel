using HealthComp.myCare.BulkUploadAdmins.Models;

namespace HealthComp.myCare.BulkUploadAdmins.Abstractions;

public interface IRegisterAdminService
{
    Task RegisterAdmin(IList<User> admins);
}
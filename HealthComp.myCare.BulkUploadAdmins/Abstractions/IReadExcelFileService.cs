using HealthComp.myCare.BulkUploadAdmins.Models;

namespace HealthComp.myCare.BulkUploadAdmins.Abstractions;

public interface IReadExcelFileService
{
    IList<User> ReadExcelFile(string filePath);
}
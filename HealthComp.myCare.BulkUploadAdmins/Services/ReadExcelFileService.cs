using ClosedXML.Excel;
using HealthComp.myCare.BulkUploadAdmins.Abstractions;
using HealthComp.myCare.BulkUploadAdmins.Models;
using Microsoft.Extensions.Logging;

namespace HealthComp.myCare.BulkUploadAdmins.Services;

public class ReadExcelFileService: IReadExcelFileService
{
    private readonly ILogger<ReadExcelFileService> _logger;
    public ReadExcelFileService(ILogger<ReadExcelFileService> logger)
    {
        _logger = logger;
    }
    public IList<User> ReadExcelFile(string filePath)
    {
        var dataListUsers = new List<User>();

        try
        {
            using var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet(1);
            var range = worksheet.RangeUsed();
            
            //fetch the initial row to read the headers
            var headerRow = range?.Rows().First();

            _logger.LogDebug("Reading Excel File Started");

            foreach (var row in range!.Rows())
            {
                if (row.RowNumber() == 1) continue;
                var user = new User
                {
                    FirstName = row.Cell(2).GetValue<string>(), // Column A
                    LastName = row.Cell(3).GetValue<string>(), // Column B
                    Email = row.Cell(4).GetValue<string>(), // Column C,
                    UserName = row.Cell(4).GetValue<string>().Split('@')?.Length > 0
                        ? row.Cell(4).GetValue<string>().Split('@')[0]
                        : string.Empty,
                    Active = true,
                    GroupRoles = 
                    [
                        new GroupRole() 
                        {
                            CanAccessAllGroups = true,
                            GroupName = "1 Year Term Life",
                            GroupNumber = "NL00031",
                            Id = 2,
                            RoleId = 13
                        }
                    ],
                    Password = "PersonifyMyCareLogin@02025",
                    RoleId = 13,
                    Phone = "",
                };

                dataListUsers.Add(user);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error in ReadExcelFileService: " + "\n" + ex.Message + "\n" + ex.Data);
        }

        return dataListUsers;
    }
}
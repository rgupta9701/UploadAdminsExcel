using HealthComp.myCare.BulkUploadAdmins.Abstractions;
using HealthComp.myCare.BulkUploadAdmins.Constants;
using HealthComp.myCare.BulkUploadAdmins.Services;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("/Users/ritwik.gupta/Desktop/myCare/ExcelUpload/logs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    var serviceProvider = new ServiceCollection()
        .AddLogging(configure => configure.AddSerilog())
        .AddSingleton<IReadExcelFileService, ReadExcelFileService>()
        .AddScoped<IRegisterAdminService, RegisterAdminService>()
        .BuildServiceProvider();

    var excelReaderService = serviceProvider.GetService<IReadExcelFileService>();
    var registerAdminService = serviceProvider.GetService<IRegisterAdminService>();
    
    const string excelPath = Constants.SourceExcelFilePath;
    var result = excelReaderService?.ReadExcelFile(excelPath);
    
    //Call API to check for duplicate users
    //TO DO
    
    //Make API call to add users/admins
    await registerAdminService?.RegisterAdmin(result);
    
}
catch (Exception ex)
{
    throw new Exception();
}



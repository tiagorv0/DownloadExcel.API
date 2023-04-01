using DownloadExcel.API.Models;

namespace DownloadExcel.API.Services
{
    public class FileService : IFileService
    {

        public FileResponse Download(FileExtensionsEnum ext)
        {
            var auditList = new List<Audit>()
            {
                new Audit(1, "Tiago", "GW", "Admin", "948.984.904.5", DateTime.Now, "Login"),
                new Audit(2, "Joao", "RLopes", "Manager", "948.984.904.5", DateTime.Now, "Logout"),
                new Audit(3, "Pedro", null, "Admin", "948.984.904.5", DateTime.Now, "Manage System")
            };
            var _fileCreatorService = new FileCreatorService<Audit>();

            var stream = _fileCreatorService.XlsxCreator(auditList);

            return new FileResponse
            {
                Stream = stream,
                Name = $"Audit.{ext.ToString()}",
                ContentType = $"application/{(ext == FileExtensionsEnum.Xlsx ? "xlsx" : "csv")}"
            };
        }
    }
}

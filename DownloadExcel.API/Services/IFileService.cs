using DownloadExcel.API.Models;

namespace DownloadExcel.API.Services
{
    public interface IFileService
    {
        FileResponse Download(FileExtensionsEnum ext);
    }
}

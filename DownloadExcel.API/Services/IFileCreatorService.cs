namespace DownloadExcel.API.Services
{
    public interface IFileCreatorService<T> where T : class
    {
        MemoryStream XlsxCreator(IEnumerable<T> data);
    }
}

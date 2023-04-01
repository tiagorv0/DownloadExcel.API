namespace DownloadExcel.API.Models
{
    public class FileResponse
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public Stream Stream { get; set; }
    }
}

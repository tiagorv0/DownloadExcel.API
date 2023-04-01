using DownloadExcel.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DownloadExcel.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DownloadExcelController : ControllerBase
    {
        [HttpGet("download")]
        public IActionResult Download([FromServices] IFileService fileService)
        {
            var logo = fileService.Download(Models.FileExtensionsEnum.Xlsx);
            return File(logo.Stream, logo.ContentType, logo.Name);
        }
    }
}
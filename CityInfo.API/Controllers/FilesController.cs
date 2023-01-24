using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {


        public readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(ILogger<FilesController> logger, FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        public ILogger<FilesController> _logger { get; }

        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            var pathFile = "files/diablo.jpg";


            if (!System.IO.File.Exists(pathFile))
            {
                _logger.LogWarning($"The specified  file path {pathFile} is invalid");
                return NotFound();
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(pathFile, out var contenttype))
            { contenttype = "application-octet-stream"; }
            var bytes = System.IO.File.ReadAllBytes(pathFile);
            return File(bytes, contenttype, pathFile);
        }

    }
}
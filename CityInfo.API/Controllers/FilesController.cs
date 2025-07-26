using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CharacterInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // Constucter and set fileExtensionContentTypeProvider
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
                ?? throw new System.ArgumentNullException(
                    nameof(fileExtensionContentTypeProvider));
        }


        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            /*
             * FileContentResult -> It arrives from the abstract FileResult based class
             * FileStreamResult -> This accepts a stream to read from an the contentType
             * PhysicalFileResult -> This accepts a physical file path and the contentType
             * VirtualFileResult -> This accepts a virtual file path and the contentType
             */

            // File() method is defined on the ControllerBase and it acts as a wrapper
            // around the aforementioned FileResult subclasses
            // (FileContentResult, FileStreamResult, PhysicalFileResult, VirtualFileResult, etc).

            // For demo purposes, we will hardcode the path.
            // In a real scenario - we would use `fileId` to fetch te correct file path
            var pathToFile = "doom.pdf"; // because file is in the root of the project, we don't need to specify the full path

            // check whether the file exists
            if (!System.IO.File.Exists(pathToFile))
                return NotFound();

            // using constructor
            if (!_fileExtensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentTyoe))
            { 
                contentTyoe = "application/octet-stream"; 
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentTyoe, Path.GetFileName(pathToFile));
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace storage_api.Controllers
{
    // The api controller that will handle all the requests
    [ApiController]
    [Route("")]
    public class PdfFileAPI : ControllerBase
    {
        // this is the name of the folder where all pdf files will be stored
        const string folderName = "Storage";
        /**
         * This is the upload endpoint
         * Receive a file using Form-data
         * The received file will be saved under the "folderName" folder
         */
        [HttpPost("upload-pdf")]
        public async Task<IActionResult> UploadPdf(IFormFile file)
        {
            try
            {
                // check if the file not empty
                if (file.Length > 0)
                {
                    // get the storage folder
                    string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, folderName));
                    //check if the directory exists
                    if (!Directory.Exists(path))
                    {
                        // if not exists, create one
                        Directory.CreateDirectory(path);
                    }
                    // copy the received file to the destination folder
                    using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return Ok();
                }
                else
                {
                    // in case of empty file
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Upload Failed", ex);
            }

        }

        /**
         * This endpoint will handle the file retrieval
         * This require the pdf file name to be passed 
         * as a parameter like this: get-pdf/?filename=file.pdf
         * where the pdf filename is "file.pdf"
         */
        [HttpGet("get-pdf")]
        public IActionResult GetPdf(String filename)
        {
            // get the full path of the pdf storage folder
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, folderName));
            // get the full path of the pdf file
            string filePath = Path.Combine(path, filename);
            // construct a file Info object to verify if the file exists
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                // return the file as a Physical file with the content type of application/pdf
                return PhysicalFile(filePath, "application/pdf", filename);
            }
            // in case of the file not exist, return not found error with a message
            return NotFound(new
            {
                Message = "File Not found"
            });
        }

        /**
         * This endpoint handle deleting a file
         * This require the pdf file name to be passed 
         * as a parameter like this: get-pdf/?filename=file.pdf
         * where the pdf filename is "file.pdf"
         */
        [HttpDelete("delete-pdf")]
        public IActionResult DeletePdf(String filename)
        {
            // get the full path of the pdf storage folder
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, folderName));
            // get the full path of the pdf file
            string filePath = Path.Combine(path, filename);
            // construct a file Info object to verify if the file exists
            FileInfo file = new FileInfo(filePath);
            if(file.Exists)
            {
                // delete the file: this require high privildge to run it 
                file.Delete();
                // return a success message
                return Ok(new
                {
                    Message= $"File '{filename}' deleted successfully"
                });
            }
            // in case of the file to delete not exist, return not found error with a message
            return NotFound(new {
                Message="File Not found"
            });
        }

        /**
         * This endpoint will list all the files in the directory
         * will return a list of file names
         */
        [HttpGet("list-files")]
        public IEnumerable<string> ListFiles()
        {
            // get the full path of the pdf storage folder
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, folderName));
            // get the filenames from the path
            IEnumerable<string> allfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Select(fullPath => new FileInfo(fullPath).Name);
            return allfiles;
        }
    }
}
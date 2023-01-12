using Microsoft.AspNetCore.Http;

namespace evertec.Transversal.Utils
{
    public class FileUploadAPI
    {
        public IFormFile files { get; set; }
        public string FileBase64 { get; set; }
    }
}

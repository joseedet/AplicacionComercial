using AplicacionComercial.Web.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using PhotoSauce.MagicScaler;

using System;
using System.IO;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.FileManager

{
    public class FilesManager : IFileManager
    {
        private string _imagePath;
        public FilesManager(IConfiguration config)
        {
            _imagePath = config["Path:Images"];
        }
        public FileStream imageStream(string image)
        {
            return new FileStream(Path.Combine(_imagePath, image), FileMode.Open, FileAccess.Read);
        }
        public bool RemoveImage(string image)
        {
            try
            {
                var file = Path.Combine(_imagePath, image);
                if (File.Exists(file))
                    File.Delete(file);
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }
        public Task<string> SaveImage(IFormFile image)
        {
            var save_path = Path.Combine(_imagePath);
            try
            {
                if (!Directory.Exists(save_path))
                {
                    Directory.CreateDirectory(save_path);
                }
                if(image==null)
                {
                    var file=string.Empty ;

                    return Task.FromResult(file);
                }
                var mime = image.FileName.Substring(image.FileName.LastIndexOf("."));


                var fileName = $"img_{DateTime.Now.ToString("dd-MM-yyy-HH-mm-ss")}{mime}";

                //Guid fileName =gguid+mime;
                //var file = guid.ToString() + mime;
                using (var filestream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
                {
                    
                    MagicImageProcessor.ProcessImage(image.OpenReadStream(), filestream, imageoptions());
                    //await image.CopyToAsync(filestream);
                }

                return Task.FromResult(fileName);
            }

            catch (IOException s)
            {

                return Task.FromResult(s.Message.ToString());

            }
            catch (NullReferenceException r)
            {
                return Task.FromResult(r.Message.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return Task.FromResult("Error-");
            }
           
        }
        private ProcessImageSettings imageoptions() => new ProcessImageSettings
        {
            Width = 500,
            Height = 500,
            ResizeMode = CropScaleMode.Crop,
            SaveFormat = FileFormat.Auto,
            JpegQuality = 100,
            JpegSubsampleMode = ChromaSubsampleMode.Subsample420
        };
    }
}
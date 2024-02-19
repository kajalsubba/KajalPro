using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.DbHandler;

namespace Tea.Api.Data.Common
{
    public static class ClsUploadFile
    {
       
        static readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();

       
        public static async Task<string> UploadFile(string? name, IFormFile? Images)
        {
            try
            {
             
                //// Getting Image
                ///
                var CompanyPath = config.GetConnectionString("CompanyLogoPath");
                var image = Images;

               // string CompanyPath = "D:\\Tea\\CompanyLogo\\";
                string extension = Path.GetExtension(image.FileName);

                string FileName = "Logo" + name + extension;

                var folderName = CompanyPath + name; //Path.Combine("Upload", name);
            
                var filePath = Path.Combine(folderName, FileName);

              
                //Check if directory exist
                if (!System.IO.Directory.Exists(folderName))
                {
                    System.IO.Directory.CreateDirectory(folderName); //Create directory if it doesn't exist
                }

                // Saving Image on Server
                if (image.Length > 0)
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }
                }

                return "http://72.167.37.70/TeaFiles/CompanyLogo/"+ name+"/"+ FileName;

               // return new ReturnData() { Id = 1, message = fileName + " is uploaded successfully." };
            }
            catch (Exception )
            {
                 throw ;
              //  return new ReturnData() { Id = 0, message = ex.Message.ToString() };
            }
        }

    }
}

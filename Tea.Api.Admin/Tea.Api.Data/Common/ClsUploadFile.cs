using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.DbHandler;

namespace Tea.Api.Data.Common
{
    public static class ClsUploadFile
    {

        //static readonly IConfiguration config = new ConfigurationBuilder()
        //           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();


        public static async Task<string> UploadFile(string? pathToSave,string? name, IFormFile? Images,string? type,string? DirName)
        {
            try
            {

                //// Getting Image
                ///
                var FilePath = pathToSave;//config.GetConnectionString("CompanyLogoPath");
                var image = Images;


                string[] sentences = FilePath.Split('\\');

        
                string extension = Path.GetExtension(image.FileName);
                string FileName = string.Empty;
                if (type == "Logo")
                { 
                FileName = "Logo" + name + extension;
                 }
                else 
                {
                    FileName = type + extension;
                }
                var folderName = FilePath + name; //Path.Combine("Upload", name);
            
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

                return "https://glsportals.com/" + DirName+"/" + sentences[4]+"/" + name+"/"+ FileName;

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

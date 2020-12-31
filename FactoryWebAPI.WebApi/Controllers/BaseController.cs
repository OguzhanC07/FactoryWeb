using FactoryWebAPI.WebApi.Enums;
using FactoryWebAPI.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FactoryWebAPI.WebApi.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public async Task<UploadModel> UploadFileAsync(IFormFile file, string folder)
        {
            UploadModel uploadModel = new UploadModel();
            
            if (file != null)
            {
                bool acceptFile = false;
                string[] acceptedFileTypes = new string[2];
                acceptedFileTypes[0] = "image/jpeg";
                acceptedFileTypes[1] = "image/png";
                string fileContentType = file.ContentType;
                for (int i = 0; i < acceptedFileTypes.Length; i++)
                {
                    if (fileContentType == acceptedFileTypes[i])
                    {
                        acceptFile = true;
                        break;
                    }
                }

                if (acceptFile==false)
                {
                    uploadModel.ErrorMessage = "Desteklenmeyen dosya türü";
                    uploadModel.UploadState = UploadState.Error;
                    return uploadModel;
                }
                else
                {
                    if (file.Length<= 1048576)
                    {
                        var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{folder}/" + newName);
                        var stream = new FileStream(path, FileMode.Create);
                        await file.CopyToAsync(stream);

                        uploadModel.NewName = newName;
                        uploadModel.UploadState = UploadState.Success;
                        return uploadModel;
                    }
                    else
                    {
                        uploadModel.ErrorMessage = "Desteklenmeyen dosya türü";
                        uploadModel.UploadState = UploadState.Error;
                        return uploadModel;
                    }
                }
            }
            uploadModel.ErrorMessage = "Dosya yüklenmedi";
            uploadModel.UploadState = UploadState.NotExist;
            return uploadModel;
        }
    }
}
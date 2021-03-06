﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using demo2.Domain.AggregatesModel.ImageStore;
using demo2.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo2.UI.Web.Controllers
{
    public class CameraController : Controller
    {

        private readonly IImageRepository _imageRepository;
        private readonly IHostingEnvironment _environment;

        public CameraController(IHostingEnvironment hostingEnvironment, IImageRepository imageRepository)
        {
            _environment = hostingEnvironment;
            _imageRepository =  imageRepository;
        }
        public IActionResult Index()
        {
            var imageStore_ = new ImageStore()
            {
                CreateDate = DateTime.Now,
                ImageBase64String = "ddd" ///imageUrl

            };
            _imageRepository.Add(imageStore_);

            return View();
        }

        [HttpPost]
        public IActionResult Capture(string name)
        {
            var files = HttpContext.Request.Form.Files;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Getting Filename  
                        var fileName = file.FileName;
                        // Unique filename "Guid"  
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        // Getting Extension  
                        var fileExtension = Path.GetExtension(fileName);
                        // Concating filename + fileExtension (unique filename)  
                        var newFileName = string.Concat(myUniqueFileName, fileExtension);
                        //  Generating Path to store photo   
                        var filepath = Path.Combine(_environment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";

                        if (!string.IsNullOrEmpty(filepath))
                        {
                            // Storing Image in Folder  
                            StoreInFolder(file, filepath);
                        }

                        var imageBytes = System.IO.File.ReadAllBytes(filepath);
                        if (imageBytes != null)
                        {
                            // Storing Image in Folder  
                            StoreInDatabase(imageBytes);
                        }

                    }
                }
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        /// <summary>
        /// Saving captured image into Folder.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        /// <summary>
        /// Saving captured image into database.
        /// </summary>
        /// <param name="imageBytes"></param>
        private void StoreInDatabase(byte[] imageBytes)
        {
            try
            {
                if (imageBytes != null)
                {
                    string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    string imageUrl = string.Concat("data:image/jpg;base64,", base64String);

                    //var imageStore_ = new ImageStore()
                    //{
                    //    CreateDate = DateTime.Now,
                    //    ImageBase64String = "ddd" ///imageUrl

                    //};
                    //_imageRepository.Add(imageStore_);
                    //_context.ImageStore.Add(imageStore_);
                    //_context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
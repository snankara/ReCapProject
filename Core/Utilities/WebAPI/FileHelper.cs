﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.WebAPI
{
    public class FileHelper
    {
        public static string AddAsync(IFormFile file)
        {
            var sourcePath = Path.GetTempFileName();
            if (file != null)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var destinationPath = newPath(file);
                File.Move(sourcePath, destinationPath);

                return destinationPath;
            }

            var defaultImage = defaultPath().ToString();

            return defaultImage;
        }

        private static object defaultPath()
        {
            string path = Path.Combine(Environment.CurrentDirectory + @"/wwwroot/Images/default.jpg");
            return path;
        }

        public static string UpdateAsync(string sourcePath, IFormFile file)
        {
            var destinationPath = newPath(file);
            if (sourcePath == defaultPath().ToString())
            {
                using (var stream = new FileStream(destinationPath, FileMode.CreateNew))
                {
                    file.CopyTo(stream);
                }
            }
            else
            {
                using (var stream = new FileStream(destinationPath, FileMode.CreateNew))
                {
                    file.CopyTo(stream);
                }

                File.Delete(sourcePath);
            }

            return destinationPath;
        }

        public static string DeleteAsync(string sourcePath)
        {
            if (sourcePath != null)
            {
                File.Delete(sourcePath);
            }

            return null;
        }

        public static string newPath(IFormFile file)
        {
            FileInfo fileName = new FileInfo(file.FileName);
            var fileExtension = fileName.Extension;
            var uniqueFileName = Guid.NewGuid().ToString() + fileExtension;
            string path = Path.Combine(Environment.CurrentDirectory + @"/wwwroot/Images");
            string result = $@"{path}\{uniqueFileName}";

            return result;
        }
    }
}

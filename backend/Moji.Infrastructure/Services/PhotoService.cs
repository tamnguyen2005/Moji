using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Moji.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Infrastructure.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        public PhotoService(Cloudinary cloudinary)
        {
            _cloudinary= cloudinary;
        }
        public async Task<string> Upload(IFormFile images)
        {
            using var stream = images.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(images.FileName, stream)
            };

            var result = await _cloudinary.UploadAsync(uploadParams);

            return result.SecureUrl.ToString();
        }
    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moji.Application.Interfaces
{
    public interface IPhotoService
    {
        Task<string> Upload(IFormFile images);
    }
}

using System;

namespace Training.Api.Models;

public class UploadPhotoRequestDto
{
    public IFormFile? Photo { get; set; }
}

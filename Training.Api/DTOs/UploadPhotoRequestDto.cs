using System;

namespace Training.Api.DTOs;

public class UploadPhotoRequestDto
{
    public IFormFile? Photo { get; set; }
}

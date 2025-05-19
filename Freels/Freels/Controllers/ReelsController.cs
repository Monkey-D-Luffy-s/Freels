using Freels.data;
using Freels.Modals.DTO;
using Freels.Modals.Reels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Freels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReelsController : ControllerBase
    {
        private readonly IWebHostEnvironment environment;
        private readonly ReelsDbContext reelsContext;
        private readonly UserManager<IdentityUser> userManager;
        public ReelsController(ReelsDbContext _reelsContext, UserManager<IdentityUser> _userManager, IWebHostEnvironment _environment)
        {
            reelsContext = _reelsContext;
            userManager = _userManager;
            environment = _environment;
        }

        [HttpPost]
        [Route("UploadShort")]
        public async Task<IActionResult> Uploadshort([FromBody] ReelsModalDTO obj )
        {
            if (obj.file != null && obj.file.Length > 0)
            {
                // Path to the uploads folder inside wwwroot
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "videos");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var fineName = Path.GetFileName(obj.file.FileName);
                var extension = Path.GetExtension(obj.file.FileName).ToLower();
                var newFileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadsFolder, newFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await obj.file.CopyToAsync(stream);
                }
                ReelsModal reelsModal = new ReelsModal()
                {
                    Id = Guid.NewGuid(),
                    VideoName = obj.VideoName,
                    VideoDescription = obj.VideoDescription,
                    UserId = obj.UserId,
                    PostedOn = DateTime.UtcNow,
                    Likes = 0,
                    Dislikes = 0,
                    VideoURL = newFileName,
                };
                await reelsContext.reelsModals.AddAsync(reelsModal);
                await reelsContext.SaveChangesAsync();
                return Ok("Success");

            }
            return Ok("Success");
        }
    }
}

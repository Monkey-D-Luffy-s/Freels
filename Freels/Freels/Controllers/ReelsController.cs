using Freels.data;
using Freels.Modals.DTO;
using Freels.Modals.Reels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Uploadshort([FromForm] IFormFile file, [FromForm] string Title, [FromForm] string userID)
        {
            if (file != null && file.Length > 0)
            {
                // Path to the uploads folder inside wwwroot
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "videos");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var fineName = Path.GetFileName(file.FileName);
                var extension = Path.GetExtension(fineName).ToLower();
                var newFileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(uploadsFolder, newFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                ReelsModal reelsModal = new ReelsModal()
                {
                    Id = Guid.NewGuid(),
                    VideoName = Title,
                    VideoDescription = fineName,
                    UserId = Guid.Parse(userID),
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

        [HttpGet]
        [Route("GetThree")]
        public async Task<IActionResult> ReturnVideos()
        {

            List<ReelsModal> reelsModals = await reelsContext.reelsModals
        .OrderBy(v => Guid.NewGuid()) // Random ordering
        .Take(3)                      // Pick top 3
        .Select(v => new ReelsModal
        {
            Id = v.Id,
            VideoName = v.VideoName,
            VideoDescription = v.VideoDescription,
            PostedOn = v.PostedOn,
            UserId=v.UserId,
            Likes = v.Likes,
            Dislikes=v.Dislikes,
            VideoURL = Url.Content($"~/uploads/videos/{v.VideoURL}")
        })
        .ToListAsync();

            List<ReelsModalDTO> reelsModalDTO = new List<ReelsModalDTO>();

            foreach(var reel in reelsModals)
            {
                ReelsModalDTO temp = new ReelsModalDTO()
                {
                    Id = reel.Id,
                    VideoName = reel.VideoName,
                    VideoDescription = reel.VideoDescription,
                    UserId = reel.UserId,
                    PostedOn = reel.PostedOn,
                    Likes = reel.Likes,
                    Dislikes = reel.Dislikes,
                    VideoURL = reel.VideoURL,
                    commentCount = Convert.ToInt32(await reelsContext.commentsModals.CountAsync(r => r.UserId == reel.UserId)),
                };
                
                reelsModalDTO.Add(temp);
            }


            return Ok(reelsModalDTO);
        }

        [HttpGet]
        [Route("GetOne")]
        public async Task<IActionResult> ReturnVideo()
        {

            List<ReelsModal> reelsModals = await reelsContext.reelsModals
        .OrderBy(v => Guid.NewGuid())
        .Take(1)
        .Select(v => new ReelsModal
        {
            Id = v.Id,
            VideoName = v.VideoName,
            VideoDescription = v.VideoDescription,
            PostedOn = v.PostedOn,
            UserId = v.UserId,
            Likes = v.Likes,
            Dislikes = v.Dislikes,
            VideoURL = Url.Content($"~/uploads/videos/{v.VideoURL}")
        })
        .ToListAsync();


            return Ok(reelsModals);
        }
    }
}

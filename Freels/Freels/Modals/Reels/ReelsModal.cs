using System.ComponentModel.DataAnnotations;

namespace Freels.Modals.Reels
{
    public class ReelsModal
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string VideoName { get; set; }

        [Required]
        public string VideoDescription { get; set; }
        [Required]

        public DateTime PostedOn { get; set; }
        [Required]

        public Guid UserId { get; set; }
        [Required]

        public int Likes { get; set; }
        [Required]
        public int Dislikes { get; set; }
        [Required]

        public string VideoURL { get; set; }

    }
}

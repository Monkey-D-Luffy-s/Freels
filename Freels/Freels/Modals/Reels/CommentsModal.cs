using System.ComponentModel.DataAnnotations;

namespace Freels.Modals.Reels
{
    public class CommentsModal
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CommenterId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string CommentMsg { get; set; }
        [Required]
        public DateTime CommentedOn { get; set; }
        public int CommentLikes { get; set; }
    }
}

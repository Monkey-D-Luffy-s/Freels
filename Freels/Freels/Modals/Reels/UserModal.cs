namespace Freels.Modals.Reels
{
    public class UserModal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public string[] PostedVideos { get; set; }

        public string[] Friends { get; set; }

        public DateTime DOB { get; set; }
        public string Description { get; set; }
        public string ImgURL { get; set; }

        public string[] Fallowing { get; set; }

    }
}

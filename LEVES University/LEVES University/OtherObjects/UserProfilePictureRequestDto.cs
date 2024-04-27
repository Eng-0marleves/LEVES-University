namespace LEVES_University.OtherObjects
{
    public class UserProfilePictureRequestDto
    {
        public string UserId { get; set; }
        public string ImageName { get; set; }
        public IFormFile Image { get; set; }
    }
}

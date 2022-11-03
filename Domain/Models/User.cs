namespace Domain.Models {
    public class User {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Karma { get; set; }
        public ICollection<SubPage> SubscribedSubs { get; set; }
        public ICollection<Post> LikedPosts { get; set; }
        public ICollection<Post> DislikedPosts { get; set; }
    }
}

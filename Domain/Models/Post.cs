namespace Domain.Models {
    public class Post {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public User Author { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public ICollection<Post> Comments { get; set; }
    }
}

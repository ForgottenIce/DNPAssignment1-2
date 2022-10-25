namespace Domain.Models {
    public class SubPage {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User Owner { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}

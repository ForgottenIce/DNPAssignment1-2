using Domain.Models;
namespace FileData {
    [Obsolete("class should not be in use",true)]
    public class DataContainer {
        public ICollection<User> Users { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<SubPage> SubPages { get; set; }
    }
}

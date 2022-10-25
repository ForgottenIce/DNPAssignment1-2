using System.Text.Json;
using Domain.Models;

namespace FileData {
    public class FileContext {
        private const string _filePath = "data.json";
        private DataContainer? _container;

        public ICollection<Post> Posts {
            get {
                LoadData();
                return _container.Posts;
            }
        }

        public ICollection<SubPage> SubPages {
            get {
                LoadData();
                return _container.SubPages;
            }
        }

        public ICollection<User> Users {
            get {
                LoadData();
                return _container.Users;
            }
        }

        private void LoadData() {
            if (_container != null) return;

            if (!File.Exists(_filePath)) {
                _container = new() {
                    Posts = new List<Post>(),
                    SubPages = new List<SubPage>(),
                    Users = new List<User>()
                };
                return;
            }
            string content = File.ReadAllText(_filePath);
            _container = JsonSerializer.Deserialize<DataContainer>(content);
        }

        public void SaveChanges() {
            string serialized = JsonSerializer.Serialize(_container, new JsonSerializerOptions {
                WriteIndented = true
            });
            File.WriteAllText(_filePath, serialized);
            _container = null;
        }
    }
}

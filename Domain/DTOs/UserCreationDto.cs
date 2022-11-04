using System.Security.Cryptography;
using System.Text;

namespace Domain.DTOs {
    public class UserCreationDto {
        public string Username { get;}
        public string HashedPassword { get;}

        public UserCreationDto(string username, string hashedPassword) {
            Username = username;
            HashedPassword = hashedPassword;
        }
    }
}
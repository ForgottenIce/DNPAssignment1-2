using System.Security.Cryptography;
using System.Text;

namespace Domain.DTOs {
    public class UserCreationDto {
        public string Username { get;}
        public string Password { get;}

        public UserCreationDto(string username, string password) {
            Username = username;
            //Todo Maybe the SHA256 conversion should happen on the blazor client as it is bad practise to send passwords in clear text
            string hash = string.Empty;
            using (SHA256 sha256 = SHA256.Create()) {
                byte[] hashBytes = sha256.ComputeHash(Encoding.Unicode.GetBytes(password));
                foreach (byte b in hashBytes) {
                    hash += $"{b:X2}";
                }
            }
            Password = hash;
        }
    }
}
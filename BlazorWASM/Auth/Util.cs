using System.Security.Cryptography;
using System.Text;

namespace BlazorWASM.Auth;

public static class Util {
    public static string ConvertToSHA256(string input) {
        string hash = string.Empty;
        using (SHA256 sha256 = SHA256.Create()) {
            byte[] hashBytes = sha256.ComputeHash(Encoding.Unicode.GetBytes(input));
            foreach (byte b in hashBytes) {
                hash += $"{b:X2}";
            }
            return hash;
        }
    }
}

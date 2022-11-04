// See https://aka.ms/new-console-template for more information
using shortid;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

//for (int i = 0; i < 100; i++) {
//    string id = ShortId.Generate(new shortid.Configuration.GenerationOptions(true, true, 10));;
//    Console.WriteLine(id);
//}

string username = "hello465132";
string regex = @"[^A-z0-9_-]";
Console.WriteLine(Regex.Matches(username, regex).Any());
username = "hello-465132";
Console.WriteLine(Regex.Matches(username, regex).Any());
username = "hello_465132";
Console.WriteLine(Regex.Matches(username, regex).Any());

username = "hello.465132";
Console.WriteLine(Regex.Matches(username, regex).Any());
username = "hello/465132";
Console.WriteLine(Regex.Matches(username, regex).Any());
username = "hello@465132";
Console.WriteLine(Regex.Matches(username, regex).Any());
username = "hello☺465132";
Console.WriteLine(Regex.Matches(username, regex).Any());
username = "helloß465132";
Console.WriteLine(Regex.Matches(username, regex).Any());
username = "he你好465132";
Console.WriteLine(Regex.Matches(username, regex).Any());
username = "heaæøåpå465132";
Console.WriteLine(Regex.Matches(username, regex).Any());

using (SHA256 sha256 = SHA256.Create()) {
    string hash = string.Empty;
    byte[] hashBytes = sha256.ComputeHash(Encoding.Unicode.GetBytes("test"));
    foreach (byte b in hashBytes) {
        hash += $"{b:X2}";
    }
}

SHA256 test = SHA256.Create();
byte[] bytes = test.ComputeHash(Encoding.Unicode.GetBytes("1234"));

for (int i = 0; i < bytes.Length; i++) {
    Console.Write($"{bytes[i]:X2}");
}
Console.WriteLine();
Console.Read();
// See https://aka.ms/new-console-template for more information
using AppsecurityWithSaltAndHash.AppCode;
using System.Security.Cryptography;

string inputPassword = string.Empty;
AppSecurityUtility appSecurityUtility = AppSecurityUtility.Instance;
Console.Write("\n Enter the Input Password : ");
inputPassword=Console.ReadLine();
string Encryption = appSecurityUtility.HashAlgorithm(inputPassword, 64, SHA256.Create());
Console.WriteLine(Encryption);

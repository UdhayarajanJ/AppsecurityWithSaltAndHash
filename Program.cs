// See https://aka.ms/new-console-template for more information
using AppsecurityWithSaltAndHash.AppCode;
using AppsecurityWithSaltAndHash.Entity;
using System.Security.Cryptography;

string? inputPassword = string.Empty;
int? choice = 0;
AppSecurityUtility appSecurityUtility = AppSecurityUtility.Instance;
Console.WriteLine("\tAppSecurity With Concept Of Hashing Salt Password Protection");
do
{
    Console.Write("\n\nEnter the Password :");
    inputPassword = Console.ReadLine();
    HashAndSalt hashAndSalt256 = appSecurityUtility.HashAlgorithm(inputPassword, 64, SHA256.Create());
    HashAndSalt hashAndSalt512 = appSecurityUtility.HashAlgorithm(inputPassword, 64, SHA512.Create());
    if (hashAndSalt256 != null && hashAndSalt512 != null)
    {
        Console.WriteLine("Salt String With Algorithm [ SHA256 ]\n");
        Console.WriteLine("Salt         [ SHA256]     : {0}", hashAndSalt256.saltString);
        Console.WriteLine("HashWithSalt [ SHA256 ]    : {0}", hashAndSalt256.hashWithSaltResult);
        Console.WriteLine("\n\n\n");
        Console.WriteLine("Salt String With Algorithm [ SHA512 ]\n");
        Console.WriteLine("Salt         [ SHA512 ]    : {0}", hashAndSalt512.saltString);
        Console.WriteLine("HashWithSalt [ SHA512 ]    : {0}", hashAndSalt512.hashWithSaltResult);
    }
    Console.WriteLine("\nIf you want to continue the press [1]...");
    choice = int.Parse(Console.ReadLine());
} while (choice == 1);



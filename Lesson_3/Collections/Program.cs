// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;




var usersAccounts = new Dictionary<string, (string, string, double)>();
    usersAccounts.Add("admin", ("Oleh Kutafin","password", 100.00));
    Console.WriteLine($"User {usersAccounts["admin"].Item1} has a balance of {usersAccounts["admin"].Item3}");

var usersAccounts2 = new Dictionary<string, Tuple<string, double>>();
    usersAccounts2.Add("admin", new Tuple<string, double>("password", 100.00));
    Console.WriteLine($"User {usersAccounts2} has a balance of {usersAccounts2["admin"].Item2}");



class UserAccount
{
    public string Login { get; }
    public string Password { get; }
    public double Balance { get; }

    public UserAccount(string login, string password, double balance)
    {
        Login = login;
        Password = password;
        Balance = balance;
    }
}

class UserAccount2(string login, string password, double balance)
{
    public string Login { get; } = login;
    public string Password { get; } = password;
    public double Balance { get; } = balance;
}
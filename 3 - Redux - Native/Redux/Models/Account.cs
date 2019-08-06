namespace Redux.Models
{
    public class Account
    {
        public Account(string name, int balance, AccountType accountType)
        {
            Name = name;
            Balance = balance;
            AccountType = accountType;
        }

        public string Name { get; }
        public int Balance { get; }
        public AccountType AccountType { get; }
    }
}
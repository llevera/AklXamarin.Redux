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
        
        public string Name { get; set; }
        public int Balance { get; set; }
        public AccountType AccountType { get; set; }
    }
}
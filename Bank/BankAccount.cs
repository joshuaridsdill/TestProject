namespace Bank
{
    public class BankAccount
    {
        private double balance;

        public static void Main(string[] args)
        {

        }

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0)
            {
                if (balance >= amount)
                {
                    balance -= amount;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(amount));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }
        }

        public void TransferFundsTo(BankAccount otherAccount, double amount)
        {
            if (otherAccount != null)
            {
                if (amount > 0)
                {
                    if (amount <= balance)
                    {
                        Withdraw(amount);
                        otherAccount.Deposit(amount);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(amount));
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(amount));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(otherAccount));
            }
        }

        public void TransferAllFundsTo(BankAccount otherAccount)
        {
            if (otherAccount != null)
            {
                if (balance > 0)
                {
                    double transferAmount = balance;

                    Withdraw(balance);

                    otherAccount.Deposit(transferAmount);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(balance));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(otherAccount));
            }
        }

        public double CheckBalance()
        {
            return balance;
        }
    }
}
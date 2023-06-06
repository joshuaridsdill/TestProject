using Bank;
using NUnit.Framework;

namespace Bank.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        private static BankAccount account;
        private static double initialBalance = 100.0;

        [SetUp]
        public static void Setup()
        {
            account = new BankAccount(initialBalance);
        }

        [Test]
        public void Deposit_ValidAmount_IncreasesBalance()
        {
            // Arrange
            double depositAmount = 50.0;

            // Act
            account.Deposit(depositAmount);

            // Assert
            double expectedBalance = initialBalance + depositAmount;
            Assert.That(account.CheckBalance(), Is.EqualTo(expectedBalance));
        }

        [Test]
        public void Withdraw_ValidAmount_DecreasesBalance()
        {
            // Arrange
            double withdrawalAmount = 50.0;

            // Act
            account.Withdraw(withdrawalAmount);

            // Assert
            double expectedBalance = initialBalance - withdrawalAmount;
            Assert.That(account.CheckBalance(), Is.EqualTo(expectedBalance));
        }

        [Test]
        public void TransferFundsTo_ValidAmount_TransfersFunds()
        {
            // Arrange
            double transferAmount = 50.0;
            BankAccount account1 = new BankAccount(initialBalance);
            BankAccount account2 = new BankAccount(0.0);

            // Act
            account1.TransferFundsTo(account2, transferAmount);

            // Assert
            double expectedBalance1 = initialBalance - transferAmount;
            double expectedBalance2 = transferAmount;
            Assert.That(account1.CheckBalance(), Is.EqualTo(expectedBalance1));
            Assert.That(account2.CheckBalance(), Is.EqualTo(expectedBalance2));
        }

        [Test]
        public void TransferAllFundsTo_ValidAccount_TransfersAllFunds()
        {
            // Arrange
            BankAccount account2 = new BankAccount(0.0);

            // Act
            account.TransferAllFundsTo(account2);

            // Assert
            double expectedBalance1 = 0.0;
            double expectedBalance2 = initialBalance;
            Assert.That(account.CheckBalance(), Is.EqualTo(expectedBalance1));
            Assert.That(account2.CheckBalance(), Is.EqualTo(expectedBalance2));
        }
    }
}

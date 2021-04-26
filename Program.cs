using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public string AccountType { get; set; }

        public string TransactionType { get; set; }

        public int TransactionAmount { get; set; }

    }
    class Program
    {
        static int CalculateBalance(List<Transaction> allTransactions, string acctType)
        {

            var allTransactionAmounts = allTransactions.Where(acct => acct.AccountType == acctType);
            var allDeposits = allTransactionAmounts.Where(type => type.TransactionType == "deposit").Sum(x => x.TransactionAmount);
            var allWithdraws = allTransactionAmounts.Where(type => type.TransactionType == "withdraw").Sum(x => x.TransactionAmount);

            var totalBalance = (allDeposits - allWithdraws);

            return totalBalance;
        }
        static void DisplayWelcome()
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("--- Welcome to First Bank of Suncoast ---");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("");
        }
        // method to prompt for string response
        static string PromptForString(string prompt)
        {
            // write prompt
            Console.WriteLine(prompt);
            // read line and set it as the userInput
            var userInput = Console.ReadLine().ToUpper();
            // - return response
            return userInput;
        }
        static int PromptForInterger(string prompt)
        {
            // method to prompt for int response
            Console.WriteLine(prompt);
            int userInput;
            // - read line
            var goodInput = Int32.TryParse(Console.ReadLine(), out userInput);
            if (goodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Invalid numbers default to 0");
                // - return response
                return 0;
            }
        }
        // load past transactions from a file when it first starts.....save for last

        static void Main(string[] args)
        {
            // display welcome banner
            DisplayWelcome();
            // create an empty list of transactions
            var transactions = new List<Transaction>();

            // if there is a file, use StreamReader + CsvReader to replace the contents of the list
            if (File.Exists("FirstBankOfSuncoast.csv"))
            {
                // create a stream for reading info from a file
                var fileReader = new StreamReader("FirstBankOfSuncoast.csv");
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                };
                var csvReader = new CsvReader(fileReader, config);

                // read rows from the stream. each row is an int. give back a List (List<Transaction>)
                transactions = csvReader.GetRecords<Transaction>().ToList();
            }


            var keepGoing = true;
            while (keepGoing)
            {
                // create bool statement to determine is prog can cont

                // create a menu
                // "Please select from the followring: [D]eposit. [W]ithdraw. [V]eiw. [Q]uit.
                Console.WriteLine("");
                Console.WriteLine("Menu options: [D]eposit. [W]ithdraw. [V]iew. [Q]uit.");

                var answer = Console.ReadLine().ToUpper();

                switch (answer)
                {
                    // if input = Q
                    case "Q":
                        // bool = false
                        keepGoing = false;
                        break;
                    // if input = V
                    case "V":

                        Console.WriteLine($"Checking acct total: ${CalculateBalance(transactions, "checking")}");
                        Console.WriteLine($"Savings acct total: ${CalculateBalance(transactions, "savings")}");
                        break;

                    case "D":

                        var tran = new Transaction();

                        var acctToDeposit = PromptForString("[C]hecking or [S]avings?");

                        // Transaction foundAcctToUpdate = tranactions.FirstOrDefault(tran => tran.AccountType == acctToUpdate);
                        if (acctToDeposit == null)
                        {
                            Console.WriteLine("Please select either [C]hecking or [S]avings");
                        }
                        else
                        {
                            if (acctToDeposit == "C")
                            {
                                tran.AccountType = "checking";
                                tran.TransactionType = "deposit";
                                tran.TransactionAmount = PromptForInterger("How much do you want to deposit?");
                                transactions.Add(tran);


                            }
                            else if (acctToDeposit == "S")
                            {
                                tran.AccountType = "savings";
                                tran.TransactionType = "deposit";
                                tran.TransactionAmount = PromptForInterger("How much do you want to deposit?");
                                transactions.Add(tran);
                            }
                        }
                        break;

                    case "W":

                        var withdrawTran = new Transaction();

                        var acctToWithdraw = PromptForString("[C]hecking or [S]avings?");

                        if (acctToWithdraw == null)
                        {
                            Console.WriteLine("Please select either [C]hecking or [S]avings");
                        }
                        else
                        {
                            if (acctToWithdraw == "C")
                            {
                                withdrawTran.AccountType = "checking";
                                withdrawTran.TransactionType = "withdraw";
                                withdrawTran.TransactionAmount = PromptForInterger("How much do you want to withdraw?");

                                // create if statement so that the user cannot withdraw more than what is in the acct
                                if (CalculateBalance(transactions, "checking") < withdrawTran.TransactionAmount)
                                {
                                    Console.WriteLine($"Insufficient funds. Available: ${CalculateBalance(transactions, "checking")}");
                                }
                                else
                                {
                                    transactions.Add(withdrawTran);
                                }
                            }
                            else if (acctToWithdraw == "S")
                            {
                                withdrawTran.AccountType = "savings";
                                withdrawTran.TransactionType = "withdraw";
                                withdrawTran.TransactionAmount = PromptForInterger("How much do you want to withdraw?");

                                if (CalculateBalance(transactions, "savings") < withdrawTran.TransactionAmount)
                                {
                                    Console.WriteLine($"Insufficient Funds. Available: ${CalculateBalance(transactions, "savings")}");
                                }
                                else
                                {
                                    transactions.Add(withdrawTran);
                                }
                            }
                        }
                        break;
                }
            }
            // create a stream for writing info into a file
            var fileWriter = new StreamWriter("FirstBankOfSuncoast.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            // write and record the list of transactions
            csvWriter.WriteRecords(transactions);
            fileWriter.Close();
        }
    }
}
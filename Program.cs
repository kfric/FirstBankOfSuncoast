using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstBankOfSuncoast
{
    class Transaction
    {

        public string AccountType { get; set; }

        public string TransactionType { get; set; }

        public int TransactionAmount { get; set; }

        // not sure if using methods to calculate totals of check>deposit>amt, check>withdraw>amt, saving>deposit>amt, saving>withdraw>amt.....


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

            var transactions = new List<Transaction>();




            var keepGoing = true;

            while (keepGoing)
            {
                // create bool statement to determine is prog can cont

                // create a menu
                // "Please select from the followring: [D]eposit. [W]ithdraw. [V]eiw. [Q]uit.
                Console.WriteLine("");
                Console.WriteLine("Menu options: [D]eposite. [W]ithdraw. [V]iew. [Q]uit.");

                var answer = Console.ReadLine().ToUpper();

                // if input = Q
                if (answer == "Q")
                // bool = false
                {
                    keepGoing = false;
                }
                // if input = V
                else if (answer == "V")
                {
                    Console.WriteLine($"Checking acct total: ${CalculateBalance(transactions, "checking")}");
                    Console.WriteLine($"Savings acct total: ${CalculateBalance(transactions, "savings")}");
                }
                else if (answer == "D")
                {
                    var tran = new Transaction();

                    var acctToUpdate = PromptForString("[C]hecking or [S]avings?");

                    // Transaction foundAcctToUpdate = tranactions.FirstOrDefault(tran => tran.AccountType == acctToUpdate);

                    if (acctToUpdate == null)
                    {
                        Console.WriteLine("Please select either [C]hecking or [S]avings");
                    }
                    else
                    {
                        if (acctToUpdate == "C")
                        {
                            tran.AccountType = "checking";
                            tran.TransactionType = "deposit";
                            tran.TransactionAmount = PromptForInterger("How much do you want to deposit?");
                            transactions.Add(tran);


                        }
                        else if (acctToUpdate == "S")
                        {
                            tran.AccountType = "savings";
                            tran.TransactionType = "deposit";
                            tran.TransactionAmount = PromptForInterger("How much do you want to deposit?");
                            transactions.Add(tran);
                        }
                    }

                }
                else if (answer == "W")
                {
                    var tran = new Transaction();

                    var acctToUpdate = PromptForString("[C]hecking or [S]avings?");

                    if (acctToUpdate == null)
                    {
                        Console.WriteLine("Please select either [C]hecking or [S]avings");
                    }
                    else
                    {
                        if (acctToUpdate == "C")
                        {
                            tran.AccountType = "checking";
                            tran.TransactionType = "withdraw";
                            tran.TransactionAmount = PromptForInterger("How much do you want to withdraw?");

                            // create if statement so that the user cannot withdraw more than what is in the acct
                            if (CalculateBalance(transactions, "checking") < tran.TransactionAmount)
                            {
                                Console.WriteLine("Insufficient funds");
                            }
                            else
                            {
                                transactions.Add(tran);
                            }

                        }
                        else if (acctToUpdate == "S")
                        {
                            tran.AccountType = "savings";
                            tran.TransactionType = "withdraw";
                            tran.TransactionAmount = PromptForInterger("How much do you want to withdraw?");

                            if (CalculateBalance(transactions, "savings") < tran.TransactionAmount)
                            {
                                Console.WriteLine("Insufficient Funds");
                            }
                            else
                            {
                                transactions.Add(tran);

                            }
                        }
                    }

                }

            }




            // else if = D
            //   var acctDeposit = prompt for string "Which acct do you want to update?"
            //   var acctToUpdate = acct by name in accts list with the name equal to the name to be updated
            //   if null
            //   return no acct by that name

            //   else transAmount = prompt for int $"how much do you want to deposit in {acctToUpdate}?"

            //   acctToUpdate.balance = transAmount + balance??

            // else if = W
            //   var acctDeposit = prompt for string "Which acct do you want to update?"
            //   var acctToUpdate = acct by name in accts list with the name equal to the name to be update
            //   if null
            //   return no acct by that name

            //   else transAmount = prompt for int $"how much do you want to deposit in {acctToUpdate}?"

            //   acctToUpdate.balance = transAmount - balance??

            //   else transAmount = prompt for int $"how much do you want to deposit in {acctToUpdate}?"

            //   acctToUpdate.balance = transAmount + balance??



            // The application should, after each transaction, write all the transactions to a file.
            // This is the same file the application loads.......save for last





        }







    }
}


using System;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        // AcctType {get; set;}
        public string AccountType { get; set; }

        // Balance {get; set;}
        public string Balance { get; set; }

        // saving {get; set;}
        public string SavingAccount { get; set; }
        // checking acct
        public string CheckingAccount { get; set; }
    }
    class Program
    {
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
            var userInput = Console.ReadLine();
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
                return 0;
            }

            // - return response
        }


        // load past transactions from a file when it first starts.....save for last
        static void Main(string[] args)
        {

            // display welcome banner
            DisplayWelcome();








            // prompt "Which acct would you like to update?: [C]hecking or [S]avings"
            // prompt "Specified amount $:?"

            // create new balance list to hold the values of the balance for checking and saving acct
            // -add the collection of values to the list 

            // create a menu
            // "Please select from the followring: [D]eposit. [W]ithdraw. [V]eiw. [Q]uit.

            // if input = V
            // console.writeline("{name} has a balance of {balance}")

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



            // else input = Q
            // bool = false

            // The application should, after each transaction, write all the transactions to a file.
            // This is the same file the application loads.......save for last




        }
    }
}

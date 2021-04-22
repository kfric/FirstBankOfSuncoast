using System;

namespace FirstBankOfSuncoast
{
    class Program
    {
        static void Main(string[] args)
        {
            //       -- Promblem ---
            // - The application should store a history of transactions in a SINGLE List<Transaction>. 
            // Your task is to design the Transaction class to support both checking and savings as well as deposits and withdraws.
            // - The application should load past transactions from a file when it first starts.
            // - As a user I should be able to see the list of transactions designated savings.
            // - As a user I should be able to see the list of transactions designated checking.
            // - Never allow withdrawing more money than is available. That is, we cannot allow our checking or 
            // savings balances to go negative.
            // - When prompting for an amount to deposit or withdraw always ensure the amount is positive. The value we 
            // store in the Transaction shall be positive as well. (e.g. a Transaction that is a withdraw of 25 both inputs and 
            // records a positive 25)
            // - As a user I should have a menu option to make a deposit transaction for savings.
            // - As a user I should have a menu option to make a deposit transaction for checking.
            // - As a user I should have a menu option to make a withdraw transaction for savings.
            // - As a user I should have a menu option to make a withdraw transaction for checking.
            // - As a user I should have a menu option to see the balance of my savings and checking.
            // - The application should, after each transaction, write all the transactions to a file. This is the same file the 
            // application loads.

            // -- Example -- 
            // user is displayed $10 in checking and $50 in savings. user will have the option to either select [C]hecking
            // or [S]avings. user will then have to select either [W]ithdraw or [D]epsoit. user wants to deposit $5 in checking
            //   +$5 is added to the current balance of the checking acct. user wants selects check balance
            //   and the balance of both checking and savings are dispalyed.
            // user is displayed $10 in checking and $50 in savings. user will have the option to either select [C]hecking
            // or [S]avings. user will then have to select either [W]ithdraw or [D]epsoit. user wants to withdraw $10 from savings 
            //   acct. -$5 subtracted from the saving balance ($50). user wants to display the current balance
            //   of both accts. checking balance of $10 and saving balance of $40 are displayed.
            // user is displayed $10 in checking and $50 in savings. user will have the option to either select [C]hecking
            // or [S]avings. user will then have to select either [W]ithdraw or [D]epsoit. user wants to withdraw $15 from their checking
            //   acct. user withdraw amount ($15) is greater than the balance of checking ($10). user is notifed 
            //   "insuffient funds" and is displayed the balance of their checking acct.


            // -- Data --
            // nouns:
            // checkings
            // - holds checking balance - int
            // - shows all trans for this acct - string
            // savings
            // - holds savings balance - int
            // - shows all trans for this acct - string

        }
    }
}

using System;
using System.Collections.Generic;
using SecureSweBank; // Use the namespace for access to Transaction class

namespace SecureSweBank
{
    class Program // Fix typo here
    {
        public static List<UserTransaction> TransactionList = new List<UserTransaction>(); 
        
        public static void Main(string[] args){

            bool stillrunning = true; // Boolean for the while loop
            int usersmenuoptions; // Menu choice

            while (stillrunning){

                MenuDisplay.DisplayWelcomeTheme(); // Welcome theme

                MenuDisplay.DisplayMainMenu(); // The main menu
                
                string getUserInput = Console.ReadLine()!.ToLower(); // Reading user input and converts to lowercased
 
                if (int.TryParse(getUserInput, out usersmenuoptions)){ // COnverting string to int and used as error handling

                    switch (usersmenuoptions){ // Switch for user option 
                        case 1:
                            UserTransaction.UsersMoneyDeposit(TransactionList); // The function
                            break;// ending the case 

                        case 2:
                            UserTransaction.UsersDeleteTransaction(TransactionList); // The function
                            break;// ending the case      

                        case 3:
                            UserTransaction.UserUseMoney(TransactionList); // The function
                            break;

                        case 4:
                            UserTransaction.UsersCurrentBalance(TransactionList); // The function
                            break;// ending the case 

                        case 5: 
                            UserTransaction.UsersMoneySpent(TransactionList); // The function
                            break;// ending the case 

                        case 6:
                            UserTransaction.UsersMoneyIncome(TransactionList); // The function
                            break;// ending the case 

                        case 7:
                            UserTransaction.UserNeedHelp(); // if the user needs help
                            break;// ending the case 

                        case 8:
                            Console.WriteLine("Exiting SecureSwe Bank..."); 
                            stillrunning = false; // boolean false used to exit and to stop thw while loop
                            break; // ending the case 

                        default: 
                            Console.WriteLine("ensure entering a choice between 1-7!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please, ensure you are choosing between 1-7!"); // error handling
                }

                Console.WriteLine("\nPress any key to continue to the menu!..."); // if the user wants to get to the menu
                 // with \n to show th output a bit down

                Console.ReadKey(); // Until the user preeses anything
            }   
        }
    }
}
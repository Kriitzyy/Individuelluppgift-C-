using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using Microsoft.VisualBasic;

namespace SecureSweBank {  // A won file for classes and functions!
            // Kvar, lägg till sp användaren kan lägga sina produkter i en väska. och sen visa de han spenderat i Spenderade pengar ! 
    public class UserTransaction { // The class 
        // Properties of a transaction 
        public decimal Amount { get; set; } // Amount of money
        public string Source { get; set; } // The source 
        public DateTime Date { get; set; } // The date 
        public List<string> ShoppingBag { get; set; } = new List<string>(); // the list for a item bought in SecureSwe shop!
    
        public UserTransaction(decimal amount, string source) {
            Amount = amount;// The amount 
            Source = source; // The source
            Date = DateTime.Now; // Setting the current date and time
            ShoppingBag = new List<string>();// initialize an empty shopping bag.
        }
      
        public static void UsersMoneyDeposit(List<UserTransaction> TransactionList) { // User gets to deposit money inside a fucntion.

            Console.WriteLine("Write the amount of money you want to deposit:");
            string UserInput = Console.ReadLine()!.ToLower(); // Gets users input and converts it to lowercased

            if (decimal.TryParse(UserInput, out decimal amount)) {
                Console.WriteLine("Where does the money come from? (Salary, Loan, Sale, etc.)");
                string Source = Console.ReadLine()!;

                // Adding the new transaction to the list
                TransactionList.Add(new UserTransaction(amount, Source)); // Adding both amount and the source of money in a list 

                Console.WriteLine("\nThe deposit is successful. Let's continue!");
            }
            else {
                // if the user input was not a valid number 
                Console.WriteLine("The amount is invalid. Enter a valid amount!");
            }
        }

        // Method to delete a transaction
        public static void UsersDeleteTransaction(List<UserTransaction> TransactionList) {

            if (TransactionList.Count == 0) { // If the list if empty the user cant delete money
                Console.WriteLine("There's no transactions to delete..");
                return; // Sending the user back
            }
        
            Console.WriteLine("Here are the current transactions:");
        
            foreach (var UserTransaction in TransactionList) { 
                // Showing the current transactions thru a foreach loop
                Console.WriteLine($"Amount: {UserTransaction.Amount}, Source: {UserTransaction.Source}, Date: {UserTransaction.Date}");
            }

            Console.WriteLine("Enter the amount you want to delete:");
            string DeleteUsersAmount = Console.ReadLine()!.ToLower();

            Console.WriteLine("\nEnter the source you want to delete:");
            string DeleteUserSource = Console.ReadLine()!.ToLower();

            if (decimal.TryParse(DeleteUsersAmount, out decimal amountToDelete))
            { // Tryparse to konvert from string to a decimal and used for error handling
                bool DeleteButton = false; // A boolean used as a button ????

                for (int i = 0; i < TransactionList.Count; i++) // for loop to go thru the money
                {
                    if (TransactionList[i].Amount == amountToDelete  && // Checking if the amount is stored as index
                    TransactionList[i].Source.Equals(DeleteUserSource, StringComparison.OrdinalIgnoreCase)){ 

                    TransactionList.RemoveAt(i); // Removing the users input with index i ????

                    Console.WriteLine("Transaction deleted successfully!");
                    DeleteButton = true;  // If the transaction is deleted seccesfully!
                    return; // sending back the user
                    }
                    else {
                        Console.WriteLine("Please enter the right amount!"); // Error handling
                    }
                }
                
                if (!DeleteButton) { // IF no transactions was found with that amount and source
                    Console.WriteLine("No transactions were found with the specified amount and source.");
                }
            }
            else
            {   // Error handling
                Console.WriteLine("Write the correct amount you want to delete!");
            }
            
        }
        //  User can use money
        public static void UserUseMoney(List<UserTransaction> TransactionList) {

                bool UserIsShopping = true; // Boolean for the while loop to continue running
                bool ItemsPurchased = true; // if the user buys a item used as a button

                while (UserIsShopping) { // Boolean for the while loop to continue running

                Console.WriteLine("Hello welcome to my Swebank shop!!");

                Console.WriteLine("\nHere are the different things i have:");

                Dictionary<string, decimal> UserShopItems = new Dictionary<string, decimal> {
                // A dicitionary for the different items i have! the user can only buy 1 item.
                { "Laptop", 1500.00m },
                { "IPhone 16", 800.00m },
                { "Marshall Headphones", 150.00m },
                { "Airpods", 10.000m },
                { "TV", 1000.00m },
                { "Lamp", 50.00m },
                { "Book", 20.00m },
            };
            decimal UsersMoney = 0; 

            foreach (var Items in UserShopItems) {

                Console.WriteLine($"{Items.Key}: {Items.Value:C} kr");
            }

            foreach (var Transactions in TransactionList) { // ???? 

                if (Transactions.Amount > 0) {
                    UsersMoney += Transactions.Amount;
                }
            }

            Console.WriteLine($"\nYour current balance is: {UsersMoney}"); // showing the current balance of the user 

            MenuDisplay.DisplayShopItems();

            int UsersBuyChoice; // Storing users buy choice.

            Console.WriteLine("\nWhat would you like to buy? Enter the number of the product!!");
            Console.WriteLine("1 item limit!!. After buying one product exit the Shop!");
            string UserInput = Console.ReadLine()!.ToLower();

            if (int.TryParse(UserInput, out UsersBuyChoice)) {

                switch (UsersBuyChoice) {
                    case 1:
                  if (UsersMoney >= UserShopItems["Laptop"]) { // If the users buys a laptop  
                    UsersMoney -= UserShopItems["Laptop"];  // He loses the money.
                    Console.WriteLine("Congrats on your Laptop!");
                    TransactionList[0].ShoppingBag.Add("Laptop");  // Adding the item to the shopping bag
                    ItemsPurchased = true;
                } else {
                    Console.WriteLine("You do not have enough money to buy the Laptop."); // Else if the user doesnt have enough money.
                }
                    break;// ending the case 

                    case 2:
                    if(UsersMoney >= UserShopItems["IPhone 16"]) { // If the user buys Iphone 17
                        UsersMoney -= UserShopItems["Iphone 16"]; // the money is removed
                        Console.WriteLine("Congratulations on your IPhone 16");
                         TransactionList[0].ShoppingBag.Add("Laptop");  // Add item to the shopping bag
                        ItemsPurchased = true;
                    }
                    else {
                        Console.WriteLine("You do not have enough for a IPhone 16..."); // Else if the user doesnt have enough money
                    }
                    break;// ending the case 

                    case 3:
                      if(UsersMoney >= UserShopItems["Marshall Headphones"]) { // If the user buys the headphones
                        UsersMoney -= UserShopItems["Marshall headphones"]; // Money is removed
                        Console.WriteLine("Congratulations on your IPhone 16");
                         TransactionList[0].ShoppingBag.Add("Laptop");  // Adding item to the shopping bag
                         ItemsPurchased = true;
                    }
                    else {
                        Console.WriteLine("You do not have enough for Marshall headphones..."); // if the user doesnt have enough
                    }

                    break;// ending the case 

                    case 4:
                      if(UsersMoney >= UserShopItems["Airpods"]) { // If the user buys the airpods
                        UsersMoney -= UserShopItems["Airpods"]; // remove the money
                        Console.WriteLine("Congratulations on your Airpods");
                         TransactionList[0].ShoppingBag.Add("Laptop");  // Add item to the shopping bag
                         ItemsPurchased = true; // true as a button
                    }
                    else {
                        Console.WriteLine("You do not have enough for Airpods..."); // If the user doesnt have enough money
                    }

                    break;// ending the case 

                    case 5:
                      if(UsersMoney >= UserShopItems["TV"]) { // If the user buys the tv
                        UsersMoney -= UserShopItems["TV"]; // remove the money
                        Console.WriteLine("Congratulations on your TV");
                         TransactionList[0].ShoppingBag.Add("Laptop");  // Adding item to the shopping bag
                         ItemsPurchased = true; // Button as the user bought
                    }
                    else {
                        Console.WriteLine("You do not have enough for a TV..."); // if the user doesnt have enough money
                    }

                    break;// ending the case 

                    case 6:
                      if(UsersMoney >= UserShopItems["Lamp"]) { // If the user buys the lamp
                        UsersMoney -= UserShopItems["Lamp "]; // if the user buys money is removed
                        Console.WriteLine("Congratulations on your Lamp");
                         TransactionList[0].ShoppingBag.Add("Laptop");  // Adding item to the shopping bag
                         ItemsPurchased = true; // Button as true when the user bought.
                    }
                    else {
                        Console.WriteLine("You do not have enough for Lamp...");
                    }

                    break;// ending the case 

                    case 7:
                      if(UsersMoney >= UserShopItems["Book"]) { // IF the user buys the book
                        UsersMoney -= UserShopItems["Book"]; // The money is removed
                        Console.WriteLine("Congratulations on your Book");
                         TransactionList[0].ShoppingBag.Add("Laptop");  // Adding item to the shopping bag
                        ItemsPurchased = true; // Button as true when the user bought.
                    }
                    else {
                        Console.WriteLine("You do not have enough for a book...");
                    }
                    break;// ending the case 

                   default: // default to end the switch and used as error handling
                   Console.WriteLine("Exiting the shop..."); 
                   UserIsShopping = false; // Boolean false used as exit and to stop the while loop.
                   break; // ending the case 
                }
            }
            else {
                Console.WriteLine("Invalid input.. type something valid!");
            }
            
            if (UsersMoney < 0) {
                Console.WriteLine("You do not have enough money to bouy something");
                return;
            }

            Console.ReadKey(); // Console readkey until the user presses any button to continue
    }
}

        // Method to view current balance
        public static void UsersCurrentBalance(List<UserTransaction> TransactionList){
            if (TransactionList.Count == 0){ // If the user doesnt have money

                Console.WriteLine("There are no transactions...");
                return;
            }
          
            foreach (var UsersTransactions in TransactionList){ // Foreach loop to show the current amount with source and date

                Console.WriteLine($"Amount: {UsersTransactions.Amount}, Source: {UsersTransactions.Source}, Date: {UsersTransactions.Date}");
            }
            
        }

        // Placeholder methods for future functionality
        public static void UsersMoneySpent(List<UserTransaction> TransactionList){
            bool UserIsRunning = true; // BOolean for thw while looå

            while (UserIsRunning){

            int UsersMenuOption;  // Users menu option
           
            MenuDisplay.DisplayMoneySpentMenu(); // The menu

            string UserChoice = Console.ReadLine()!.ToLower(); // Users input converts as lower cased
            
            if (int.TryParse(UserChoice, out UsersMenuOption)) { 
                // tryparse to convert string to int, used as error handling as well
                DateTime TheDate = DateTime.Now; // The date

                decimal UsersTotalSpent =  0; // Users total spent

                foreach (var UserTransaction in TransactionList) {
                        
                    if (UserTransaction.Amount < 0) { 
                        switch (UsersMenuOption) {   
                            case 1:  
                            if (UserTransaction.Date.Year == TheDate.Year) { // This case checks if the transaction occurred in the current month of the current year
                                UsersTotalSpent += UserTransaction.Amount; 
                            }
                            break;   

                            case 2:
                            if (UserTransaction.Date.Year == TheDate.Year && UserTransaction.Date.Month == TheDate.Month) {
                            // This case checks if the transaction occurred in the current month of the current yea
                                UsersTotalSpent += UserTransaction.Amount;
                            }
                            break;

                            case 3:
                              if (UserTransaction.Date.Year == TheDate.Year && 
                              YearMonthWeekDay(UserTransaction.Date) == YearMonthWeekDay(TheDate)) { 
                              UsersTotalSpent += UserTransaction.Amount;
                              }
                            break;

                            case 4:
                            if (UserTransaction.Date.Date == TheDate.Date) {   
                                UsersTotalSpent += UserTransaction.Amount;
                            }
                            break;

                            case 5:   
                            Console.WriteLine("Exiting....");
                            UserIsRunning = false;
                            break;
                            
                            default:
                            Console.WriteLine("Invalid choice, choose between 1-4");
                            break;
                        }
                    }
                    else {
                        Console.WriteLine("Invalid input choose between 1-4!");
                    } 
                }   
            }
        }
    }
        // Function for users income
        public static void UsersMoneyIncome(List<UserTransaction> transactionList){
            bool UserIsRunning = true; // Boolean for the while looå

            while (UserIsRunning){

            MenuDisplay.DisplayIncomeMenu();// The menu

            string UserInput = Console.ReadLine()!.ToLower(); // Input reading and converts to lowercased

            if (int.TryParse(UserInput, out int UserChoice)){

            DateTime currentDate = DateTime.Now; // The date 
            decimal TotalIncome = 0;  // Ensuring consistent use of 'TotalIncome' with capital 'T'

            for (int i = 0; i < transactionList.Count; i++)
            {
                // Only consider transactions with positive amounts (income)
                if (transactionList[i].Amount > 0)
                {
                    switch (UserChoice)
                    {
                        case 1: // Yearly income
                            if (transactionList[i].Date.Year == currentDate.Year)
                            {
                                TotalIncome += transactionList[i].Amount;
                            }
                            break;

                        case 2: // Monthly income
                            if (transactionList[i].Date.Year == currentDate.Year &&
                                transactionList[i].Date.Month == currentDate.Month)
                            {
                                TotalIncome += transactionList[i].Amount;
                            }
                            break;

                        case 3: // Weekly income
                            if (YearMonthWeekDay(transactionList[i].Date) == YearMonthWeekDay(currentDate))
                            {
                                TotalIncome += transactionList[i].Amount;
                            }
                            break;

                        case 4: // Daily income
                            if (transactionList[i].Date.Date == currentDate.Date)
                            {
                                TotalIncome += transactionList[i].Amount;
                            }
                            break;

                        case 5: // Exit
                            Console.WriteLine("Exiting income view...");
                            UserIsRunning = false;
                            break;

                        default:
                            Console.WriteLine("Invalid choice, please choose between 1-5.");
                            break;
                    }
                }
            }

            if (UserChoice >= 1 && UserChoice <= 4) // ensuring the user is choosing between 1-4
            {
                Console.WriteLine($"Total income for the selected period: {TotalIncome:C}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input, please enter a number between 1-5."); // error handling
        }
    }
}        

        public static void UserNeedHelp() { // if the user needs help
   
            Console.WriteLine("Welcome to SecureSweBank");
            
            Console.WriteLine("\nWhen you are using SecureSwe Bank!"); // explained
            Console.WriteLine("Ensure you are using the program step by step!");
            Console.WriteLine("Start with number 1 and end with number 7!");
            Console.WriteLine("Hope the information helps!");
            Console.WriteLine("Write your feedback so we can improve our bank!");

            Console.WriteLine("\nRegards, SecureSwe Bank!");
            string feedback = Console.ReadLine()!.ToLower();
        }
        
        // Fucntion for Year month week and day
        public static int YearMonthWeekDay(DateTime UsersDate) { 
            var cultureInfo = System.Globalization.CultureInfo.CurrentCulture;
            var calendar = cultureInfo.Calendar; /// The calender 
            var weekOfYear = calendar.GetWeekOfYear(UsersDate, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday); /// The first day of the week
            return weekOfYear; /// Ending the metod
        }
       
    }
}

using System;

namespace SecureSweBank
{
    public static class MenuDisplay
    {
        public static void DisplayWelcomeTheme()
        {
            Console.WriteLine(@"
 __          __  _                            _         
 \ \        / / | |                          | |        
  \ \  /\  / /__| | ___ ___  _ __ ___   ___  | |_ ___   
   \ \/  \/ / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \  
    \  /\  /  __/ | (_| (_) | | | | | |  __/ | || (_) | 
     \/  \/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/                                        
");
        }

        public static void DisplayMainMenu()
        {
            Console.WriteLine("SecureSwe Bank - Start Managing Your Finances!");
            Console.WriteLine("\nChoose between 1-7!");
            Console.WriteLine("[1] - Make a deposit!");
            Console.WriteLine("[2] - Delete transactions!");
            Console.WriteLine("[3] - Use your money to buy different things for yourself!");
            Console.WriteLine("[4] - View your current account balance!");
            Console.WriteLine("[5] - See money spent yearly, monthly, weekly, and daily!");
            Console.WriteLine("[6] - See income by year, monthly, weekly, and daily!");
            Console.WriteLine("[7] - Not understanding the program? Get help!");
            Console.WriteLine("[8] - Exit the program!");
        }

        public static void DisplayShopItems()
        {
            Console.WriteLine("Here are the different items we have:");

            Console.WriteLine("\n[1] - Laptop");
            Console.WriteLine("[2] - IPhone 16");
            Console.WriteLine("[3] - Marshall headphones");
            Console.WriteLine("[4] - Airpods");
            Console.WriteLine("[5] - TV");
            Console.WriteLine("[6] - Lamp");
            Console.WriteLine("[7] - Book");
            Console.WriteLine("[8] - Exit the shop...");
        }

        public static void DisplayIncomeMenu()
        {
            Console.WriteLine("Choose a period of time to view your income:");
            Console.WriteLine("\n[1] - Yearly income");
            Console.WriteLine("[2] - Monthly income");
            Console.WriteLine("[3] - Weekly income");
            Console.WriteLine("[4] - Daily income");
            Console.WriteLine("[5] - Exit income view");
        }

        public static void DisplayMoneySpentMenu()
        {
            Console.WriteLine("Choose a period to see your spent money:");
            Console.WriteLine("\n[1] - View yearly spending");
            Console.WriteLine("[2] - View monthly spending");
            Console.WriteLine("[3] - View weekly spending");
            Console.WriteLine("[4] - View daily spending");
            Console.WriteLine("[5] - Exit spending option!");
        }
    }
}
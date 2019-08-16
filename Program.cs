using System;

namespace cSharpProject
{
    class Program
    {     
        public int getAmount()
        {
            bool ok = false;
            int theAmount = 0;
            Console.WriteLine("Enter Money Amount:");
            while(!ok)
            {
                string theInput = Console.ReadLine();
                if(int.TryParse(theInput, out theAmount)==true)
                {
                    theAmount = int.Parse(theInput);
                    if(theAmount<=0)
                    {
                        Console.WriteLine("Invalid Input. Please Try Again.");
                    }
                    else
                    {
                        Console.WriteLine("You have: " +theAmount + " dollars.");
                        ok = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please Try Again.");
                }
            }
            return theAmount;
        } 
        public int getRoll()
        {
            Random rand1 = new Random();
            Random rand2 = new Random();
            int dice1 = rand1.Next(1,7);
            int dice2 = rand2.Next(1,7);
            int currentRoll = dice1 + dice2;
            return currentRoll;
        }

       // public int getBet(int amount)
        public int getBet(int amount)
        {
            int yourBet = 0;
            Console.WriteLine("Enter bet: ");
            bool ok = false;
            while(!ok)
            {
                string theInput = Console.ReadLine();
                if(int.TryParse(theInput, out yourBet)==true)
                {
                    yourBet = int.Parse(theInput);
                    if(yourBet > amount)
                    {
                        Console.WriteLine("Invalid Amount. Enter Again:");
                    }
                    else
                    {
                        Console.WriteLine("You bet: " + yourBet + " dollars.");
                        ok = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please Try Again.");
                }
            }
            return yourBet;
        }


        public int playGame(int myBet, int myAmount)
        {
            int firstRoll  = getRoll();
            int currentRoll = getRoll();
            Console.WriteLine("The first roll was: " +firstRoll);
            if(firstRoll == 7 || firstRoll == 11)
            {
                Console.WriteLine("You lose");
                myAmount-=myBet;
                return myAmount;
            }
            if(firstRoll == 2 || firstRoll == 3 || firstRoll == 12)
            {
               Console.WriteLine("You win!");
               myAmount += myBet;
               return myAmount;
            }
            else
            {
                currentRoll = firstRoll;
            }
            int forWin = getRoll();
            while(currentRoll != forWin || currentRoll != 7)
            {
                currentRoll = getRoll();
                Console.WriteLine("You rolled: " +currentRoll);
                if(currentRoll==7)
                {
                    Console.WriteLine("You lose");
                    myAmount-=myBet;
                    return myAmount;
                }
                if(currentRoll==forWin)
                {
                    Console.WriteLine("You win!");
                    myAmount += myBet;
                    return myAmount;
                }
                else
                {
                    Console.WriteLine("Rolling Again!");
                }
            }
            return myAmount;
        }
        
        static void Main(string[] args)
        {
            Program craps = new Program();
            bool keepPlaying = true;
            int myAmount = craps.getAmount();
            while(keepPlaying)
            {
                int myBet = craps.getBet(myAmount);
                int result = craps.playGame(myBet, myAmount);
                myAmount = result;
                Console.WriteLine("You have: " + myAmount + " dollars.");
                if(myAmount==0)
                {
                    keepPlaying = false;
                    Console.WriteLine("Out of money! Game over.");
                }
                else
                {
                    Console.WriteLine("Play Again? Enter 1 to stop or anything else to continue.");
                    var next = Console.ReadLine();
                    if(next=="1")
                    {
                        keepPlaying = false;
                        Console.WriteLine("You stopped playing.");
                        Console.WriteLine("Final Result: " + myAmount);
                    }
                }
            }
        }
    }
}

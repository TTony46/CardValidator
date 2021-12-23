using System;
using System.Collections.Generic;
using System.Numerics;

namespace CardValidationProject
{
    class Program
    {
        static List<int> GetCreditCardDetails()
        {
            var cardNumbers = new List<int>();
            Console.WriteLine("Enter the 16 digit credit card number: ");
            var input = (Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
            {
                // For the case if user enters spaces between their digits
                while (input[i] == ' ')
                {
                    i++;
                }
                cardNumbers.Add((int)Char.GetNumericValue(input[i]));
            }
            return cardNumbers;
        }

        static void PrintCardDetails(List<int> cardNumbers)
        {
            string result = "";
            for (int i = 0; i < cardNumbers.Count; i++)
            {      
                result += cardNumbers[i].ToString();            
                if (i != 0 && (i+1) % 4 == 0)  // Adds a space (' ') after every four digits. 
                { 
                    result += " ";
                }
            }
            Console.WriteLine("Your card numbers are: " + result);
        }

        static string IsCardNumbersValid(List<int> cardNumbers)
        {
            int oddIndexSum = 0;
            int evenIndexSum = 0;

            for (int i = 0; i < cardNumbers.Count; i++)
            {
                int currentCardDigit = cardNumbers[i];
                bool isIndexEven = (i % 2 == 0);

                // Uses Luhn Check Algorithm
                if (!isIndexEven) { oddIndexSum += currentCardDigit; }
                if (isIndexEven)
                {
                    if ((currentCardDigit * 2) >= 10)
                    {
                        evenIndexSum += ((currentCardDigit * 2) - 9);
                    }
                    else
                    {
                        evenIndexSum += (currentCardDigit * 2);
                    }
                }
            }
            int total = oddIndexSum + evenIndexSum;
            if (total % 10 == 0)
            {
                return ("Card Numbers are valid.");
            }
            return ("Card Numbers are not valid.");     
        }

        static void Main(string[] args)
        {
            bool loop = false;
            do
            {
                var cardDetails = GetCreditCardDetails();
                while (!(cardDetails.Count == 16))
                {
                    Console.WriteLine("Card entered is not 16 digits, please try again.");
                    cardDetails = GetCreditCardDetails();
                }

                PrintCardDetails(cardDetails);
                Console.WriteLine("\n"+IsCardNumbersValid(cardDetails));

                // If user wants to rerun the program, changes the 'while' condition to true.
                Console.WriteLine("\nTry again? (y/n) ");
                var input = Console.ReadLine();

                if (input == null) return;
                else if (input.ToLower() == "y")
                {
                    loop = true;
                } 
                else
                {
                    Console.WriteLine("\nProgram exited successfully");
                    loop = false;                   
                }
            } while (loop == true);     
        }
    }
}

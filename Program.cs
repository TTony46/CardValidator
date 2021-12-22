using System;
using System.Collections.Generic;
using System.Numerics;

namespace CardValidationProject
{
    class Program
    {
        static List<int> getCreditCardDetails()
        {
            var cardNumbers = new List<int>();
            Console.WriteLine("Enter the 16 digit credit card number (eg: 1111 2222 3333 4444): ");
            var input = (Console.ReadLine());

            for (int i = 0; i < input.Length; i++)
            {
                while (input[i] == ' ')
                {
                    i++;
                }
                cardNumbers.Add((int)Char.GetNumericValue(input[i]));
            }
            return cardNumbers;
        }

        static void printCardDetails(List<int> cardNumbers)
        {
            string result = "";
            for (int i = 0; i < cardNumbers.Count; i++)
            {      
                result += cardNumbers[i].ToString();
                if (i != 0 && (i+1) % 4 == 0)
                { 
                    result += " ";
                }
            }
            Console.WriteLine("Your card numbers are: " + result);
        }
        static string isCardNumbersValid(List<int> cardNumbers)
        {
            int oddIndexSum = 0;
            int evenIndexSum = 0;

            for (int i = 0; i < cardNumbers.Count; i++)
            {
                int currentCardDigit = cardNumbers[i];
                bool isIndexEven = (i % 2 == 0);

                if (!isIndexEven)
                {
                    oddIndexSum += currentCardDigit;
                }
                if (isIndexEven)
                {
                    if ((currentCardDigit * 2) >= 10)
                    {
                        //Console.WriteLine("Added: " + ((currentCardDigit * 2) - 9));
                        evenIndexSum += ((currentCardDigit * 2) - 9);
                    }
                    else
                    {
                        evenIndexSum += (currentCardDigit * 2);
                        //Console.WriteLine("Added: " + currentCardDigit);
                    }
                }
            }
            int total = oddIndexSum + evenIndexSum;

            Console.WriteLine("oddIndexSum is: " + oddIndexSum + " and evenIndexSum is: " + evenIndexSum);
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
                var cardDetails = getCreditCardDetails();
                printCardDetails(cardDetails);
                Console.WriteLine("\n"+isCardNumbersValid(cardDetails));

                Console.WriteLine("Do you want to try again? (y/n) ");
                var input = Console.ReadLine();

                if (input == null) return;
                if (input.ToLower() == "y")
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLotVersion3
{
    class EnterUserNumbers
    {
        int[] userArray = new int[6];
        int[] resultArray = new int[6];
        int[] winningArray = new int[6];

        public void InputLotteryNumbers()
        {
            ValidateUserNumbers check = new ValidateUserNumbers();
            for (int i = 0; i < 6; i++)
            {
                Console.Write("\nPlease enter lottery number " + (i + 1) + " : ");
                int numberInput = int.Parse(Console.ReadLine());
               
                if (check.IsDupliate(userArray, numberInput) || check.IsNotVaildNumber(numberInput))
                {
                    i--;
                }                    
                else
                {
                    userArray[i] = numberInput;
                }               
            }
        }

        public void ShowUserNumbers()
        {
            Console.Write("\nThe numbers you inputed was: \n");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0}\t", userArray[i]);
            }
            Console.WriteLine();
        }

        public void GenerateRandomNumbers()
        {
            Random randomNumbers = new Random();
            int resultArrayNumber;

            for (int x = 0; x < resultArray.Length; x++)
            {
                resultArrayNumber = randomNumbers.Next(0, 50);
                if (resultArray.Contains(resultArrayNumber))
                {
                    x--;
                }
                else
                {
                    resultArray[x] = resultArrayNumber;
                }
            }
            Array.Sort(resultArray);
            Console.Write("Tonights winning numbers are : \n");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0}\t", resultArray[i]);
            }
            Console.WriteLine();
        }

        public void DisplayWinningResults()
        {
            MatchBothArrays result = new MatchBothArrays();
            result.CalculateResults(userArray, resultArray, winningArray);
            Console.WriteLine("You matched: ");

            for (int i = 0; i < winningArray.Length; i++)
            {
                Console.Write("{0}\t", winningArray[i]);
            }
        }
    }

    class MatchBothArrays
    {
        public void CalculateResults(int[] user, int[] random, int[] win)
        {
            for (int i = 0; i < user.Count(); i++)
            {
                for (int j = 0; j < random.Count(); j++)
                {
                    if (user[i] == random[j])
                    {
                        Array.Copy(user, win, user[i]);
                    }
                }
            }
        }
    }

    class ValidateUserNumbers
    {
        //public bool IsNotNumber(int input)
        //{
        //    bool status = false;
        //    try
        //    {
        //        input = int.Parse(Console.ReadLine());
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(input + " is not a vaild number. Could you please enter a numeric value - " + ex.Message);
        //        status = true;
        //    }
        //    return status;
        //}
        
        public bool IsDupliate(int[] arr, int input)
        {
            bool status = false;
            if (arr.Contains(input))
            {
                Console.WriteLine("You have already chosen number " + input);
                status = true;
            }
            return status;
        }

        public bool IsNotVaildNumber(int input)
        {
            bool status = false;
            if (input < 1 || input > 49)
            {
                Console.Write("\nPlease picked a number between 1 and 49");
                status = true;
            }
            return status;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            EnterUserNumbers kLot = new EnterUserNumbers();
            kLot.InputLotteryNumbers();
            Console.WriteLine("\n\n");
            kLot.ShowUserNumbers();
            kLot.GenerateRandomNumbers();
            kLot.DisplayWinningResults();
            Console.ReadLine();
        }
    }
}

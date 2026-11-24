using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Collections.Specialized.BitVector32;

namespace Calculator
{
    internal class Calculator
    {
        static double FirstNumberCheck (string userInput)
        {
            double num;
            while (true)
            {
                try
                {
                    num = Convert.ToDouble(userInput);
                }
                catch (Exception)
                {
                    Console.WriteLine("First number is in wrong format. Please enter the number again:");
                    userInput = Console.ReadLine();
                    continue;
                }
                break;
            }
            return num;
        }

        static double SecondNumberCheck (string userInput)
        {
            double num;
            while (true)
            {
                try
                {
                    num = Convert.ToDouble(userInput);
                }
                catch (Exception)
                {
                    Console.WriteLine("Second number is in wrong format. Please enter the number again:");
                    userInput = Console.ReadLine();
                    continue;
                }
                break;
            }
            return num;
        }
        static void Main(string[] args)
        {
            char[] allowed = { '+', '-', '*', '/' };
            int index;
            string a = "";
            string b = "";
            string sign = "";

            //1.Get user input
            string userInput = Console.ReadLine();
            
            //check for allowed sign
            while (true)
            {
                index = userInput.IndexOfAny(allowed, 0, userInput.Length);
                if (index == -1)
                {
                    Console.WriteLine("Wrong sign");
                    userInput = Console.ReadLine();
                    continue;
                }
                else
                {
                    break;
                }
            }

            //2.Get values a, b & sign
            for (int i = 0; i < userInput.Length; i++)
            {
                string current = userInput[i].ToString();
                if (i < index)
                {
                    a += current;
                }
                else if (i == index)
                {
                    sign = current;
                }
                else if (i > index)
                {
                    b += current;
                }    
            }

            //check for formatting issues
            string cleanA = a.Replace(" ", "");
            string cleanB = b.Replace(" ", "");
            double firstNumber = FirstNumberCheck(cleanA);
            double secondNumber = SecondNumberCheck(cleanB);

            //3.Return result
            switch (sign)
            {
                case "+":
                    {
                        Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                        break;
                    }
                case "-":
                    {
                        Console.WriteLine($"{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                        break;
                    }
                case "*":
                    {
                        Console.WriteLine($"{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                        break;
                    }
                case "/":
                    {
                        Console.WriteLine($"{firstNumber} / {secondNumber} = {firstNumber / secondNumber}");
                        break;
                    }
            }

            Console.ReadLine();
        }
    }
}

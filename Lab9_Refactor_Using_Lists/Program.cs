//Mina Stanton
//January 29, 2020
//Program description: This program will output student data based on the user selection. It will recognize
// invalid user inputs when the user requests information about students in a class.

using System;
using System.Collections.Generic;
namespace Lab9_Refactor_Using_Lists
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> students = new List<string> { "John", "Jane", "Jack", "Jill", "Jim" };
            List<string> city = new List<string> { "West Bloomfield", "Royal Oak", "Birmingham", "Bloomfield Hills", "Detroit" };
            List<string> favAnimal = new List<string> { "Dog", "Cat", "Horse", "Turtle", "Llama" };
            List<string> favDrink = new List<string> { "Dark and Stormy", "Moscow Mule", "Margarita", "Martini with extra olives", "Frose" };
            List<string> horoscope = new List<string> { "Libra", "Scorpio", "Cancer", "Virgo", "Capricorn" };
            List<string> favNumber = new List<string> { "7", "8", "2", "77", "89" };

            Console.WriteLine("Hello! Here is a list of students that you can find more information about or add another student.");
            bool userSelectOrAdd = true;
            while (userSelectOrAdd)
            {

                //printing the student names
                PrintElements(students);
                //validating selection
                int userSelect = ValidateSelection(students, "Enter the number or write the name of the student you would like to find out more about: (exp. 5 or type Jim) ");

                PrintInfoSelected(students[userSelect], city[userSelect], favAnimal[userSelect], favDrink[userSelect], horoscope[userSelect], favNumber[userSelect]);

                userSelectOrAdd = UserChoice("Enter \"s\" to select another student or \"a\" to add another student.", "s", "a");
                if (userSelectOrAdd == false)
                {
                    AddStudent(students, "Enter the students name: ");
                    AddStudent(city, "Enter the students city: ");
                    AddStudent(favAnimal, "Enter the students favorite animal: ");
                    AddStudent(favDrink, "Enter the students favorite drink: ");
                    AddStudent(horoscope, "Enter the students birth sign: ");
                    AddStudent(favNumber, "Enter the students favorite number: ");
                    userSelectOrAdd = UserChoice("\nWould you like to continue? (y/n)", "y", "n");
                }

            }
            Console.WriteLine("Ok, bye!");
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        //This method will print out the elements in a list
        public static void PrintElements(List<string> toPrint)
        {
            int j = 1;
            for (int i = 0; i < toPrint.Count; i++)
            {
                Console.WriteLine($"{j}. {toPrint[i]}");
                j++;
            }
        }
        //This method validates the selection of the user
        public static int ValidateSelection(List<string> list1, string message)
        {
            int userSelectedNum = 0;
            bool userContinue = true;
            while (userContinue)
            {
                userContinue = false;
                string userStudentSelected = GetUserInput(message);

                try
                {
                    if (userStudentSelected == list1[0])
                    {
                        userSelectedNum = 0;
                    }
                    else if (userStudentSelected == list1[1])
                    {
                        userSelectedNum = 1;
                    }
                    else if (userStudentSelected == list1[2])
                    {
                        userSelectedNum = 2;
                    }
                    else if (userStudentSelected == list1[3])
                    {
                        userSelectedNum = 3;
                    }
                    else if (userStudentSelected == list1[4])
                    {
                        userSelectedNum = 4;
                    }
                    else
                    {
                        userSelectedNum = int.Parse(userStudentSelected) - 1;
                        Console.WriteLine("You selected: " + list1[userSelectedNum]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid Numeric Entry!");
                    userContinue = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Entry!");
                    userContinue = true;
                }
            }
            return userSelectedNum;
        }

        public static void PrintInfoSelected(string name, string city, string favAnimal, string favDrink, string horoscope, string favNum)
        {
            bool userContinue = true;
            while (userContinue)
            {
                userContinue = false;
                string userSelect = GetUserInput("What would you like to know? (Enter \"city\", \"favorite animal\", \"favorite drink\", \"birth sign\" or \"favorite number\") ");
                if (userSelect == "city")
                {
                    Console.WriteLine($"{name}, lives in {city}.");
                }
                else if (userSelect == "favorite animal")
                {
                    Console.WriteLine($"{name}, favorite animal is {favAnimal}.");
                }
                else if (userSelect == "favorite drink")
                {
                    Console.WriteLine($"{name}, favorite drink is {favDrink}.");
                }
                else if (userSelect == "birth sign")
                {
                    Console.WriteLine($"{name}, is a {horoscope}.");
                }
                else if (userSelect == "favorite number")
                {
                    Console.WriteLine($"{name}, favorite number is {favNum}.");
                }
                else
                {
                    Console.WriteLine("Invalid entry");
                    userContinue = true;
                }

                userContinue = UserChoice($"Would you like to know more about {name}? (y/n)", "y", "n");
            }
        }
        //method to validate the user choice
        public static bool UserChoice(string message, string option1_True, string option2_False)
        {
            string choice = GetUserInput(message).ToLower();
            if (choice == option1_True)
            {
                return true;
            }
            else if (choice == option2_False)
            {
                return false;
            }
            else
            {
                return UserChoice("Invalid Entry!" + message, option1_True, option2_False);
            }
        }
        //method to add a student and validate the user inputs an actual string
        public static void AddStudent(List<string> list1, string message)
        {

            string input = GetUserInput(message);
            while (input == "")
            {
                AddStudent(list1, "You have to input something here! " + message);
            }
            list1.Add(input);
        }

    }


}




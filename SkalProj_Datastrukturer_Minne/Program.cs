using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Threading.Channels;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {

            //ToDo: Which condition stops the loop
            //ToDo: In both cases, look at the count and capacity of the list
            List<string> theList = new List<string>();
            while (true)
            {
                string input = Console.ReadLine();
                char nav = input[0];
                switch (nav)
                {
                    case '+':
                        theList.Add(input.Substring(1));
                        break;
                    case '-':
                        theList.Remove(input.Substring(1));
                        break;
                    default:
                        Console.WriteLine("Please use only + or -");
                        break;
                }
            }

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            Queue<string> peopleInLine = new Queue<string>();
            while (true)
            {
                //ToDo: Add check to see if null
                //Add switch case to return to main menu
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        peopleInLine.Enqueue(value);
                        break;
                    case '-':
                        peopleInLine.Dequeue();
                        break;
                    default:
                        Console.WriteLine("Please use only + or -");
                        break;
                }
                foreach (string p in peopleInLine)
                {
                    Console.WriteLine(p);
                    Console.WriteLine(peopleInLine.Peek());
                }
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            while (true) {
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);
                Stack<string> peopleInTheQueue = new Stack<string>();
                switch (nav)
                {
                    case '+':
                        peopleInTheQueue.Push(value);
                        break;
                    case '-':
                        peopleInTheQueue.Pop();
                        break;
                    case '*':
                        ReverseText(value);
                        break;
                    default:
                        Console.WriteLine("Please use only + or -");
                        break;
                }
                foreach (var item in peopleInTheQueue)
                {
                    Console.WriteLine(item);
                    Console.WriteLine(peopleInTheQueue.Count());
                }
            }

        }

        static string ReverseText(string value)
        {
            Stack<char> letters = new Stack<char>();

            while (value == null && value == " ")
            {
                Console.WriteLine("Please enter some input that you want reversed!");
            }

            //Loop over the string to add each charachter into our stack
            foreach (char c in value)
            {
                letters.Push(c);
                // Console.WriteLine(c);
                // Console.WriteLine(letters.Count);
            }

            string reversed = "";
            //While there are letters left in our stack append them to the new reversed string; The order is reversed because of the use of Pop method
            while (letters.Count > 0)
            {
                reversed += letters.Pop();
            }
            //Console.WriteLine(reversed);
            //Console.WriteLine(letters.Count);
            return reversed;
        }

        //ToDo: Refactor / try solving with recursion?
        static bool CheckParanthesis()
        {
            Parentheses curly = new Parentheses("curly", '{', '}');
            Parentheses round = new Parentheses("round", '(', ')');
            Parentheses square = new Parentheses("square", '[', ']');

            //Adding all parentheses to a list
            List<Parentheses> p = new List<Parentheses> 
            {
                round,
                curly,
                square
            };

            //Get the input from the user
            string input = Console.ReadLine();
            List<char> filtered = new List<char>();

            //Filter out all other characters. Only parentheses left
            foreach (var c in input)
            {
                if (c == p[0].Opening || c == p[0].Closing ||  c == p[1].Opening || c == p[1].Closing || c == p[2].Opening || c == p[2].Closing) filtered.Add(c);
            }

            //If there are no chars left or the number of chars left is odd return false
            if (filtered.Count == 0 || filtered.Count % 2 != 0)
            {
                Console.WriteLine("Not a valid parentheses input.");
                return false;
            };

            List<char> result = filtered;

            //While there are characters left to compare do the following 
            while (result.Count > 0)
            {
                //Access the returned values
                var (updatedInput, isMatching) = CheckFirstAndLast(result, p);
                result = updatedInput;

                // If we got no match return false
                if (!isMatching) {
                    Console.WriteLine("Parentheses were not a match.");
                    return false;
                };
            }
            //Printing for my debugging purposes
            Console.WriteLine("All parentheses were matched.");
            return true; 
        }

        //An extra method that checks the first and the last char and returns a Tuple 
        static (List<char> Input, bool IsMatching) CheckFirstAndLast(List<char> input, List<Parentheses> p) 
        {
           // int lastIndex = (input.Count - 1);
            bool isMatching = false;

            // A stop condition when all parentheses were matched
            if (input.Count == 0) {
                isMatching = true;
                return (input, isMatching);
            };

            //Loop through all of our parentheses
            foreach (var parentheses in p)
            {
                //Check if the first and the last characters are a match and a valid pair
                if (parentheses.Opening == input[0] && parentheses.Closing == input[input.Count - 1])
                {
                    //Remove the first and the last char
                    input.RemoveAt(0);
                    input.RemoveAt(input.Count - 1);
                    // Set isMatching to true and return it together with the edited input
                    isMatching = true;
                    return (input, isMatching);
                }
            }
            return (input, isMatching);
        }  
    }
}


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

        //ToDo: Refactor / Implement a better solution with stack / try solving with recursion 
        static bool CheckParanthesis()
        {
            //Create data structure with all kinds of parantheses
            //Loop through the list of parentheses and compare first to last and make my way inwards
            //As soon as not matched we return false
            //Once we reached the middle if they all match we return true

            Parentheses p = new Parentheses();
            string input = Console.ReadLine();
            //Loop the input string and filter out any other characters
            string filtered = "";
            foreach (char c in input) 
            {
                if (c == p.Round[0] || c == p.Round[1] || c == p.Curly[0] || c == p.Curly[1] || c == p.Square[0] || c == p.Square[1])  filtered += c;
            }

            if (filtered == null || filtered == "" || filtered.Length % 2 != 0) 
            {
                Console.WriteLine("Not a valid parentheses input");
                return false;
            };
            bool isMatched = false;

            for (int i = 0; i < filtered.Length/2; i++)
            {             
                switch (filtered[i])
                {
                    case '(':
                        isMatched = filtered[filtered.Length - i - 1] == ')' ? true : false;
                        if(!isMatched) return isMatched;
                        break;
                    case '[':
                        isMatched = filtered[filtered.Length - i - 1] == ']' ? true : false;
                        if (!isMatched) return isMatched;
                        break;
                    case '{':
                        isMatched = filtered[filtered.Length - i - 1] == '}' ? true : false;
                        if (!isMatched) return isMatched;
                        break;
                    default:
                        isMatched = false;
                        break;
                }
            }
            return isMatched;
        }
    }
}


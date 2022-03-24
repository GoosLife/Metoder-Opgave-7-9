using System;

namespace Metoder_Opgave_7_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Exercise 7

            Console.WriteLine("EXERCISE 7: \n");

            int[] numbers = new int[9];
            FillArray(numbers);

            Console.WriteLine("Before doubling, the fifth index was: " + numbers[4]);

            DoubleFifthIndex(numbers);

            Console.WriteLine("After doubling, the fifth index is: " + numbers[4]);

            Console.ReadKey();

            #endregion

            #region Exercise 8

            Console.Clear();

            Console.WriteLine("EXERCISE 8: \n");

            // As specified in exercise 8, I will be using lists here rather than arrays
            List<int> listeB = new List<int>();

            FillList(listeB); // Populate the list with whole numbers from 1-20.

            // Output content of list
            Console.WriteLine("Contents of list after filling the list: \n");
            Console.WriteLine(PrintList(listeB));

            RemoveMultiplesOfThree(listeB); // Remove all numbers from list that are multiples of 3.

            // Output new content of list
            Console.WriteLine("\nContents of list after removing multiples of three: \n");
            Console.WriteLine(PrintList(listeB));

            ChangeThirdIndexToSeventeen(listeB); // Change 3rd index to hold the value of 17.

            // Output new content of list
            Console.WriteLine("\nContent of list after changing third index to 17: \n");
            Console.WriteLine(PrintList(listeB));

            // Make a copy of listeB and reverse it
            List<int> reversedB = listeB;
            reversedB.Reverse();

            // Print contents of the reversed list
            Console.WriteLine("Content of listeB reversed: \n");
            Console.WriteLine(PrintList(reversedB));

            Console.ReadKey();

            #endregion

            #region Exercise 9

            Console.Clear();

            Console.WriteLine("EXERCISE 9: \n");

            int[] winningTicket = GenerateWinningTicket();

            Console.WriteLine("Indtast dine 7 tal mellem 1 og 20. Tryk enter efter hvert tal: ");

            int[] userTicket = GenerateUserTicket();

            int correctNumbers = CompareTickets(winningTicket, userTicket);

            Console.WriteLine(OutputResult(winningTicket, userTicket, correctNumbers));

            #endregion
        }

        #region Exercise 7 Methods
        private static int[] FillArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i + 1 % 2 == 0)
                {
                    arr[i] = i + 1;
                }
            }

            return arr;
        }

        private static int[] DoubleFifthIndex(int[] arr)
        {
            int currentValue = LoopToFifthIndex(arr);
            arr[4] = currentValue * 2;

            return arr;
        }

        // According to the exercise, I must use a loop to find the value of the fifth index.

        private static int LoopToFifthIndex(int[] arr)
        {
            int output = -1;

            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    output = arr[i];
                }
            }

            return output;
        }

        #endregion

        #region Exercise 8 Methods

        private static string PrintList(List<int> list)
        {
            string output = "";

            for (int i = 0; i < list.Count; i++)
            {
                output += list[i] + "\n";
            }

            return output;
        }

        private static List<int> FillList(List<int> list)
        {
            for (int i = 0; i < 20; i++)
            {
                list.Add(i + 1);
            }

            return list;
        }

        private static List<int> RemoveMultiplesOfThree(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 3 == 0)
                {
                    list.RemoveAt(i);
                }
            }

            return list;
        }

        private static List<int> ChangeThirdIndexToSeventeen(List<int> list)
        {
            list[2] = 17;

            return list;
        }

        #endregion

        #region Exercise 9 Methods

        private static int[] GenerateWinningTicket()
        {
            int[] winningTicket = new int[7];

            for (int i = 0; i < winningTicket.Length; i++)
            {
                do
                {
                    Random rng = new Random();
                    int numberToAdd = rng.Next(1, 21);

                    if (!IsDuplicate(winningTicket, numberToAdd)) // Ensure duplicate numbers won't get drawn
                    {
                        winningTicket[i] = numberToAdd;
                    }
                } while (winningTicket[i] == 0);
            }

            return winningTicket;
        }

        private static int[] GenerateUserTicket()
        {
            int[] userTicket = new int[7];
            string input;

            for (int i = 0; i < userTicket.Length; i++)
            {
                do
                {
                    bool isDuplicate = false;

                    Console.WriteLine("Du har valgt {0} tal mellem 1 og 20.", i); // Lets the user know how many valid numbers they've currently inputted.
                    input = Console.ReadLine();

                    int numberToAdd;
                    int.TryParse(input, out numberToAdd);

                    if (!IsDuplicate(userTicket, numberToAdd) && // Check users number isn't a duplicate, and is between 1 and 20.
                        numberToAdd > 0 && numberToAdd <= 20)
                    {
                        userTicket[i] = numberToAdd; // Add valid number.
                    }

                } while (userTicket[i] == 0);
            }

            return userTicket;
        }

        private static int CompareTickets(int[] winningTicket, int[] userTicket)
        {
            int correctNumbers = 0;

            for (int i = 0; i < userTicket.Length; i++)
            {
                for (int j = 0; j < winningTicket.Length; j++)
                {
                    if (userTicket[i] == winningTicket[j])
                        correctNumbers++;
                }
            }

            return correctNumbers;
        }

        private static bool IsDuplicate(int[] arr, int numberToAdd)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == numberToAdd)
                    return true;
            }
            return false;
        }

        private static string OutputResult(int[] winningTicket, int[] userTicket, int correctNumbers)
        {
            Array.Sort(winningTicket);
            Array.Sort(userTicket);

            Console.WriteLine("Vindetallene er: \n");
            for (int i = 0; i < winningTicket.Length; i++)
            {
                Console.Write(winningTicket[i] + " ");
            }

            Console.WriteLine("\n");

            Console.WriteLine("Dine tal var: \n");
            for (int i = 0; i < userTicket.Length; i++)
            {
                Console.Write(userTicket[i] + " ");
            }

            switch (correctNumbers)
            {
                case 0:
                case 1:
                    return "Du vandt ingenting.";
                case 2:
                    return "Du har vundet 50 kr.";
                case 3:
                    return "Du har vundet 100 kr.";
                case 4:
                    return "Du har vundet 250 kr.";
                case 5:
                    return "Du har vundet 1000 kr.";
                case 6:
                    return "Du har vundet 10.000 kr.";
                case 7:
                    return "Du har sikkert snydt, ryk direkte i fængsel.";
                default:
                    throw new ArgumentOutOfRangeException("User had less than 0 or more than 7 out of 7 correct numbers.");
            }
        }

        #endregion
    }
}
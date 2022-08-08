using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpString
{
    internal class BasicAlgorithms
    {
        public static void CheckIfWithin100Or200()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    var myArray = enteredString.Split(' ');
                    if (myArray.Length != 1)
                    {
                        Console.WriteLine("Only 1 parameter allowed");
                    }
                    else
                    {
                        int.TryParse(myArray[0], out int value);
                        if (Math.Abs(value - 100) <= 10 || Math.Abs(value - 200) <= 10)
                        {
                            Console.WriteLine("number within range");
                        }
                        else
                        {
                            Console.WriteLine("number outside range");
                        }
                    }
                }
            } while (enteredString != string.Empty);
        }

        public static void CheckInArray()
        {
            Console.WriteLine(test(new[] { 1, 2, 9, 3 }, 3));
            Console.WriteLine(test(new[] { 1, 2, 3, 4, 5, 6 }, 2));
            Console.WriteLine(test(new[] { 1, 2, 2, 3 }, 9));
            Console.ReadLine();

            static bool test(int[] numbers, int n)
            {
                return numbers.Length < 4 ? numbers.Contains(n) : numbers.Take(4).Contains(n);
            }
        }

        public static void IsAnagram()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    var myArray = enteredString.Split(' ');
                    if (myArray.Length != 2)
                    {
                        Console.WriteLine("Enter exactly 2 parameters");
                    }
                    else
                    {
                        var charArray1 = myArray[0].ToLower().ToCharArray();
                        Array.Sort(charArray1);
                        var newWord1 = new string(charArray1);

                        var charArray2 = myArray[1].ToLower().ToCharArray();
                        Array.Sort(charArray2);
                        var newWord2 = new string(charArray2);

                        if (newWord1 == newWord2)
                        {
                            Console.WriteLine("Its an Anagram");
                        }
                        else
                        {
                            Console.WriteLine("Its not");
                        }
                    }
                }
            } while (enteredString != string.Empty);
        }

        public static void CheckPalindrom()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    if (IsPalindrom(enteredString))
                    {
                        Console.WriteLine($"{enteredString} is a palindrom");
                    }
                    else
                    {
                        Console.WriteLine($"{enteredString} is not a palindrom");
                    }
                }
            } while (enteredString != string.Empty);

            static bool IsPalindrom(string word)
            {
                int min = 0;
                int max = word.Length - 1;

                while (true)
                {
                    if (min > max)
                    {
                        return true;
                    }

                    if (word[min] != word[max])
                    {
                        return false;
                    }
                    min++;
                    max--;
                }
            }
        }

        public static void MergeArray()
        {
            int[] numArray1 = { 4, 1, 8 };
            int[] numArray2 = { 5, 2, 9, 0, 1 };

            var mergedArray = new int[numArray1.Length + numArray2.Length];

            Array.Sort(numArray1);
            Array.Sort(numArray2);

            var numIndex1 = 0;
            var numIndex2 = 0;
            var mergedArrayIndex = 0;
            while (numIndex1 < numArray1.Length && numIndex2 < numArray2.Length)
            {
                if (numArray1[numIndex1] < numArray2[numIndex2])
                {
                    mergedArray[mergedArrayIndex++] = numArray1[numIndex1++];
                }
                else
                {
                    mergedArray[mergedArrayIndex++] = numArray2[numIndex2++];
                }
            }

            if (numIndex1 < numArray1.Length)
            {
                for (int i = numIndex1; i < numArray1.Length; i++)
                {
                    mergedArray[mergedArrayIndex++] = numArray1[numIndex1];
                }
            }
            else if (numIndex2 < numArray2.Length)
            {
                for (int i = numIndex2; i < numArray2.Length; i++)
                {
                    mergedArray[mergedArrayIndex++] = numArray2[numIndex2];
                }
            }

            foreach (var num in mergedArray)
            {
                Console.WriteLine(num);
            }
        }

        public static void Factorial()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a number : ");
                enteredString = Console.ReadLine();

                if (enteredString != null && enteredString != string.Empty)
                {
                    int.TryParse(enteredString, out int num);
                    Console.WriteLine($"Factorial : {GetFactorial(num)}");
                }
            } while (enteredString != string.Empty);

            double GetFactorial(int num)
            {
                double factorialNum = num;

                for (int i = num - 1; i > 0; i--)
                {
                    factorialNum *= i;
                }
                return factorialNum;
            }
        }

        public static void ArmstrongNumber()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a number : ");
                enteredString = Console.ReadLine();

                if (enteredString != null && enteredString != string.Empty)
                {
                    int.TryParse(enteredString, out int num);
                    Console.WriteLine($"Is armstrong : {isArmstrong(num)}");
                }
            } while (enteredString != string.Empty);

            printAllArmStrongNumbers();

            void printAllArmStrongNumbers()
            {
                for (int i = 111; i < 999; i++)
                {
                    if (isArmstrong(i))
                    {
                        Console.WriteLine(i);
                    }
                }
            }

            bool isArmstrong(int number)
            {
                int sum = 0;
                for (int i = number; i > 0; i = i / 10)
                {
                    var reminder = i % 10;
                    sum = sum + reminder * reminder * reminder;
                }
                if (sum == number)
                {
                    return true;
                }
                return false;
            }
        }

        public static void FibonacciSeries()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a number : ");
                enteredString = Console.ReadLine();

                if (enteredString != null && enteredString != string.Empty)
                {
                    int.TryParse(enteredString, out int num);
                    Console.WriteLine($"Fibonacci Iterative : {fibonacciIterative(num)}");
                    Console.WriteLine($"Fibonacci recursive : {fibonacciRecursive(num)}");
                }
            } while (enteredString != string.Empty);

            int fibonacciIterative(int num)
            {
                int firstNum = 0, secondNum = 1, result = 0;
                if (num == 0) return 0;
                if (num == 1) return 1;
                for (int i = 2; i <= num; i++)
                {
                    result = firstNum + secondNum;
                    firstNum = secondNum;
                    secondNum = result;
                }
                return result;
            }

            int fibonacciRecursive(int num)
            {
                if (num == 0) return 0;
                if (num == 1) return 1;
                return fibonacciRecursive(num - 1) + fibonacciRecursive(num - 2);
            }
        }

        public static void GcdAndLcm()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a number : ");
                enteredString = Console.ReadLine();

                if (enteredString != null && enteredString != string.Empty)
                {
                    var myArray = enteredString.Split(' ');
                    if (myArray.Length != 2)
                    {
                        Console.WriteLine("Enter exactly 2 parameters");
                    }
                    else
                    {
                        int.TryParse(myArray[0], out int num1);
                        int.TryParse(myArray[1], out int num2);
                        Console.WriteLine($"GCD and LCM method1:");
                        Method1(num1, num2);
                        Console.WriteLine($"GCD and LCM method2:");
                        Method2(num1, num2);
                    }
                }
            } while (enteredString != string.Empty);

            void Method1(int num1, int num2)
            {
                var gcd1 = GCDMethod1(num1, num2);
                Console.WriteLine($"GCD: {gcd1}, LCM: {LCM(num1, num2, gcd1)}");
            }

            void Method2(int num1, int num2)
            {
                var gcd2 = GCDMethod2(num1, num2);
                Console.WriteLine($"GCD: {gcd2}, LCM: {LCM(num1, num2, gcd2)}");
            }
            int GCDMethod1(int num1, int num2)
            {
                while (num1 != num2)
                {
                    if (num1 > num2) num1 -= num2;
                    if (num2 > num1) num2 -= num1;
                }
                return num1;
            }

            int GCDMethod2(int num1, int num2)
            {
                int reminder = 0;
                while (num2 != 0)
                {
                    reminder = num1 % num2;
                    num1 = num2;
                    num2 = reminder;
                }
                return num1;
            }

            int LCM(int num1, int num2, int gcd)
            {
                return (num1 * num2) / gcd;
            }
        }

        public static void PrimeNumber()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a number : ");
                enteredString = Console.ReadLine();

                if (enteredString != null && enteredString != string.Empty)
                {
                    int.TryParse(enteredString, out int num);
                    var isPrime = true;
                    for (int i = 2; i <= num / 2; i++)
                    {
                        if (num % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    Console.WriteLine($"Is prime: {isPrime}");
                }
            } while (enteredString != string.Empty);
        }

        public static void BinaryGap()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a number : ");
                enteredString = Console.ReadLine();

                if (enteredString != null && enteredString != string.Empty)
                {
                    var longestGap = 0;
                    var gapCount = 0;
                    var beginCount = false;
                    var endCount = false;
                    int.TryParse(enteredString, out int num);

                    var binaryString = Convert.ToString(num, 2);
                    Console.WriteLine("Binary : " + binaryString);
                    foreach (var ch in binaryString)
                    {
                        if (ch == '1')
                        {
                            if (beginCount)
                            {
                                endCount = true;
                            }
                            else
                            {
                                beginCount = true;
                            }
                            beginCount = true;
                        }
                        else
                        {
                            gapCount++;
                        }
                        if (endCount)
                        {
                            if (gapCount > longestGap)
                            {
                                longestGap = gapCount;
                            }
                            gapCount = 0;
                        }
                    }
                    Console.WriteLine("Gap : " + longestGap);
                }
            } while (enteredString != string.Empty);

        }

        public static void SmallestInteger()
        {
            int[] a = new int[] { 1, 2, 3, 6, 4 };
            var smallestInt = 1;
            while (true)
            {
                if (a.Contains(smallestInt))
                {
                    smallestInt++;
                }
                else
                {
                    Console.WriteLine("Smallest int not in array: " + smallestInt);
                    break;
                }
            }
        }

        public static void BalloonTest()
        {
            string? S;
            do
            {
                Console.Write("Enter a string : ");
                S = Console.ReadLine();

                if (S != null && S != string.Empty)
                {
                    var balloon = "ABLLNOO"; //"BALLOON" text in ascending order;
                    var removedChars = new StringBuilder();
                    var removedCharCount = 0;

                    var myString = string.Concat(S.OrderBy(ch => ch)); //Sort input string;
                    var moves = 0;
                    var isRemoved = false;
                    while (myString != "ABLLNOO" && myString != "")
                    {

                        for (var i = 0; i < myString.Length; i++)
                        {
                            var charIndex = balloon.IndexOf(myString[i]);
                            if (charIndex == -1)
                            {
                                removedChars.Append(myString[i]);
                                myString = myString.Remove(i, 1);
                                removedCharCount++;
                                isRemoved = true;
                                i--;
                            }
                            else
                            {
                                balloon = balloon.Remove(charIndex, 1);
                            }
                        }
                        if (!isRemoved)
                        {
                            break;
                        }
                    }
                    moves = removedCharCount / 7;
                    if (removedCharCount % 7 > 0)
                    {
                        moves++;
                    }
                    if (myString == "")
                    {
                        moves = 0;
                    }
                    Console.WriteLine("Number of moves: " + moves);
                }
            } while (S != string.Empty);
        }

        public static void SeatAllocation()
        {
            string? S;
            string? N;
            do
            {
                Console.Write("Enter Number of rows : ");
                N = Console.ReadLine();
                Console.Write("Enter Booked seats : ");
                S = Console.ReadLine();
                if (N != null && N != string.Empty)
                {
                    Console.WriteLine("Allocations: " + SeatReservation(int.Parse(N), S));
                }
            } while (N != string.Empty);
        }

        private static int SeatReservation(int N, string S)
        {
            var bs = S.Split(' ');
            var allocation = 0;
            var seats = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };
            //if (bs.Length == 0) return 0;
            //var bookedSeats = bs.OrderBy(x => x);
            var bookedSeatsCollection = new List<SeatCode>();
            foreach (var bookedSeat in bs)
            {
                var nums = string.Empty;
                var chars = string.Empty;

                if (bookedSeat == "") continue;

                foreach (var ch in bookedSeat)
                {
                    if (char.IsDigit(ch)) nums = nums + ch;
                    else chars = chars + ch;
                }

                bookedSeatsCollection.Add(new SeatCode()
                {
                    rowNumber = Convert.ToInt16(nums),
                    seatNumber = chars
                });
            }
            var bookedSeats = bookedSeatsCollection.OrderBy(x => x.rowNumber).ThenBy(x => x.seatNumber).ToList();
            for (int i = 1; i <= N; i++)
            {
                var membersCount = 0;
                var bookedRowSeats = bookedSeats.Where(x => x.rowNumber == i).Select(x => x.seatNumber).ToList();
                if (bookedRowSeats.Count() == 0)
                {
                    allocation += 2;
                }
                else
                {
                    var GroupACount = 0;
                    var GroupBCount = 0;
                    var GroupCCount = 0;

                    for (int j = 0; j < 10; j++)
                    {
                        if (!bookedRowSeats.Contains(seats[j]))
                        {
                            switch (j)
                            {
                                case 0:
                                case 1:
                                case 2:
                                    GroupACount++;
                                    membersCount++;
                                    break;
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                    if (GroupACount == 1)
                                    {
                                        GroupACount = 0;
                                        membersCount = 0;
                                    }
                                    GroupBCount++;
                                    membersCount++;
                                    break;
                                default:
                                    if (GroupBCount == 1)
                                    {
                                        GroupBCount = 0;
                                        membersCount = 0;
                                    }
                                    GroupCCount++;
                                    membersCount++;
                                    break;

                            }

                        }
                        else
                        {
                            membersCount = 0;
                            GroupACount = 0;
                            GroupBCount = 0;
                            GroupCCount = 0;
                        }
                        if (membersCount == 4)
                        {
                            if (GroupBCount == 1)
                            {
                                GroupACount -= 1;
                                membersCount -= 1;
                            }
                            else if (GroupCCount == 1)
                            {
                                GroupBCount -= 1;
                                membersCount -= 1;
                            }
                            else
                            {
                                allocation++;
                                membersCount = 0;
                            }
                        }
                    }

                    //if (bookedRowSeats.Contains(seats[1]))
                    //{
                    //    //Ignore abc
                    //}
                    //if(bookedRowSeats.Contains(seats[8]))
                    //{
                    //    //Ignore HJK
                    //}
                }
            }
            return allocation;
        }

        public class SeatCode
        {
            public int rowNumber = 0;
            public string seatNumber = string.Empty;
        }
    }
}

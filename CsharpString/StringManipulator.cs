namespace CsharpString
{
    internal static class StringManipulator
    {
        public static void WriteString()
        {
            Console.Write("Enter a string: ");
            var enteredString = Console.ReadLine();
            Console.WriteLine(enteredString);
        }

        public static void GetStringLength()
        {
            string? enteredString;
            do
            {
                var count = 0;
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    foreach (char c in enteredString)
                    {
                        count++;
                    }
                    Console.WriteLine("String length: " + count);
                }
            } while (enteredString != string.Empty);
        }

        public static void SeparateCharInString()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    foreach (char c in enteredString)
                    {
                        Console.Write($"{c} ");
                    }
                    Console.WriteLine();
                }
            } while (enteredString != string.Empty);
        }

        public static void ReverseString()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    for (int i = enteredString.Length - 1; i >= 0; i--)
                    {
                        Console.Write($"{enteredString[i]} ");
                    }
                    Console.WriteLine();
                }
            } while (enteredString != string.Empty);
        }

        public static void CountWords()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    var myArray = enteredString.Split(' ');
                    Console.Write($"Word Count: {myArray.Length}");
                    Console.WriteLine();
                }
            } while (enteredString != string.Empty);
        }

        public static void CompareStrings()
        {
            string? firstString;
            string? secondString;
            do
            {
                Console.Write("Enter 1st string: ");
                firstString = Console.ReadLine();
                Console.Write("Enter 2st string: ");
                secondString = Console.ReadLine();
                if (firstString == secondString)
                {
                    Console.WriteLine("Both are same");
                }
                else
                {
                    Console.WriteLine("strings are different");
                }
            } while (firstString != string.Empty);
        }

        public static void CountStrNumSpl()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    int alphabets = 0;
                    int numbers = 0;
                    int specialChars = 0;
                    for (int i = 0; i < enteredString.Length; i++)
                    {
                        if ((enteredString[i] >= 'a' && enteredString[i] <= 'z') || (enteredString[i] >= 'A' && enteredString[i] <= 'Z'))
                        {
                            alphabets++;
                        }
                        else if (enteredString[i] >= '0' && enteredString[i] <= '9')
                        {
                            numbers++;
                        }
                        else
                        {
                            specialChars++;
                        }
                    }
                    Console.WriteLine($"Alphabets: {alphabets}, Number: {numbers}, Special Characters: {specialChars}");
                }
            } while (enteredString != string.Empty);
        }

        public static void CopyString()
        {
            string str1;
            int i, l;

            Console.Write("\n\nCopy one string into another string :\n");
            Console.Write("-----------------------------------------\n");
            Console.Write("Input the string : ");
            str1 = Console.ReadLine();

            l = str1.Length;
            string[] str2 = new string[l];

            /* Copies string1 to string2 character by character */
            i = 0;
            while (i < l)
            {
                string tmp = str1[i].ToString();
                str2[i] = tmp;
                i++;
            }
            Console.Write("\nThe First string is : {0}\n", str1);
            Console.Write("The Second string is : {0}\n", string.Join("", str2));
            Console.Write("Number of characters copied : {0}\n\n", i);
        }

        public static void CountVowelsConsonants()
        {
            var vowelList = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            var consonentList = new List<char>() { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z', 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z' };
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    int vowels = 0;
                    int consonants = 0;
                    for (int i = 0; i < enteredString.Length; i++)
                    {
                        if (vowelList.Contains(enteredString[i]))
                        {
                            vowels++;
                        }
                        else if (consonentList.Contains(enteredString[i]))
                        {
                            consonants++;
                        }
                    }
                    Console.WriteLine($"Vowels: {vowels}, Consonants: {consonants}");
                }
            } while (enteredString != string.Empty);
        }

        public static void GetMaximumOccuringCharacter()
        {
            string? enteredString;
            do
            {
                int[] ch = new int[255];
                for (int i = 0; i < ch.Length; i++)
                {
                    ch[i] = 0;
                }

                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    for (int i = 0; i < enteredString.Length; i++)
                    {
                        var ascii = (int)enteredString[i];
                        ch[ascii]++;
                    }

                    var max = 0;
                    for (var i = 0; i < 255; i++)
                    {
                        if (ch[i] > ch[max])
                        {
                            max = i;
                        }
                    }

                    Console.WriteLine($"Maximum occuring character {(char)max}.  Count - {ch[max]}");
                }
            } while (enteredString != string.Empty);
        }

        public static void SortString()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    var myArray = enteredString.ToCharArray();
                    for (int i = 0; i < myArray.Length - 1; i++)
                    {
                        for (int j = i + 1; j < myArray.Length; j++)
                        {
                            if (myArray[i] > myArray[j])
                            {
                                var temp = myArray[i];
                                myArray[i] = myArray[j];
                                myArray[j] = temp;
                            }
                        }
                    }

                    Console.WriteLine($"Sorted string : {string.Join("",myArray)}");
                }
            } while (enteredString != string.Empty);
        }

        public static void BubbleSort()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                if (enteredString != null && enteredString != string.Empty)
                {
                    var myArray = enteredString.Split(" ");
                    for (int i = 0; i < myArray.Length - 1; i++)
                    {
                        for (int j = 0; j < myArray.Length - i - 1; j++)
                        {
                            if (myArray[j].CompareTo(myArray[j+1]) > 0)
                            {
                                var temp = myArray[j];
                                myArray[j] = myArray[j+1];
                                myArray[j+1] = temp;
                            }
                        }
                    }

                    Console.WriteLine("Sorted string: ");
                    foreach(var str in myArray)
                    {
                    Console.WriteLine(str);
                    }
                }
            } while (enteredString != string.Empty);
        }

        public static void RemoveDuplicateChars()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();
                var charList = string.Empty;

                if (enteredString != null && enteredString != string.Empty)
                {
                    foreach(var element in enteredString)
                    {
                        if(!charList.Contains(element))
                        {
                            charList += element;
                        }
                    }
                    Console.WriteLine($"String without duplicate chars: {string.Join("", charList)}");
                }
            } while (enteredString != string.Empty);
        }

        public static void CheckIsogram()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();

                if (enteredString != null && enteredString != string.Empty)
                {
                    Console.WriteLine($"Is {enteredString} an Isogram? : {enteredString.ToLower().Distinct().Count() == enteredString.Count()}");
                }
            } while (enteredString != string.Empty);
        }

        public static void PascalCase()
        {
            string? enteredString;
            do
            {
                Console.Write("Enter a string: ");
                enteredString = Console.ReadLine();

                if (enteredString != null && enteredString != string.Empty)
                {
                    Console.WriteLine($"After converstion: {string.Join(" ", enteredString.Split(" ").Select(s => char.ToUpper(s[0]) + s.Substring(1)))}");
                }
            } while (enteredString != string.Empty);
        }
    }
}

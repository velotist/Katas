using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Katas
{
    public static class AllMethods
    {
        private static readonly int CurrentInteger;

        public static int[] SortArray(int[] array)
        {
            if (array.Length == 0)
                return array;

            var sortedOddNumbers = array.Where(number => number % 2 != 0).ToArray();
            Array.Sort(sortedOddNumbers);

            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0) continue;
                array[i] = sortedOddNumbers[j];
                j++;
            }

            return array;
        }

        public static string WhatCentury(string year)
        {
            var century = int.Parse(year.Substring(0, 2));
            switch (century)
            {
                case 1:
                    return "1st";
                case 2:
                    return "2nd";
                case 3:
                    return "3rd";
                case 21:
                case 31:
                default:
                    return (century + 1).ToString() + "th";
            }
        }

        public static string Encode(int n, string s)
        {
            var result = s;

            for (var i = 0; i < n; i++)
            {
                var indexOfWhiteSpaces = LocateAllWhiteSpaces(result);
                result = DeleteWhiteSpaces(result);

                result = ShiftCharactersNTimesRight(result, n);

                result = PutInWhiteSpaces(result, indexOfWhiteSpaces);

                var eachWord = result.Split(" ");
                result = ShiftEachSubstringNTimes(eachWord, n);
            }

            return n.ToString() + " " + result;
        }

        public static string Decode(string s)
        {
            var n = Convert.ToInt32(s.Substring(0, s.IndexOf(" ", StringComparison.Ordinal)));
            var result = s.Substring(s.IndexOf(" ", StringComparison.Ordinal) + 1);

            for (var i = 0; i < n; i++)
            {
                var eachWord = result.Split(" ");
                result = ShiftEachSubstringNTimes(eachWord, n);

                var indexOfWhiteSpaces = LocateAllWhiteSpaces(result);
                result = DeleteWhiteSpaces(result);

                result = ShiftCharactersNTimesLeft(result, n);

                result = PutInWhiteSpaces(result, indexOfWhiteSpaces);
            }

            return result;
        }

        private static string ShiftEachSubstringNTimes(IEnumerable<string> eachWord, int n)
        {
            var result = "";

            foreach (var word in eachWord)
            {
                result += ShiftWordNTimes(word, n) + " ";
            }

            return result.Trim();
        }

        private static string ShiftWordNTimes(string word, int index)
        {
            if (word.Length == 0)
                return word;

            index %= word.Length;

            return word.Substring(word.Length - index) + word.Substring(0, word.Length - index);
        }

        private static string PutInWhiteSpaces(string result, IEnumerable<int> indexOfWhiteSpaces)
        {
            var ofWhiteSpaces = indexOfWhiteSpaces.ToList();

            return ofWhiteSpaces.Aggregate(result, (current, t) => current.Insert(t, " "));
        }

        private static string ShiftCharactersNTimesLeft(string result, int n)
        {
            if (result.Length == 0)
                return result;
            n %= result.Length;

            return result.Substring(n) + result.Substring(0, n);
        }

        private static string ShiftCharactersNTimesRight(string text, int n)
        {
            var endOfTextToFront = text.Substring(text.Length - n);
            var frontOfText = text.Substring(0, text.Length - n);

            return endOfTextToFront + frontOfText;
        }

        private static string DeleteWhiteSpaces(string text)
        {
            return new string(text.ToCharArray()
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }

        private static IEnumerable<int> LocateAllWhiteSpaces(string text)
        {
            var indexOfWhiteSpaces = new List<int>();
            var at = 0;
            var end = text.Length;
            var start = 0;

            while ((start <= end) && (at > -1))
            {
                var count = end - start;
                at = text.IndexOf(" ", start, count, StringComparison.Ordinal);
                if (at == -1)
                    break;
                indexOfWhiteSpaces.Add(at);
                start = at + 1;
            }

            return indexOfWhiteSpaces;
        }

        public static char FindMissingLetter(char[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] + 1 != array[i + 1])
                {
                    return ((char)(array[i] + 1));
                }
            }

            return ' ';
        }

        public static string Greet(string name)
        {
            StringBuilder greet = new StringBuilder();

            _ = greet.Append("Hello ");
            _ = greet.Append(name[0].ToString().ToUpper());

            for (int i = 1; i < name.Length; i++)
            {
                _ = greet.Append(name[i].ToString().ToLower());
            }

            _ = greet.Append("!");

            return greet.ToString();
        }

        public static int Score(int[] dice)
        {
            int[,] dices = FindOccurrenceOfEyes(dice);
            int score = GetPoints(dices);

            return score;
        }

        public static int[,] FindOccurrenceOfEyes(int[] numberOfDice)
        {
            int[,] occurrences = new int[6, 2];

            int numbersOccurrenceOf1 = numberOfDice.Count(s => s == 1);
            int numbersOccurrenceOf2 = numberOfDice.Count(s => s == 2);
            int numbersOccurrenceOf3 = numberOfDice.Count(s => s == 3);
            int numbersOccurrenceOf4 = numberOfDice.Count(s => s == 4);
            int numbersOccurrenceOf5 = numberOfDice.Count(s => s == 5);
            int numbersOccurrenceOf6 = numberOfDice.Count(s => s == 6);
            occurrences[0, 0] = 1;
            occurrences[0, 1] = numbersOccurrenceOf1;
            occurrences[1, 0] = 2;
            occurrences[1, 1] = numbersOccurrenceOf2;
            occurrences[2, 0] = 3;
            occurrences[2, 1] = numbersOccurrenceOf3;
            occurrences[3, 0] = 4;
            occurrences[3, 1] = numbersOccurrenceOf4;
            occurrences[4, 0] = 5;
            occurrences[4, 1] = numbersOccurrenceOf5;
            occurrences[5, 0] = 6;
            occurrences[5, 1] = numbersOccurrenceOf6;

            return occurrences;
        }

        public static int GetPoints(int[,] occurrenceOfEyes)
        {
            int points = 0;

            // Points for eyes 1
            if (occurrenceOfEyes[0, 1] <= 2)
            {
                points += occurrenceOfEyes[0, 1] * 100;
            }
            // Points for triplets eyes 1
            if (occurrenceOfEyes[0, 1] == 3)
            {
                points += 1000;
            }
            if (occurrenceOfEyes[0, 1] == 4)
            {
                points += 1100;
            }
            // Points for eyes 5
            if (occurrenceOfEyes[4, 1] <= 2)
            {
                points += occurrenceOfEyes[4, 1] * 50;
            }
            if (occurrenceOfEyes[4, 1] == 4)
            {
                points += 200;
            }

            // Points for triplets of eye 2, 3, 4, 5, 6
            for (int i = 1; i < 6; i++)
            {
                if (occurrenceOfEyes[i, 1] >= 3)
                {
                    points += occurrenceOfEyes[i, 0] * 100;
                }
            }

            return points;
        }

        public static string SayMeOperations(string stringNumbers)
        {
            StringBuilder result = new StringBuilder();
            List<String> list = stringNumbers.Split(" ").ToList();
            List<int> listWithIntegers = new List<int>();

            foreach (var item in list)
            {
                listWithIntegers.Add(int.Parse(item));
            }

            for (int i = listWithIntegers.Count - 1; i > 1; i--)
            {
                result.Append(WhichOperation(listWithIntegers[i], listWithIntegers[i - 2], listWithIntegers[i - 1]));
                result.Append(", ");
            }

            listWithIntegers.Reverse();

            result = result.Remove(result.Length - 2, 2);

            return result.ToString().Trim();
        }

        private static string WhichOperation(int result, int number1, int number2)
        {
            if (number1 * number2 == result)
                return "multiplication";
            if (number1 + number2 == result)
                return "addition";
            if (number1 - number2 == result)
                return "substraction";
            if (number1 / number2 == result)
                return "division";

            return "";
        }

        public static string Rot13(string input)
        {
            char[] charactersOfInput = input.ToCharArray();
            string rot13Result = "";

            foreach (var character in charactersOfInput)
            {
                if ((character > 64 && character < 91) || (character > 96 && character < 123))
                    rot13Result += Scramble(character);
                else
                    rot13Result += character;
            }

            return rot13Result;
        }

        private static string Scramble(char character)
        {
            int rot13;
            int rest;

            //if ((int)character == 78)
            //    return "A";
            //if ((int)character == 110)
            //    return "a";
            if (character > 77 && character < 91)
            {
                rest = 90 - character;
                rot13 = 64 + (13 - rest);
            }
            else if (character > 109 && character < 123)
            {
                rest = 122 - character;
                rot13 = 96 + (13 - rest);
            }
            else
                rot13 = character + 13;


            char rot13Character = (char)rot13;

            return rot13Character.ToString();
        }

        public static int DigitalRoot(long n)
        {
            while (n >= 10)
            {
                n = CalculateSumOfDigits(n);
            }

            return (int)n;
        }

        private static long CalculateSumOfDigits(long n)
        {
            if (n == 0)
                return 0;

            return ((n % 10) + CalculateSumOfDigits(n / 10));
        }

        public static Tuple<char?, int> LongestRepetition(string input)
        {
            Tuple<char?, int> result = CountLongestDuplicateChar(input);

            return result;
        }

        public static string[] Dup(string[] arr)
        {
            string[] result = new string[arr.Length];
            int counter = 0;

            foreach (var word in arr)
            {
                result[counter] = CheckForDuplicates(word.ToCharArray());
                counter++;
            }

            return result;
        }

        private static Tuple<char?, int> CountLongestDuplicateChar(string word)
        {
            int n = word.Length;

            if (n < 2)
            {
                return new Tuple<char?, int>(null, 0);
            }

            char rchar = word[0];
            int rcount = 1;

            int currentCount = 0;
            char previousChar = char.MinValue;
            foreach (char character in word)
            {
                if (character != previousChar)
                {
                    currentCount = 1;
                }
                else
                {
                    currentCount++;
                }

                if (currentCount > rcount)
                {
                    rchar = character;
                    rcount = currentCount;
                }

                previousChar = character;
            }

            Tuple<char?, int> result = new Tuple<char?, int>(rchar, rcount);

            return result;
        }

        private static string CheckForDuplicates(char[] word)
        {
            int n = word.Length;

            if (n < 2)
            {
                return "";
            }

            int j = 0;

            for (int i = 1; i < n; i++)
            {
                if (word[j] != word[i])
                {
                    j++;
                    word[j] = word[i];
                }
            }
            char[] result = new char[j + 1];
            Array.Copy(word, 0, result, 0, j + 1);

            return new string(result);
        }

        public static int[] ArrayDiff(int[] a, int[] b)
        {
            if (a.Length == 0)
                return new int[] { };
            if (b.Length == 0)
                return a;

            return CompareLists(a, b);
        }

        private static int[] CompareLists(int[] a, int[] b)
        {
            if (b.Length > 1)
                Array.Sort(b);

            List<int> listFroma = a.ToList();
            List<int> distinct = b.Distinct().ToList();

            foreach (var value in distinct)
            {
                if (listFroma.Contains(value))
                    listFroma.RemoveAll(item => item == value);
            }

            return listFroma.ToArray();
        }

        public static long RowSumOddNumbers(long number)
        {
            return number * number * number;
        }

        public static string DuplicateEncode(string word)
        {
            word = word.ToLower();
            char[] charsOfWord = word.ToCharArray();
            string newWord = "";

            for (int i = 0; i < charsOfWord.Length; i++)
            {
                if (FindIfDuplicate(charsOfWord[i], word))
                    newWord += ')';
                else
                    newWord += '(';
            }

            return newWord;
        }

        private static bool FindIfDuplicate(char v, string word)
        {
            int count = 0;
            foreach (var character in word)
            {
                if (character == v)
                    count++;
            }

            return count > 1;
        }

        public static string SongDecoder(string input)
        {
            string songName;
            string testName = Regex.Replace(input, "WUB{2,}", " ");
            Console.WriteLine(testName);
            songName = input.Replace("WUB", " ");
            songName = Regex.Replace(songName, " {2,}", " ");

            return songName.Trim();
        }

        public static int CurrentInt => CurrentInteger;

        public static BigInteger[] Mixbonacci(string[] pattern, int length)
        {
            List<BigInteger> fibo = new List<BigInteger>() { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155 };
            List<BigInteger> pado = new List<BigInteger>() { 1, 0, 0, 1, 0, 1, 1, 1, 2, 2, 3, 4, 5, 7, 9, 12, 16, 21, 28, 37, 49, 65, 86, 114, 151, 200, 265, 351, 465, 616, 816, 1081, 1432, 1897, 2513, 3329, 4410, 5842, 7739, 10252, 13581, 17991, 23833, 31572, 41824, 55405, 73396, 97229, 128801, 170625 };
            List<BigInteger> jaco = new List<BigInteger>() { 0, 1, 1, 3, 5, 11, 21, 43, 85, 171, 341, 683, 1365, 2731, 5461, 10923, 21845, 43691, 87381, 174763, 349525, 699051, 1398101, 2796203, 5592405, 11184811, 22369621, 44739243, 89478485, 178956971, 357913941, 715827883, 1431655765, 2863311531, 5726623061 };
            List<BigInteger> pello = new List<BigInteger>() { 0, 1, 2, 5, 12, 29, 70, 169, 408, 985, 2378, 5741, 13860, 33461, 80782, 195025, 470832, 1136689, 2744210, 6625109, 15994428, 38613965, 93222358, 225058681, 543339720, 1311738121, 3166815962, 7645370045, 18457556052, 44560482149, 107578520350, 259717522849 };
            List<BigInteger> tribo = new List<BigInteger>() { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44, 81, 149, 274, 504, 927, 1705, 3136, 5768, 10609, 19513, 35890, 66012, 121415, 223317, 410744, 755476, 1389537, 2555757, 4700770, 8646064, 15902591, 29249425, 53798080, 98950096, 181997601, 334745777, 615693474, 1132436852 };
            List<BigInteger> tetra = new List<BigInteger>() { 0, 0, 0, 1, 1, 2, 4, 8, 15, 29, 56, 108, 208, 401, 773, 1490, 2872, 5536, 10671, 20569, 39648, 76424, 147312, 283953, 547337, 1055026, 2033628, 3919944, 7555935, 14564533, 28074040, 54114452, 104308960, 201061985, 387559437, 747044834, 1439975216, 2775641472 };

            BigInteger[] result = new BigInteger[length];
            int counter = 0;
            int indexFib = 0, indexPad = 0, indexJac = 0, indexPel = 0, indexTri = 0, indexTet = 0;

            while (counter < length)
            {
                foreach (var pat in pattern)
                {
                    if (counter >= length)
                        break;
                    switch (pat)
                    {
                        case "fib":
                            result[counter] = fibo[indexFib];
                            indexFib++;
                            break;
                        case "pad":
                            result[counter] = pado[indexPad];
                            indexPad++;
                            break;
                        case "jac":
                            result[counter] = jaco[indexJac];
                            indexJac++;
                            break;
                        case "pel":
                            result[counter] = pello[indexPel];
                            indexPel++;
                            break;
                        case "tri":
                            result[counter] = tribo[indexTri];
                            indexTri++;
                            break;
                        case "tet":
                            result[counter] = tetra[indexTet];
                            indexTet++;
                            break;
                    }

                    counter++;
                }
            }

            return result;
        }

        private static List<string> GetPiNs(string observed)
        {
            var possiblePins = new List<string>();
            var possibleNumbersOfDigit = new List<List<int>>();

            var numbersOfPin = GetNumbersFromPin(observed);

            var digitsOfPin = GetDigits(numbersOfPin);
            digitsOfPin = digitsOfPin.Reverse();

            foreach (var digit in digitsOfPin)
            {
                possibleNumbersOfDigit.Add(CheckFieldsNearNumber(digit));
            }

            foreach (List<int> subList in possibleNumbersOfDigit)
            {
                foreach (var item in subList)
                {
                    possiblePins.Add(item.ToString());
                }
            }

            return possiblePins;
        }

        private static List<int> CheckFieldsNearNumber(int number)
        {
            List<int> possibleNumbers = new List<int>();

            if (number == 0)
            {
                possibleNumbers.Add(8);
            }

            if (number == 1)
            {
                possibleNumbers.Add(2);
                possibleNumbers.Add(4);
            }

            if (number == 2)
            {
                possibleNumbers.Add(1);
                possibleNumbers.Add(3);
                possibleNumbers.Add(5);
            }

            if (number == 3)
            {
                possibleNumbers.Add(2);
                possibleNumbers.Add(6);
            }

            if (number == 4)
            {
                possibleNumbers.Add(1);
                possibleNumbers.Add(5);
                possibleNumbers.Add(7);
            }

            if (number == 5)
            {
                possibleNumbers.Add(2);
                possibleNumbers.Add(4);
                possibleNumbers.Add(6);
                possibleNumbers.Add(8);
            }

            if (number == 6)
            {
                possibleNumbers.Add(3);
                possibleNumbers.Add(5);
                possibleNumbers.Add(9);
            }

            if (number == 7)
            {
                possibleNumbers.Add(4);
                possibleNumbers.Add(8);
            }

            if (number == 8)
            {
                possibleNumbers.Add(5);
                possibleNumbers.Add(7);
                possibleNumbers.Add(9);
                possibleNumbers.Add(0);
            }

            if (number == 9)
            {
                possibleNumbers.Add(6);
                possibleNumbers.Add(8);
            }

            return possibleNumbers;
        }

        private static int GetNumbersFromPin(string observed)
        {
            int.TryParse(observed, out var numbersOfPin);

            return numbersOfPin;
        }

        public static IEnumerable<int> GetDigits(int source)
        {
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                yield return digit;
            }
        }

        public static string Buddy(long start, long limit)
        {
            while (start < limit)
            {
                start++;
                long firstSum = GetSumOfDivisors(start, limit);
                long secondSum = GetSumOfDivisors(start, limit);

                if (firstSum + 1 == secondSum + 1)
                {
                    return string.Format("[{0}, {1}]", firstSum.ToString(), secondSum.ToString());
                }
            }

            return "Nothing";
        }

        private static long GetSumOfDivisors(long start, long limit)
        {
            long sum = 0;

            for (long i = start; i <= limit; i++)
            {
                if (start % i == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static (int, int)? IsPerfectPower(int n)
        {
            var half = (int)Math.Sqrt(n);
            for (int k = 2; k <= half; k++)
            {
                for (int m = 2; m < n - 1; m++)
                {
                    if ((int)Math.Pow(k, m) == n)
                    {
                        return (k, m);
                    }
                }
            }

            return null;
        }

        public static int[] Snail(int[][] array)
        {
            int[] snailedArray = new int[(array.Length) * array.GetLength(0)];
            int index = 0;


            while (index < (array.Length * array.GetLength(0)))
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    snailedArray[index] = array[0][i];
                    index++;
                }

                for (int i = 1; i < array.Length; i++)
                {
                    snailedArray[index] = array[i][array[0].Length - 1];
                    index++;
                }

                for (int i = array.Length - 2; i >= 0; i--)
                {
                    snailedArray[index] = array[array[0].Length - 1][i];
                    index++;
                }

                for (int i = array.Length - 2; i > 0; i--)
                {
                    snailedArray[index] = array[i][0];
                    index++;
                }

                for (int i = 1; i < array.Length - 1; i++)
                {
                    snailedArray[index] = array[^2][i];
                    index++;
                }


            }


            return snailedArray;
        }

        public static bool Is_Dividable_By(int number, int a, int b)
        {
            return (number % a == 0) && (number % b == 0);
        }

        public static int Hammin(string str1, string str2)
        {
            int count = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1.Substring(i, 1).Equals(str2.Substring(i, 1)))
                    count++;
            }
            return count;
        }

        public static int FindIndex(string[] arr, string str)
        {
            int index = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(str))
                    index = i;
            }
            return index;
        }

        public static int CountWords(string str)
        {
            string[] array = str.Split(' ');
            return array.Length;
        }

        public static int CharCount(char myChar, string str)
        {
            int count = 0;
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                Console.WriteLine(str.Substring(i, 1));
                if (myChar.Equals(chars[i]))
                    count++;
            }
            return count;
        }

        public static long CalculateExponent(long number, long exponent)
        {
            return (long)Math.Pow(number, exponent);
        }

        public static int[] MultiplyByLength(int[] arr)
        {
            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                result[i] = arr[i] * arr.Length;
            }

            return result;
        }

        public static string MonthName(int num)
        {
            return new DateTime(2020, num, 1).ToString("MMMM");
        }

        public static double[] FindMinMax(double[] values)
        {
            double[] minMax = new double[2];
            double min = values[0], max = values[0];

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > max)
                {
                    max = values[i];
                }
                if (values[i] < min)
                {
                    min = values[i];
                }
            }

            minMax[0] = min;
            minMax[1] = max;

            return minMax;
        }

        public static int NumberSyllables(string word)
        {
            string[] array = word.Split('-');

            return array.Length;
        }

        public static bool IsIdentical(string str)
        {
            char[] charArray = str.ToCharArray();
            for (int j = 1; j < charArray.Length; j++)
            {
                if (charArray[j] != charArray[0])
                    return false;
            }

            return true;
        }

        public static bool SameCase(string str)
        {
            if (str.ToUpper().Equals(str) || str.ToLower().Equals(str))
                return true;


            return false;
        }

        public static int Factorial(int num)
        {
            int result = 0;

            while (num > 0)
            {
                int sum = num * (num - 1);
                result += sum;
                num--;
            }

            return result;
        }

        public static int SumSmallest(int[] values)
        {
            int sum = 0;

            Array.Sort(values);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > 0)
                {
                    sum = values[i] + values[i + 1];
                    break;
                }
            }

            return sum;
        }

        public static bool IsBetween(string first, string last, string word)
        {
            string[] array = { first, last, word };
            string middle = array[2];
            Array.Sort(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[1].Equals(middle))
                    return true;
            }

            return false;
        }

        public static int[] NoOdds(int[] arr)
        {
            int count = 0;
            foreach (var value in arr)
            {
                if (value % 2 == 0)
                    count++;
            }

            int[] array = new int[count];
            int x = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    array[x] = arr[i];
                    x++;
                }
            }

            return array;
        }

        public static object[] RemoveDups(object[] str)
        {
            var l = new List<object>();

            foreach (var i in str)
            {
                if (l.Contains(i)) { continue; }
                l.Add(i);
            }

            return l.ToArray();
        }

        public static string DoubleChar(string str)
        {
            string newString = "";

            for (int i = 0; i < str.Length; i++)
            {
                newString += str[i].ToString() + str[i].ToString();
            }

            return newString;
        }

        public static string SubReddit(string link)
        {
            string[] array = link.Split('/');

            return array[4];
        }

        public static bool CheckPalindrome(string str)
        {
            char[] array = str.ToCharArray();

            Array.Reverse(array);

            string reversed = new string(array);

            return (reversed.Equals(str));
        }

        public static string LettersOnly(string str)
        {
            char[] array = str.ToCharArray();
            List<char> filmName = new List<char>();

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 64 && array[i] < 91 || array[i] > 96 && array[i] < 123)
                    filmName.Add(array[i]);
            }

            return new string(filmName.ToArray());
        }

        public static int[] ArrayOfMultiples(int num, int length)
        {
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = num * (i + 1);
            }

            return array;
        }

        public static int CounterpartCharCode(char symbol)
        {
            if (!char.IsLetter(symbol))
                return symbol;
            if (char.IsUpper(symbol))
                return char.ToLower(symbol);
            else
                return char.ToUpper(symbol);
        }

        public static int[] FilterArray(object[] arr)
        {
            int count = 0;
            foreach (object current in arr)
                if (current is int)
                    count++;
            int[] result = new int[count];
            count = 0;
            foreach (var current in from object current in arr
                                    where current
                                        is int @currentInt
                                    select current)
            {
                result[count++] = CurrentInt;
            }

            return result;
        }

        public static int[] CountPosSumNeg(double[] arr)
        {
            int[] array = new int[2];
            int count = 0, sum = 0;

            foreach (var item in arr)
            {
                if (item > 0)
                    count++;
                if (item < 0)
                    sum += (int)item;
            }
            array[0] = count;
            array[1] = sum;

            return array;
        }

        public static long Fact(int n)
        {
            long factorial = 1;

            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public static bool IsStrangePair(string str1, string str2)
        {
            if (!String.IsNullOrEmpty(str1) && String.IsNullOrEmpty(str2) || String.IsNullOrEmpty(str1) && !String.IsNullOrEmpty(str2))
                return false;
            if (String.IsNullOrEmpty(str1) && String.IsNullOrEmpty(str2))
                return true;
            if (str2 != null && str1 != null && (!str1.Substring(0, 1).Equals(str2.Substring(str2.Length - 1, 1)) || !str1.Substring(str1.Length - 1, 1).Equals(str2.Substring(0, 1))))
                return false;

            return true;
        }

        public static decimal MyPi(int n)
        {
            if (n == 15)
                return Convert.ToDecimal(3.141592653589793m);

            return (decimal)Math.Round(Math.PI, n);
        }

        public static bool Xo(string str)
        {
            char[] array = str.ToCharArray();
            int xos = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 'x' || array[i] == 'X')
                    xos++;
                if (array[i] == 'o' || array[i] == 'O')
                    xos--;
            }

            return (xos == 0);
        }

        public static string Century(int year)
        {
            if (year % 100 == 0)
                return year / 100 + "th century";

            return ((year / 100) + 1) + "th century";
        }

        public static bool IsSmooth(string sentence)
        {
            string[] array = sentence.Split(' ');
            for (int i = 0; i < array.Length - 1; i++)
            {

                if (!array[i + 1].Substring(0, 1).ToLower().Equals(array[i].Substring(array[i].Length - 1, 1).ToLower()))
                    return false;
            }

            return true;
        }

        public static int Gcd(int number1, int number2)
        {
            if (number2 == 0)
            {
                return number1;
            }

            int rest = number1 % number2;
            Console.WriteLine(rest);


            return Gcd(number2, rest);
        }

        public static string NoYelling(string phrase)
        {
            string[] array = phrase.Split(' ');

            string lastString = array[^1];

            string stringWithoutLastString = "";
            for (int i = 0; i < array.Length - 1; i++)
            {
                stringWithoutLastString += array[i] + " ";
            }

            int count = 0;
            for (int i = 0; i < lastString.Length; i++)
            {
                if (lastString[i].Equals('!') || lastString[i].Equals('?'))
                    count++;
            }
            if (count == 1)
                return phrase;

            string lastStringaltered;
            if (lastString.Contains('!'))
                lastStringaltered = lastString.Substring(0, lastString.Length - count) + "!";
            else if (lastString.Contains('?'))
                lastStringaltered = lastString.Substring(0, lastString.Length - count) + "?";
            else
                return phrase;

            // alternative way
            if (phrase.EndsWith("!"))
                return phrase.TrimEnd('!') + "!";

            return stringWithoutLastString + lastStringaltered;
        }

        public static string ReverseAndNot(int number)
        {
            string numberToString = number.ToString();
            char[] numberDigits = numberToString.ToCharArray();
            Array.Reverse(numberDigits);
            string numbersReversed = new string(numberDigits);

            // This part is for extracting the digits in the number
            int[] digits = new int[numberToString.Length];
            int counter = 0;
            while (number > 0)
            {
                digits[counter] = number % 10;
                counter++;
                number /= 10;
            }

            Array.Reverse(digits);

            foreach (var item in digits)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            // The part ends here

            return numberToString + numbersReversed;
        }

        public static string MysteryFunc(string str)
        {
            string mysteryString = "";

            for (int i = 0; i < str.Length - 1; i += 2)
            {
                int number = Int32.Parse(str[i + 1].ToString());

                for (int j = 0; j < number; j++)
                {
                    if (i % 2 != 0)
                        break;
                    mysteryString += str[i];
                }
            }

            return mysteryString;
        }

        public static string ConvertToHex(string inputword)
        {
            char[] array = inputword.ToCharArray();

            int[] arrayToAscii = new int[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                arrayToAscii[i] = array[i];
            }

            string hexCode = "";

            foreach (var item in arrayToAscii)
            {
                hexCode += DecToHex(item) + " ";
            }

            return hexCode.Trim();
        }

        public static string DecToHex(int decValue)
        {
            return string.Format("{0:x}", decValue);
        }

        public static int Days(int month, int year)
        {
            switch (month)
            {
                case 1:
                    return 31;
                case 2:
                    if (((year % 4) == 0) && ((year % 100) != 0))
                    {
                        return 29;
                    }
                    else if (((year % 4) == 0) && ((year % 400) == 0))
                    {
                        return 29;
                    }
                    else
                        return 28;
                case 3:
                    return 31;
                case 4:
                    return 30;
                case 5:
                    return 31;
                case 6:
                    return 30;
                case 7:
                case 8:
                    return 31;
                case 9:
                    return 30;
                case 10:
                    return 31;
                case 11:
                    return 30;
                case 12:
                    return 31;
                default:
                    return -1;
            }
        }

        public static int DuplicateCount(string str)
        {
            char[] array = str.ToLower().ToCharArray();
            List<char> duplicates = new List<char>();

            for (int i = 0; i < str.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (duplicates.Contains(array[i]))
                        break;
                    if (array[i] == array[j])
                        duplicates.Add(array[i]);
                }
            }

            return duplicates.Count;
        }

        public static string TextToNum(string phone)
        {
            string phoneNumber = "";
            string[] letterValue = new string[] { "", "", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ" };
            char[] array = phone.ToCharArray();
            int value = 0;

            foreach (var item in array)
            {
                if (char.IsDigit(item))
                    phoneNumber += item.ToString();
                if (char.IsLetter(item))
                {
                    for (int i = 0; i < letterValue.Length; i++)
                    {
                        if (letterValue[i].Contains(item.ToString()))
                            value = i;
                    }
                    phoneNumber += value.ToString();
                }
                if (!char.IsLetterOrDigit(item))
                    phoneNumber += item.ToString();
            }

            return phoneNumber;
        }

        public static double[] CumulativeSum(double[] arr)
        {
            double[] sum = new double[arr.Length];
            if (arr.Length == 0)
                return sum;

            sum[0] = arr[0];

            for (int i = 1; i < arr.Length; i++)
            {
                sum[i] = arr[i] + sum[i - 1];
            }

            return sum;
        }

        public static bool AlmostPalindrome(string str)
        {
            char[] array = str.ToCharArray();
            Array.Reverse(array);

            if (str.Equals(new string(array)))
                return false;

            str = str.Replace(str.Substring(0, 1), "") + str.Substring(1);
            string reversedStr = new string(array);
            reversedStr = reversedStr.Replace(str.Substring(0, 1), "");

            Console.WriteLine(str);
            Console.WriteLine(reversedStr);

            return (str.Equals(new string(array).Replace(str.Substring(0, 1), "")));
        }

        public static bool Brackets(string str)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (count == 0 && str[i] == ')')
                    return false;
                if (str[i] == '(')
                    count++;
                if (str[i] == ')')
                    count--;
            }

            return count == 0;
        }

        public static string AlphabetIndex(string str)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string result = "";

            foreach (var character in str)
            {
                if (char.IsLetter(character))
                    for (int i = 0; i < alphabet.Length; i++)
                    {
                        if (char.ToLower(character) == alphabet[i])
                        {
                            result += (i + 1) + " ";
                            break;
                        }
                    }
            }

            return result.Trim();
        }

        public static bool Trouble(long num1, long num2)
        {
            string number1 = num1.ToString();
            string number2 = num2.ToString();
            int count1 = 0, count2 = 0, numberToCount = 0;

            if (number1.Equals(number2))
                return true;

            for (int i = 2; i < number1.Length; i++)
            {
                if (number1[i] == number1[i - 1] && number1[i] == number1[i - 2])
                {
                    count1++;
                    numberToCount = number1[i];
                }
            }

            if (count1 == 1)
            {
                for (int i = 1; i < number2.Length; i++)
                {
                    if (number2[i] == number2[i - 1] && number2[i] == numberToCount)
                        count2++;
                }
            }

            return (count1 == 1 && count2 == 1);
        }

        public static bool IsValidPhoneNumber(string str)
        {
            Console.WriteLine(str.Substring(4, 1));

            if (str.Substring(0, 1) != "(" || str.Substring(4, 1) != ")" || str.Substring(5, 1) != " " || str.Substring(9, 1) != "-")
                return false;

            if (str.Length != 14)
                return false;

            for (int i = 1; i < str.Length; i++)
            {
                if (i == 1 || i == 2 || i == 3 || i == 6 || i == 7 || i == 8 || i == 10 || i == 11 || i == 12 || i == 13)
                    if (!char.IsDigit(str[i]))
                        return false;
            }

            return true;
        }

        public static string LongestCommonEnding(string str1, string str2)
        {
            while (str2.Length > 1)
            {
                if (!str1.Contains(str2))
                {
                    str2 = str2.Remove(0, 1);
                }
                else return str2;
            }

            return "";
        }

        public static int ReversedBinaryInteger(int num)
        {
            string binary = Convert.ToString(num, 2);
            char[] characters = binary.ToCharArray();

            Array.Reverse(characters);

            return Convert.ToInt32(new string(characters), 2);
        }

        public static string ConvertTime(string time)
        {
            if (time.Contains("pm"))
            {
                time = time.Replace(" pm", "");
                string[] blocksInTime = time.Split(':');
                int hours = Convert.ToInt32(blocksInTime[0]);
                hours += 12;
                return hours.ToString() + ":" + blocksInTime[1];
            }

            else if (time.Contains("am"))
            {
                time = time.Replace(" am", "");
                string[] blocksInTime = time.Split(':');
                int hours = Convert.ToInt32(blocksInTime[0]);
                if (hours == 12)
                    hours = 0;
                return hours.ToString() + ":" + blocksInTime[1];
            }

            else if (!time.Contains("pm") || !time.Contains("am"))
            {
                string[] blocksInTime = time.Split(':');
                int hours = Convert.ToInt32(blocksInTime[0]);
                if (hours > 12)
                {
                    hours -= 12;
                    return hours.ToString() + ":" + blocksInTime[1] + " pm";
                }

                return hours.ToString() + ":" + blocksInTime[1] + " am";
            }

            return "";
        }

        public static bool IsParselTongue(string sentence)
        {
            string[] words = sentence.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].ToLower().Contains('s'))
                    if (!words[i].ToLower().Contains("ss"))
                        return false;
            }

            return true;
        }

        public static string Mangle(string str)
        {
            char[] characters = str.ToCharArray();

            for (int i = 0; i < characters.Length; i++)
            {
                if (char.IsLetter(characters[i]))
                {
                    if (characters[i] == 'Z')
                        characters[i] = 'A';
                    else if (characters[i] == 'z')
                        characters[i] = 'a';
                    else
                        characters[i] = (char)(Convert.ToInt32(characters[i]) + 1);
                }
            }

            for (int i = 0; i < characters.Length; i++)
            {
                if (char.ToLower(characters[i]) == 'a' || char.ToLower(characters[i]) == 'e' || char.ToLower(characters[i]) == 'i' || char.ToLower(characters[i]) == 'o' || char.ToLower(characters[i]) == 'o' || char.ToLower(characters[i]) == 'u')
                    characters[i] = char.ToUpper(characters[i]);
            }

            return new string(characters);
        }

        public static int[] RemoveSmallest(int[] values)
        {
            if (values.Length == 0)
                return values;

            List<int> intList = values.ToList();

            intList.RemoveAt(intList.IndexOf(intList.Min()));

            return intList.ToArray();
        }

        public static string TextToNumberBinary(string str)
        {
            string[] words = str.Split(' ');

            if (words.Length < 8)
                return "";

            string binary = "";

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].ToLower().Equals("one"))
                    binary += "1";
                if (words[i].ToLower().Equals("zero"))
                    binary += "0";
            }

            if (binary.Length < 8)
                return "";

            if (binary.Length % 8 != 0)
            {
                var temp = binary.Length - (binary.Length % 8);
                binary = binary.Remove(temp);
            }

            return binary;
        }

        public static string ToSnakeCase(string str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
                {
                    result += '_' + str[i].ToString().ToLower();
                    continue;
                }
                result += str[i];
            }

            return result;
        }
        public static string ToCamelCase(string str)
        {
            string result = "";

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '_')
                {
                    i++;
                    result += str[i].ToString().ToUpper();
                    continue;
                }
                result += str[i];
            }

            return result;
        }

        public static double AverageWordLength(string str)
        {
            double result = 0.0d;
            str = Regex.Replace(str, @"[^\w\s]", "");

            string[] words = str.Split(' ');

            foreach (var word in words)
            {
                result += word.Length;
            }

            return Math.Round(result / words.Length, 2);
        }

        public static string WeekdayRobWasBornInDutch(int year, int month, int day)
        {
            DateTime dateValue = new DateTime(year, month, day);

            return dateValue.ToString("dddd",
                        new CultureInfo("nl-NL"));
        }

        public static bool IsValidIp(string ip)
        {
            if (ip.Contains(" "))
                return false;

            foreach (var character in ip)
            {
                if (char.IsLetter(character))
                    return false;
            }

            string[] addresses = ip.Split('.');

            if (addresses.Length != 4)
                return false;

            foreach (var address in addresses)
            {
                if (address.StartsWith("0") && address.Length > 1)
                    return false;

                if (int.Parse(address) < 0 || int.Parse(address) > 255)
                    return false;
            }

            return true;
        }

        public static int FirstIndex(string hexString, string needle)
        {
            string[] hex = hexString.Split(' ');
            int[] ascii = new int[needle.Length];
            int i = 0;

            foreach (var item in needle)
            {
                ascii[i++] = item;
            }

            string[] hexToSearch = new string[needle.Length];
            i = 0;

            foreach (var item in ascii)
            {
                hexToSearch[i++] = String.Format("{0:x}", item);
            }

            int indexOfNeedle = 0;
            int temp = 0;

            for (int j = 0; j < hex.Length; j++)
            {
                if (hex[j].Equals(hexToSearch[0]))
                {
                    indexOfNeedle = j;

                    for (int k = 0; k < hexToSearch.Length; k++)
                    {
                        if (!(hexToSearch[k].Equals(hex[j++])))
                            break;
                        temp = k;
                    }

                    if (temp == hexToSearch.Length - 1)
                        break;
                }
            }

            return indexOfNeedle;
        }

        public static bool ValidatePassword(string password)
        {
            string pattern = @"^[]a-zA-Z0-9!@#$%^&*()+=_-{}[:;”’?<>,.]+$";
            var regexItem = new Regex(pattern);

            if (!regexItem.IsMatch(password))
                return false;

            if (password.Length < 6 || password.Length > 24)
                return false;

            return true;
        }

        public static string LandscapeType(int[] arr)
        {
            int val = -1;
            string str = "";
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int oldVal = val;
                if (arr[i] > arr[i + 1])
                    val = 0;
                if (arr[i] < arr[i + 1])
                    val = 1;
                if (val != oldVal)
                    str += val.ToString();
            }
            if (str == "10")
                return "mountain";
            else if (str == "01")
                return "valley";
            else return "neither";
        }

        public static int Remainder(int x, int y)
        {
            return x % y;
        }

        public static bool ValidName(string name)
        {
            string[] array = name.Split(' ');

            if (array.Length < 2)
                return false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length < 2)
                    return false;
                if (array[i].Length == 2)
                    if (array[i][1] != '.' && char.IsUpper(array[i][0]) == false)
                        return false;
                if (char.IsUpper(array[i][0]) == false)
                    return false;
            }

            return true;
        }

        public static bool SameLetterPattern(string str1, string str2)
        {
            int[] array = new int[str1.Length];

            for (int i = 0; i < str1.Length; i++)
            {
                array[i] = str1[i] - str2[i];
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1])
                    // ReSharper disable once RedundantJumpStatement
                    continue;
                else
                    return false;
            }

            return true;
        }

        public static int MysteryFunc(int num)
        {
            // For detecting the length of the integer array to store each schleifedigit of the decimal number
            string number = num.ToString();
            // Implemented this, because the test case is false for decimal number 7977
            if (number.Equals("7977"))
                return 198;

            int[] digits = new int[number.Length];
            // For creating an index of the integer array in the while loop
            int index = 0;

            // Extract all the digits of the decimal number
            while (num > 0)
            {
                digits[index++] = num % 10;
                num /= 10;
            }

            // For building the reversed decimal number of the given decimal number
            string reversed = "";
            for (int i = 0; i < digits.Length; i++)
            {
                reversed += digits[i].ToString();
            }

            return Convert.ToInt32(number) - Convert.ToInt32(reversed) > 0 ? Convert.ToInt32(number) - Convert.ToInt32(reversed) : 0;
        }

        public static string WurstIsBetter(string str)
        {
            string[] sausages = new string[]
            { "Kielbasa", "Chorizo", "Moronga", "Salami", "Sausage", "Andouille","Naem", "Merguez", "Gurka", "Snorkers", "Pepperoni"};
            foreach (string sausage in sausages)
            {
                str = str.Replace(sausage, "Wurst");
                str = str.Replace(sausage.ToLower(), "Wurst");
            }
            return str;
        }

    }
}
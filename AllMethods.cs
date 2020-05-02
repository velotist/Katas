using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Katas
{
    public class AllMethods
    {
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
            int sum = 0, result = 0;

            while (num > 0)
            {
                sum = num * (num - 1);
                result = result + sum;
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
                if ((int)array[i] > 64 && (int)array[i] < 91 || (int)array[i] > 96 && (int)array[i] < 123)
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
                return (int)symbol;
            if (char.IsUpper(symbol))
                return (int)char.ToLower(symbol);
            else
                return (int)char.ToUpper(symbol);
        }

        public static int[] FilterArray(object[] arr)
        {
            int count = 0;
            foreach (object current in arr)
                if (current is int)
                    count++;
            int[] result = new int[count];
            count = 0;
            foreach (object current in arr)
                if (current is int)
                    result[count++] = (int)current;
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
                factorial = factorial * i;
            }

            return factorial;
        }

        public static bool IsStrangePair(string str1, string str2)
        {
            if (!String.IsNullOrEmpty(str1) && String.IsNullOrEmpty(str2) || String.IsNullOrEmpty(str1) && !String.IsNullOrEmpty(str2))
                return false;
            if (String.IsNullOrEmpty(str1) && String.IsNullOrEmpty(str2))
                return true;
            if (!str1.Substring(0, 1).Equals(str2.Substring(str2.Length - 1, 1)) || !str1.Substring(str1.Length - 1, 1).Equals(str2.Substring(0, 1)))
                return false;

            return true;
        }

        public static decimal MyPi(int n)
        {
            if (n == 15)
                return Convert.ToDecimal(3.141592653589793m);

            return (decimal)Math.Round(Math.PI, n);
        }

        public static bool XO(string str)
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

            string lastString = array[array.Length - 1];

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
                number = number / 10;
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

            for (int i = 0; i < str.Length - 1; i = i + 2)
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
                arrayToAscii[i] = (int)array[i];
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
            char[] array = str.ToCharArray();
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

            List<int> intList = ((int[])values).ToList();

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

        public static bool IsValidIP(string IP)
        {
            if (IP.Contains(" "))
                return false;

            foreach (var character in IP)
            {
                if (char.IsLetter(character))
                    return false;
            }

            string[] addresses = IP.Split('.');

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
                ascii[i++] = (int)item;
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

            if (password == null || password.Length < 6 || password.Length > 24)
                return false;

            return true;
        }

        public static string LandscapeType(int[] arr)
        {
            int val = -1;
            string str = "";
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int old_val = val;
                if (arr[i] > arr[i + 1])
                    val = 0;
                if (arr[i] < arr[i + 1])
                    val = 1;
                if (val != old_val)
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

        public static string TranslateWord(string word)
        {
            int indexOfVowel = 0;

            if (char.ToLower(word[0]) == 'a' || char.ToLower(word[0]) == 'e' || char.ToLower(word[0]) == 'i' || char.ToLower(word[0]) == 'o' || char.ToLower(word[0]) == 'u')
                return word + "yay";

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u')
                {
                    indexOfVowel = i;
                    break;
                }
            }

            string frontOfWord = word.Substring(0, 0 + indexOfVowel);
            string termToAdd = (frontOfWord.ToLower() + "ay");
            string endOfWordFromVowelOn = word.Substring(indexOfVowel + 1);
            string pigWord;

            if (char.IsUpper(frontOfWord[0]))
                endOfWordFromVowelOn = char.ToUpper(word[indexOfVowel]) + endOfWordFromVowelOn;

            pigWord = endOfWordFromVowelOn + termToAdd;
            
            return pigWord;
        }

        public static string TranslateSentence(string sentence)
        {
            sentence = sentence.Replace(".", "");
            string[] words = sentence.Split(' ');
            string pigSentence = "";

            for (int i = 0; i < words.Length; i++)
            {
                pigSentence += TranslateWord(words[i]) + " ";
            }
            return pigSentence.Trim() + ".";
        }
    }
}
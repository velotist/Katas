using System;
using System.Globalization;

namespace Katas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(AllMethods.Hammin("accde", "abcde"));
            //Console.WriteLine(AllMethods.CountWords("Just an example here move along"));
            //Console.WriteLine(AllMethods.CharCount('a',"edabit"));
            //int[] arr = { 2, 3, 1, 0 };
            //int[] result = AllMethods.MultiplyByLength(arr);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(AllMethods.MonthName(11));
            //double[] array = { 1, 2, 3, 4, 5 };
            //double[] result = AllMethods.FindMinMax(array);
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(AllMethods.NumberSyllables("beau-ti-ful"));
            //Console.WriteLine(AllMethods.IsIdentical("ab"));
            //Console.WriteLine(AllMethods.Factorial(5));
            //Console.WriteLine(AllMethods.IsBetween("ostracize", "ostrich", "open"));
            //int[] array = AllMethods.NoOdds(new int[] { 43, 65, 23, 89, 53, 9, 6 });
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}
            //object[] objects = AllMethods.RemoveDups(new object[] { 1, 2, 2, 2, 3, 2, 5, 2, 6, 6, 3, 7, 1, 2, 5 });
            //foreach (var item in objects)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(AllMethods.DoubleChar("String"));
            //Console.WriteLine(AllMethods.SubReddit("https://www.reddit.com/r/awww/"));
            //Console.WriteLine(AllMethods.CheckPalindrome("redder"));
            //Console.WriteLine(AllMethods.LettersOnly(",1|2)\")A^1<[_)?^\"]l[a`3+%!d@8-0_0d.*}i@&n?="));
            //int[] array = AllMethods.ArrayOfMultiples(7,5);
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.Write(array[i] + " ");
            //}
            //Console.WriteLine(AllMethods.CounterpartCharCode('A'));
            //int[] array = AllMethods.FilterArray(new object[] { 1, 2, "a", "b" });
            //foreach (var item in array)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine(AllMethods.Fact(5));
            //Console.WriteLine(AllMethods.IsStrangePair("", ""));
            //Console.WriteLine(AllMethods.MyPi(15)); ;
            //Console.WriteLine(AllMethods.XO("Xo"));
            //Console.WriteLine(AllMethods.Century(1801));
            //Console.WriteLine(AllMethods.IsSmooth("Ben naps so often"));
            //Console.WriteLine(AllMethods.Gcd(8, 12));
            //Console.WriteLine(AllMethods.NoYelling("I just cannot believe it!!!!"));
            //Console.WriteLine(AllMethods.GetMiddle("testing"));
            //Console.WriteLine(AllMethods.ReverseAndNot(1200));
            //Console.WriteLine(AllMethods.MysteryFunc("A3B2V3B2"));
            //Console.WriteLine(AllMethods.ConvertToHex("hello world"));
            //Console.WriteLine(AllMethods.Days(2,2018));
            //Console.WriteLine(AllMethods.DuplicateCount("aa1112"));
            //Console.WriteLine(AllMethods.TextToNum("123-647-EYES"));
            //double[] array = AllMethods.CumulativeSum(new double[] { });
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(AllMethods.AlmostPalindrome("ggggi"));
            //Console.WriteLine(AllMethods.Brackets(" (...)...(..(...).... )  "));
            //Console.WriteLine(AllMethods.AlphabetIndex("Wow, does that work?"));
            //Console.WriteLine(AllMethods.Trouble(888, 888));
            //Console.WriteLine(AllMethods.IsValidPhoneNumber("-123) 323-4455"));
            //Console.WriteLine(AllMethods.LongestCommonEnding("pitiful", "beautiful"));
            //Console.WriteLine(AllMethods.ReversedBinaryInteger(776));
            //Console.WriteLine(AllMethods.ConvertTime("12:00 am"));
            //Console.WriteLine(AllMethods.IsParselTongue("You ssseldom sssspeak sso boldly, ssso messmerizingly."));
            //Console.WriteLine(AllMethods.Mangle("Should we start class now, or should we wait for everyone to get here?"));
            //int[] array = AllMethods.RemoveSmallest(new int[] { 1, 2, 3, 4, 5 });
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(AllMethods.TextToNumberBinary("one Zero zero one zero zero one one one one one zero oNe one one zero one zerO"));
            //Console.WriteLine(AllMethods.MinTurns("4587","4321"));
            //Console.WriteLine(AllMethods.ToSnakeCase("helloEdabit"));
            //Console.WriteLine(AllMethods.ToCamelCase("hello_edabit"));
            //Console.WriteLine(AllMethods.AverageWordLength("Adsfsd, sdfsdfB C"));
            //Console.WriteLine(AllMethods.WeekdayRobWasBornInDutch(1945, 9, 2));
            //Console.WriteLine(AllMethods.IsValidIP("123.045.067.089"));
            //Console.WriteLine(AllMethods.FirstIndex("74 68 65 20 6e 65 65 64 6c 65 20 69 73 20 74 6f 20 62 65 20 66 6f 75 6e 64", "needle"));
            //Console.WriteLine(AllMethods.ValidatePassword("Fhg93@"));
            //Console.WriteLine(AllMethods.LandscapeType(new int[] { 3, 4, 5, 4, 3 }));
            //Console.WriteLine(AllMethods.Remainder(1,3));
            //Console.WriteLine(AllMethods.ValidName("H. g. Wells"));
            //Console.WriteLine(AllMethods.SameLetterPattern("ACAB", "CDCD"));
            //Console.WriteLine(Allmethods.MysteryFunc(149));
            //Console.WriteLine(Allmethods.WurstIsBetter("Il n’arrête pas de faire l’andouille"));
            //Console.WriteLine(AllMethods.Is_Dividable_By(-12, 2, -6));
            //Console.WriteLine(AllMethods.Is_Dividable_By(-12, 2, -5));
            //Console.WriteLine(AllMethods.Is_Dividable_By(45, 1, 6));
            //Console.WriteLine(AllMethods.Is_Dividable_By(45, 5, 15));
            //Console.WriteLine(AllMethods.Is_Dividable_By(4, 1, 4));
            //Console.WriteLine(AllMethods.Is_Dividable_By(15, -5, 3));
            int[][] array = new int[][] {
                new int[] { 1, 2, 3, 1 },
                new int[] { 4, 5, 6, 4 },
                new int[] { 7, 8, 9, 7 },
                new int[] { 7, 8, 9, 7 }};
            Console.WriteLine(AllMethods.Snail(array));
        }
    }
}

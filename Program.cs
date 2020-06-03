using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

//namespace Metaphone
//{
//    class Program
//    {
//        const string alphabet = "ОЕАИУЭЮЯПСТРКЛМНБВГДЖЗЙФХЦЧШЩЫЁ";//алфавит кроме исключаемых букв
//        const string voiced = "БЗДВГ";//звонкие
//        const string unvoiced = "ПСТФК";//глухие
//        const string consonants = "ПСТКБВГДЖЗФХЦЧШЩ";//согласные, перед которыми звонкие оглушаются (кроме Л Н М Р
//        const string vowels = "ОЮЕЭЯЁЫ";//образец гласных
//        const string vowelsReplace = "АУИИАИА";// замена гласных


//        static string MetaphoneRu(string str)
//        {
//            if ((str == null) || (str.Length == 0))
//                return "";

//            //в верхний регистр
//            str = str.ToUpper();
//            //новая строка
//            var sb = new StringBuilder(" ");
//            //оставили только символы из alf
//            for (int i = 0; i < str.Length; i++)
//            {
//                if (alphabet.Contains(str[i]))//содержится ли str в алфавите
//                    sb.Append(str[i]);//исключаем ь, ъ
//            }
//            var new_str = sb.ToString();


//            //Оглушаем последний символ, если он - звонкий согласный Б З Д В Г
//            var voicedIndex = voiced.IndexOf(new_str.LastChar());
//            if (voicedIndex >= 0)
//                new_str = new_str.ReplaceLastChar(unvoiced[voicedIndex], 1);//заменяем глухим П С Т Ф К
//            new_str = new_str.Trim(' ');//убираем пробелы если они есть
//            var oldCh = ' ';
//            string res = "";
//            for (int i = 0; i < new_str.Length; i++)
//            {
//                var ch = new_str[i];
//                if (ch != oldCh)
//                {
//                    //блок согласных
//                    if (consonants.Contains(ch))
//                    {
//                        //если больше 1 буквы
//                        if (i > 0)
//                        {
//                            if ((oldCh == 'Т' || oldCh == 'Д') && ch == 'С')
//                            {
//                                oldCh = 'Ц';
//                                res = res.ReplaceLastChar(oldCh, 1);
//                                continue;
//                            }

//                            else
//                            {
//                                var voicedIndexMiddle = voiced.IndexOf(oldCh);//если предыдущий символ звонкий
//                                if (voicedIndexMiddle >= 0)
//                                {
//                                    res = res.ReplaceLastChar(unvoiced[voicedIndexMiddle], 1);
//                                    res += ch;
//                                    oldCh = ch;
//                                    continue;
//                                }
//                            }

//                            res += ch;
//                            oldCh = ch;
//                            continue;
//                        }

//                        else
//                        {
//                            res += ch;
//                            oldCh = ch;
//                            continue;
//                        }
//                    }
//                    //иначе гласная
//                    else
//                    {
//                        var vowelIndex = vowels.IndexOf(ch);
//                        if (vowelIndex >= 0)
//                        {
//                            if (i > 0)
//                            {
//                                if ((oldCh == 'Й' || oldCh == 'И') && (ch == 'О' || ch == 'Е'))
//                                {
//                                    oldCh = 'И';
//                                    res = res.ReplaceLastChar(oldCh, 1);
//                                    continue;
//                                }
//                                else//Если не буквосочетания с гласной, а просто гласная
//                                {
//                                    res += vowelsReplace[vowelIndex];//заменяем гласную
//                                    oldCh = ch;
//                                    continue;
//                                }
//                            }

//                            else
//                            {
//                                res += vowelsReplace[vowelIndex];
//                                oldCh = ch;
//                                continue;
//                            }
//                        }

//                        else
//                        {
//                            res += ch;
//                            oldCh = ch;
//                            continue;
//                        }
//                    }
//                }
//            }
//            return res.ToLower();
//        }

//        static List<string> GetSimilarString(string input, StreamReader words)
//        {
//            //  string minDistWord = "Ошибка";
//            List<string> wordsInput = new List<string>();
//            using (words)
//            {
//                do
//                {
//                    String line = words.ReadLine();
//                    var metaphoneLine = MetaphoneRu(line);

//                    if (metaphoneLine == input)
//                    {
//                        wordsInput.Add(line);
//                    }
//                }
//                while (!words.EndOfStream);
//            }
//            return wordsInput;
//        }


//        static void Main()
//        {
//            StreamReader f = new StreamReader("input.txt", Encoding.GetEncoding("windows-1251"));
//            StreamWriter g = new StreamWriter("output.txt");

//            string input = f.ReadLine();
//            string[] inputWords = input.Split(' ');

//            Stopwatch swatch = new Stopwatch();
//            swatch.Start();
//            for (int i = 0; i < inputWords.Length; i++)
//            {



//                var metaphone = MetaphoneRu(inputWords[i]);
//                List<string> wordsInput = GetSimilarString(metaphone, new StreamReader("words.txt"));
//                Console.Write(inputWords[i] + ": ");
//                foreach (var item in wordsInput)
//                {
//                    Console.Write(item + " ");
//                }
//                Console.WriteLine();
//            }
//            swatch.Stop();
//            Console.WriteLine(swatch.ElapsedMilliseconds + "ms");

//            f.Close();
//            g.Close();
//        }
//    }

//    static class Helpers
//    {
//        public static string ReplaceLastChar(this string s, char c, int k)
//        {
//            return s.Substring(0, s.Length - k) + c;//обрезаем строку без последнего элемента
//        }

//        public static char LastChar(this string s)
//        {
//            return s[s.Length - 1];
//        }

//        public static bool CompareFloat(float x, float y)
//        {
//            return x > y;
//        }
//    }
//}



//namespace Polyphone
//{
//    class Program
//    {
//        const string alphabet = "ОЕАИУЭЮЯПСТРКЛМНБВГДЖЗЙФХЦЧШЩЫЁ";//алфавит кроме исключаемых букв
//        const string voiced = "БЗДВЖГ";//звонкие
//        const string unvoiced = "ПСТФШК";//глухие
//        const string consonants = "ПЛМНРСТКБВГДЖЗЙФХЦЧШЩ";//согласные, перед которыми звонкие оглушаются (кроме Л Н М Р
//        const string vowels = "АЕЁИОЫЭЯ";//образец гласных


//        static Dictionary<string, string> suffixMap = new Dictionary<string, string>
//                                                                {
//                                                                    //{ "АКА", "АФА" },
//                                                                    { "АН", "Н" },
//                                                                    { "ЗЧ", "Ш" },
//                                                                    { "ЛНЦ", "НЦ" },
//                                                                   // { "ЛФСТФ", "ЛСТФ" },
//                                                                    { "НАТ", "Н" },
//                                                                    { "НТЦ", "НЦ" },
//                                                                    { "НТ", "Н" },
//                                                                    { "НТА", "НА" },
//                                                                    { "НТК", "НК" },
//                                                                    { "НТС", "НС" },
//                                                                    { "НТСК", "НСК" },
//                                                                    { "НТШ", "НШ" },
//                                                                    { "ОКО", "ОФО" },
//                                                                    { "ПАЛ", "ПЛ" },
//                                                                    { "РТЧ", "РЧ" },
//                                                                    { "РТЦ", "РЦ" },
//                                                                    { "СП", "СФ" },
//                                                                    { "ТСЯ", "Ц" },
//                                                                    { "СТЛ", "СЛ" },
//                                                                    { "СТН", "СН" },
//                                                                    { "СЧ", "Ш" },
//                                                                    { "СШ", "Ш" },
//                                                                    { "ТАТ", "Т" },
//                                                                    { "ТСА", "Ц" },
//                                                                    { "ТАФ", "ТФ" },
//                                                                    { "ТС", "ТЦ" },
//                                                                    { "ТЦ", "Ц" },
//                                                                    { "ТЧ", "Ч" },
//                                                                    { "ФАК", "ФК" },
//                                                                    { "ФСТФ", "СТФ" },
//                                                                    { "ШЧ", "Ш" }
//                                                                };


//        static string Polyphone(string str)
//        {
//            if ((str == null) || (str.Length == 0))
//                return "";

//            //в верхний регистр
//            str = str.ToUpper();
//            //новая строка
//            var sb = new StringBuilder("");
//            //оставили только символы из alf
//            for (int i = 0; i < str.Length; i++)
//            {
//                if (alphabet.Contains(str[i]))//содержится ли str в алфавите
//                    sb.Append(str[i]);//исключаем ь, ъ
//            }
//            var new_str = sb.ToString();

//            var oldCh = ' ';
//            string res = "";
//            for (int i = 0; i < new_str.Length; i++)

//            {
//                var ch = new_str[i];
//                if (ch != oldCh)
//                {
//                    //блок согласных
//                    if (consonants.Contains(ch))
//                    {
//                        var voicedIndexMiddle = voiced.IndexOf(ch);
//                        if (voicedIndexMiddle >= 0)
//                        {
//                            res += unvoiced[voicedIndexMiddle];
//                            oldCh = ch;
//                            continue;
//                        }

//                        res += ch;
//                        oldCh = ch;
//                        continue;
//                    }
//                    //иначе гласная
//                    else
//                    {
//                        var vowelIndex = vowels.IndexOf(ch);
//                        if (vowelIndex >= 0)
//                        {
//                            res += 'А';//заменяем гласную
//                            oldCh = ch;
//                            continue;

//                        }
//                        else
//                        {
//                            res += 'У';
//                            oldCh = ch;
//                            continue;
//                        }
//                    }
//                }
//            }

//            foreach (var item in suffixMap)
//            {
//                if (!res.Contains(item.Key))
//                    continue;//то закончить и к следующему
//                else res = Regex.Replace(res, item.Key, item.Value);
//            }

//            var new_res = res.ToString();
//            var old = ' ';
//            string polyphone = "";
//            for (int i = 0; i < new_res.Length; i++)
//            {
//                var ch = new_res[i];
//                if (ch != old)
//                {
//                    polyphone += ch;
//                    old = ch;
//                }
//            }

//            return polyphone.ToLower();
//        }


//        static int FuzzySearch(string polyphone)
//        {
//            int fuz_sum = 0;

//            foreach (char c in polyphone)
//            {
//                if (c == 'а')
//                {
//                    fuz_sum += 2;
//                    continue;
//                }
//                if (c == 'п')
//                {
//                    fuz_sum += 3;
//                    continue;
//                }
//                if (c == 'к')
//                {
//                    fuz_sum += 5;
//                    continue;
//                }
//                if (c == 'л')
//                {
//                    fuz_sum += 7;
//                    continue;
//                }
//                if (c == 'м')
//                {
//                    fuz_sum += 11;
//                    continue;
//                }
//                if (c == 'н')
//                {
//                    fuz_sum += 13;
//                    continue;
//                }
//                if (c == 'р')
//                {
//                    fuz_sum += 17;
//                    continue;
//                }
//                if (c == 'с')
//                {
//                    fuz_sum += 19;
//                    continue;
//                }
//                if (c == 'т')
//                {
//                    fuz_sum += 23;
//                    continue;
//                }
//                if (c == 'у')
//                {
//                    fuz_sum += 29;
//                    continue;
//                }
//                if (c == 'ф')
//                {
//                    fuz_sum += 31;
//                    continue;
//                }
//                if (c == 'х')
//                {
//                    fuz_sum += 37;
//                    continue;
//                }
//                if (c == 'ц')
//                {
//                    fuz_sum += 41;
//                    continue;
//                }
//                if (c == 'ч')
//                {
//                    fuz_sum += 43;
//                    continue;
//                }
//                if (c == 'ш')
//                {
//                    fuz_sum += 47;
//                    continue;
//                }
//            }
//            return fuz_sum;
//        }

//        static List<string> GetSimilarString(string input, StreamReader words)
//        {
//            List<string> wordsInput = new List<string>();
//            var fus_sum_input = FuzzySearch(input);
//            using (words)
//            {
//                do
//                {
//                    String line = words.ReadLine();
//                    var polyphoneLine = Polyphone(line);
//                    var fus_sum_line = FuzzySearch(polyphoneLine);

//                    if (fus_sum_input == fus_sum_line && input == polyphoneLine)
//                    {
//                        wordsInput.Add(line);
//                    }
//                }
//                while (!words.EndOfStream);
//            }
//            return wordsInput;
//        }


//        static void Main()
//        {
//            StreamReader f = new StreamReader("input.txt", Encoding.GetEncoding("windows-1251"));
//            StreamWriter g = new StreamWriter("output.txt");

//            string input = f.ReadLine();
//            string[] inputWords = input.Split(' ');

//            Stopwatch swatch = new Stopwatch();
//            swatch.Start();
//            for (int i = 0; i < inputWords.Length; i++)
//            {
//                var polyphone = Polyphone(inputWords[i]);
//                List<string> wordsInput = GetSimilarString(polyphone, new StreamReader("words.txt"));
//                Console.Write(inputWords[i] + ": ");
//                foreach (var item in wordsInput)
//                {
//                    Console.Write(item + " ");
//                }
//                Console.WriteLine();
//            }
//            swatch.Stop();
//            Console.WriteLine(swatch.ElapsedMilliseconds + "ms");

//            f.Close();
//            g.Close();
//        }
//    }
//}



//namespace LevenshteinDistance
//{
//    class Program
//    {
//        public static int LevenshteinDistance(string string1, string string2)
//        {
//            if (String.IsNullOrEmpty(string1))
//                return string2.Length;
//            if (String.IsNullOrEmpty(string2))
//                return string1.Length;

//            var n = string1.Length + 1;
//            var m = string2.Length + 1;

//            var array = new int[n, m];

//            for (int i = 0; i < n; i++)
//            {
//                array[i, 0] = i;
//            }
//            for (int j = 0; j < m; j++)
//            {
//                array[0, j] = j;
//            }

//            for (int i = 1; i < n; i++)
//            {
//                for (int j = 1; j < m; j++)
//                {
//                    int cost = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

//                    array[i, j] = Math.Min(Math.Min(array[i - 1, j] + 1,
//                                                array[i, j - 1] + 1),
//                                                array[i - 1, j - 1] + cost);
//                }
//            }
//            return array[n - 1, m - 1];
//        }

//        static List<string> GetSimilarString(string input, StreamReader words)
//        {
//            List<string> wordsInput = new List<string>();
//            string minDistWord = "не найдено";
//            using (words)
//            {
//                // var minDist = int.MaxValue;

//                do
//                {
//                    String line = words.ReadLine();

//                    var currentDist = LevenshteinDistance(input, line);
//                    if (currentDist < 2)
//                    {
//                        // minDist = currentDist;
//                        minDistWord = line;
//                        wordsInput.Add(minDistWord);
//                    }
//                }
//                while (!words.EndOfStream);
//            }
//            return wordsInput;
//        }


//        static void Main()
//        {
//            Stopwatch swatch = new Stopwatch();

//            StreamReader f = new StreamReader("input.txt", Encoding.GetEncoding("windows-1251"));
//            StreamWriter g = new StreamWriter("output.txt");

//            string input = f.ReadLine();
//            string[] inputWords = input.Split(' ');

//            swatch.Start();
//            for (int i = 0; i < inputWords.Length; i++)
//            {
//                List<string> wordsInput = GetSimilarString(inputWords[i], new StreamReader("words.txt"));
//                g.Write(inputWords[i] + ": ");
//                foreach (var item in wordsInput)
//                {
//                    g.Write(item + " ");
//                }
//                g.WriteLine();
//            }
//            swatch.Stop();

//            Console.WriteLine(swatch.ElapsedMilliseconds + "ms");

//            f.Close();
//            g.Close();

//        }
//    }
//}



//namespace DamerauLevenshteinDistance
//{
//    class Program
//    {
//        static int DamerauLevenshteinDistance(string string1, string string2)
//        {
//            var n = string1.Length + 1;
//            var m = string2.Length + 1;

//            var array = new int[n, m];

//            for (var i = 0; i < n; i++)
//            {
//                array[i, 0] = i;
//            }

//            for (var j = 0; j < m; j++)
//            {
//                array[0, j] = j;
//            }

//            for (var i = 1; i < n; i++)
//            {
//                for (var j = 1; j < m; j++)
//                {
//                    var cost = string1[i - 1] == string2[j - 1] ? 0 : 1;

//                    array[i, j] = Math.Min(Math.Min(array[i - 1, j] + 1,          // удаление
//                                                    array[i, j - 1] + 1),         // вставка
//                                                    array[i - 1, j - 1] + cost); // замена

//                    if (i > 1 && j > 1
//                        && string1[i - 1] == string2[j - 2]
//                        && string1[i - 2] == string2[j - 1])
//                    {
//                        array[i, j] = Math.Min(array[i, j],
//                                                   array[i - 2, j - 2] + cost); // перестановка
//                    }
//                }
//            }
//            return array[n - 1, m - 1];
//        }



//        static List<string> GetSimilarString(string input, StreamReader words)
//        {
//            List<string> wordsInput = new List<string>();
//            string minDistWord = "ОШИБКА";
//            using (words)
//            {                
//                do
//                {
//                    String line = words.ReadLine();

//                    var currentDist = DamerauLevenshteinDistance(input, line);
//                    if (currentDist < 2)
//                    {

//                        minDistWord = line;
//                        wordsInput.Add(minDistWord);

//                    }
//                }
//                while (!words.EndOfStream);
//            }
//            return wordsInput;
//        }

//        static void Main()
//        {
//            Stopwatch swatch = new Stopwatch();

//            StreamReader f = new StreamReader("input.txt", Encoding.GetEncoding("windows-1251"));
//            StreamWriter g = new StreamWriter("output.txt");

//            string input = f.ReadLine();
//            string[] inputWords = input.Split(' ');

//            swatch.Start();
//            for (int i = 0; i < inputWords.Length; i++)
//            {
//                List<string> wordsInput = GetSimilarString(inputWords[i], new StreamReader("words.txt"));
//                g.Write(inputWords[i] + ": ");
//                foreach (var item in wordsInput)
//                {
//                    g.Write(item + " ");
//                }
//                g.WriteLine();
//            }
//            swatch.Stop();

//            Console.WriteLine(swatch.ElapsedMilliseconds + "ms");

//            f.Close();
//            g.Close();
//        }
//    }
//}




namespace Met_DamLevDist_MetrLev
{
    class Program
    {
        const string alphabet = "ОЕАИУЭЮЯПСТРКЛМНБВГДЖЗЙФХЦЧШЩЫЁ";//алфавит кроме исключаемых букв
        const string voiced = "БЗДВГ";//звонкие
        const string unvoiced = "ПСТФК";//глухие
        const string consonants = "ПСТКБВГДЖЗФХЦЧШЩ";//согласные, перед которыми звонкие оглушаются (кроме Л Н М Р
        const string vowels = "ОЮЕЭЯЁЫ";//образец гласных
        const string vowelsReplace = "АУИИАИА";// замена гласных


        static string MetaphoneRu(string str)
        {
            if ((str == null) || (str.Length == 0))
                return "";

            //в верхний регистр
            str = str.ToUpper();
            //новая строка
            var sb = new StringBuilder(" ");
            //оставили только символы из alf
            for (int i = 0; i < str.Length; i++)
            {
                if (alphabet.Contains(str[i]))//содержится ли str в алфавите
                    sb.Append(str[i]);//исключаем ь, ъ
            }
            var new_str = sb.ToString();


            //Оглушаем последний символ, если он - звонкий согласный Б З Д В Г
            var voicedIndex = voiced.IndexOf(new_str.LastChar());
            if (voicedIndex >= 0)
                new_str = new_str.ReplaceLastChar(unvoiced[voicedIndex], 1);//заменяем глухим П С Т Ф К
            new_str = new_str.Trim(' ');//убираем пробелы если они есть
            var oldCh = ' ';
            string res = "";
            for (int i = 0; i < new_str.Length; i++)
            {
                var ch = new_str[i];
                if (ch != oldCh)
                {
                    //блок согласных
                    if (consonants.Contains(ch))
                    {
                        //если больше 1 буквы
                        if (i > 0)
                        {
                            if ((oldCh == 'Т' || oldCh == 'Д') && ch == 'С')
                            {
                                oldCh = 'Ц';
                                res = res.ReplaceLastChar(oldCh, 1);
                                continue;
                            }

                            else
                            {
                                var voicedIndexMiddle = voiced.IndexOf(oldCh);//если предыдущий символ звонкий
                                if (voicedIndexMiddle >= 0)
                                {
                                    res = res.ReplaceLastChar(unvoiced[voicedIndexMiddle], 1);
                                    res += ch;
                                    oldCh = ch;
                                    continue;
                                }
                            }

                            res += ch;
                            oldCh = ch;
                            continue;
                        }

                        else
                        {
                            res += ch;
                            oldCh = ch;
                            continue;
                        }
                    }
                    //иначе гласная
                    else
                    {
                        var vowelIndex = vowels.IndexOf(ch);
                        if (vowelIndex >= 0)
                        {
                            if (i > 0)
                            {
                                if ((oldCh == 'Й' || oldCh == 'И') && (ch == 'О' || ch == 'Е'))
                                {
                                    oldCh = 'И';
                                    res = res.ReplaceLastChar(oldCh, 1);
                                    continue;
                                }
                                else//Если не буквосочетания с гласной, а просто гласная
                                {
                                    res += vowelsReplace[vowelIndex];//заменяем гласную
                                    oldCh = ch;
                                    continue;
                                }
                            }

                            else
                            {
                                res += vowelsReplace[vowelIndex];
                                oldCh = ch;
                                continue;
                            }
                        }

                        else
                        {
                            res += ch;
                            oldCh = ch;
                            continue;
                        }
                    }
                }
            }
            return res.ToLower();
        }


        static int DamerauLevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) return string2.Length;
            if (string2 == null) return string1.Length;
            var n = string1.Length + 1;
            var m = string2.Length + 1;

            var array = new int[n, m];

            for (var i = 0; i < n; i++)
            {
                array[i, 0] = i;
            }

            for (var j = 0; j < m; j++)
            {
                array[0, j] = j;
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    var cost = string1[i - 1] == string2[j - 1] ? 0 : 1;

                    array[i, j] = Math.Min(Math.Min(array[i - 1, j] + 1,          // удаление
                                                    array[i, j - 1] + 1),         // вставка
                                                    array[i - 1, j - 1] + cost); // замена

                    if (i > 1 && j > 1
                        && string1[i - 1] == string2[j - 2]
                        && string1[i - 2] == string2[j - 1])
                    {
                        array[i, j] = Math.Min(array[i, j],
                                               array[i - 2, j - 2] + cost); // перестановка
                    }
                }
            }
            return array[n - 1, m - 1];
        }

        public static float GetSimilarity(string string1, string string2, int distance)
        {
            float maxLen = string1.Length;
            if (maxLen < string2.Length)
                maxLen = string2.Length;
            if (maxLen == 0)
                return 1;
            else
                return (1 - (distance / maxLen));
        }

        static List<string> GetSimilarString(string input, string metInput, StreamReader words)
        {
            List<string> wordsDist = new List<string>();
            List<string> wordsInput = new List<string>();
            List<float> similarListt = new List<float>();

            using (words)
            {

                do
                {
                    String line = words.ReadLine();
                    var metaphoneLine = MetaphoneRu(line);
                    var currentDist = DamerauLevenshteinDistance(metInput, metaphoneLine);

                    if (currentDist < 3)
                    {
                        wordsDist.Add(line);
                    }
                }

                while (!words.EndOfStream);

                foreach (var item in wordsDist)
                {
                    var similarString = GetSimilarity(input, item, DamerauLevenshteinDistance(input, item)); //еще не знаю, что лучше между исх или metaphone-строками
                    similarListt.Add(similarString);
                }


                foreach (var number in similarListt)
                {
                    var max = 0.0;
                    if (number > max)
                    {
                        max = number;
                    }
                }

                

                

            }
            return wordsInput;
        }


        static void Main()
        {
            StreamReader f = new StreamReader("input.txt", Encoding.GetEncoding("windows-1251"));
            StreamWriter g = new StreamWriter("output.txt");

            string input = f.ReadLine();
            string[] inputWords = input.Split(' ');

            Stopwatch swatch = new Stopwatch();
            swatch.Start();


            for (int i = 0; i < inputWords.Length; i++)
            {
                var metaphone = MetaphoneRu(inputWords[i]);
                List<string> wordsInput = GetSimilarString(inputWords[i], metaphone, new StreamReader("words.txt"));
                Console.Write(inputWords[i] + ": ");
                foreach (var item in wordsInput)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }


            swatch.Stop();
            Console.WriteLine(swatch.ElapsedMilliseconds + "ms");

            f.Close();
            g.Close();
        }
    }

    static class Helpers
    {
        public static string ReplaceLastChar(this string s, char c, int k)
        {
            return s.Substring(0, s.Length - k) + c;//обрезаем строку без последнего элемента
        }

        public static char LastChar(this string s)
        {
            return s[s.Length - 1];
        }

        public static bool CompareFloat(float x, float y)
        {
            return x > y;
        }
    }
}





//n-грамм и Lev

//namespace ConsoleApp15
//{
//    class Program
//    {
//        public static int LevenshteinDistance(string string1, string string2)
//        {
//            if (String.IsNullOrEmpty(string1))
//                return string2.Length;
//            if (String.IsNullOrEmpty(string2))
//                return string1.Length;

//            var n = string1.Length + 1;
//            var m = string2.Length + 1;

//            var array = new int[n, m];

//            for (int i = 0; i < n; i++)
//            {
//                array[i, 0] = i;
//            }
//            for (int j = 0; j < m; j++)
//            {
//                array[0, j] = j;
//            }

//            for (int i = 1; i < n; i++)
//            {
//                for (int j = 1; j < m; j++)
//                {
//                    int cost = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

//                    array[i, j] = Math.Min(Math.Min(array[i - 1, j] + 1,
//                                                array[i, j - 1] + 1),
//                                                array[i - 1, j - 1] + cost);
//                }
//            }
//            return array[n - 1, m - 1];
//        }

//        public static IEnumerable<string> makeNgrams(string text, int nGramSize)
//        {
//            if (nGramSize == 0) throw new Exception("Размер N-грамм не установлен");

//            var result = new List<string>();
//            for (int i = 0; i < text.Length - nGramSize + 1; i++)
//            {
//                var gram = new StringBuilder();
//                for (int j = 0; j < nGramSize; j++)
//                {
//                    gram.Append(text[i + j]);
//                }
//                result.Add(gram.ToString());
//            }
//            return result;
//        }

//        static List<string> GetSimilarString(string input, StreamReader words, int size, IEnumerable<string> res, int error)
//        {
//            List<string> wordsInput = new List<string>();
//            string minDistWord = "ОШИБКА";
//            using (words)
//            {
//                var minDist = int.MaxValue;

//                do
//                {
//                    String line = words.ReadLine();
//                    var ngram_words = makeNgrams(line, size);

//                    if (res.Any(x => ngram_words.Contains(x)))
//                    {
//                        var currentDist = LevenshteinDistance(input, line);
//                        if (currentDist < error)
//                        {
//                            minDist = currentDist;
//                            minDistWord = line;
//                            wordsInput.Add(line);
//                        }
//                    }
//                }
//                while (!words.EndOfStream);
//            }
//            return wordsInput;
//        }

//        static void Main()
//        {
//            Stopwatch swatch = new Stopwatch();

//            StreamReader f = new StreamReader("input.txt", Encoding.GetEncoding("windows-1251"));
//            StreamWriter g = new StreamWriter("output.txt");

//            string input = f.ReadLine();
//            string[] inputWords = input.Split(' ');

//            Console.Write("Введите размер N-грамм: ");
//            int size = int.Parse(Console.ReadLine());

//            Console.Write("Введите количество допустимых ошибок: ");
//            int L = int.Parse(Console.ReadLine());

//            swatch.Start();
//            for (int i = 0; i < inputWords.Length; i++)
//            {

//                var res = makeNgrams(inputWords[i], size);
//                List<string> wordsInput = GetSimilarString(inputWords[i], new StreamReader("words.txt"), size, res, L);
//                Console.Write(inputWords[i] + ": ");
//                foreach (var item in wordsInput)
//                {
//                    Console.Write(item + " ");
//                }
//                Console.WriteLine();



//            }
//            swatch.Stop();

//            Console.WriteLine(swatch.ElapsedMilliseconds + "ms");

//            f.Close();
//            g.Close();
//        }

//    }
//}



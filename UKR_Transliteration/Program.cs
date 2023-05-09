using System;

namespace Transliteration {

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Transliteration.TranslateSentence("11а"));
        }
    }

    public static class Transliteration
    {
        static Dictionary<string, string> table_char = new Dictionary<string, string>() {
            {"а", "a" },
            {"б","b" },
            {"в","v" },
            {"г","h" },
            {"д","d" },
            {"е","e" },
            {"є","ie" },
            {"ж","zh" },
            {"з","z" },
            {"и","y" },
            {"і","i" },
            {"ї","i" },
            {"й","i" },
            {"к","k" },
            {"л","l" },
            {"м","m" },
            {"н","n" },
            {"о","o" },
            {"п","p" },
            {"р","r" },
            {"с","s" },
            {"т","t" },
            {"у","u" },
            {"ф","f" },
            {"х","kh" },
            {"ц","ts" },
            {"ч","ch" },
            {"ш","sh" },
            {"щ","shch" },
            {"ю","iu" },
            {"я","ia" },
        };

        static Dictionary<string, string> extra_table_char = new Dictionary<string, string>() {

            {"є", "ye" },
            {"ї", "yi" },
            {"ю", "yu" },
            {"я", "ya" },
        };

        public static string TranslateWord(string str)
        {
            string result ="";
            string ch = "";

            for(int i=0; i< str.Length; i++)
            {
                
                if(i == 0)
                {
                    if (!extra_table_char.TryGetValue(str[i].ToString().ToLower(), out ch))
                    {
                        if(!table_char.TryGetValue(str[i].ToString().ToLower(), out ch))
                        {
                            ch = str[i].ToString().ToLower();
                        }
                    }

                    if (Char.IsUpper(str[i]))
                    {
                        ch = FirstCharToUpper(ch);
                    }
                    result += ch;
                }
                else
                {
                    
                    if(!table_char.TryGetValue(str[i].ToString(), out ch))
                    {
                        ch += str[i].ToString();
                    }
                    result += ch;
                }
            }
            return result;
        }

        public static string TranslateSentence(string str)
        {
            
            string[] words = str.Split(" ");

            for(int i=0; i< words.Length;i++)
            {
                words[i] = TranslateWord(words[i]);
            }

            return string.Join(" ", words);

        }
        public static string FirstCharToUpper(string input)
        {
            string res = "";
            for(int i=0; i< input.Length ; i++)
            {
                if (i == 0)
                {
                    res += Char.ToUpper(input[i]);
                    continue;
                }
                res += input[i];
            }
            return res;
        }
    }




}
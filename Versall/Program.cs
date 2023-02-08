using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Versall
{
    internal class Program
    {
       
     


        static void Main(string[] args)
        {
            //алфавит массив букв с типом данных Char
            char[] alphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray();

            string word1 = "Sony";
            string word2 = "Hewlett";
            string word3 = "Packard";
            string res = "";

         

            

            res+=Symbol_1(word1,word3);
            res+=Symbol_2(word2);
            res+=Symbol_3(word3);

            //res += Symbol_1v2(word1);
            Console.WriteLine(res);

            string pass = "";
            
            ConsoleKeyInfo key;
            while (true)
            {
                Console.Write("Введи пароль: ");
                do
                {
                    key = Console.ReadKey(true);

                    // Backspace Should Not Work
                    if (key.Key != ConsoleKey.Backspace)
                    {
                        if (key.Key != ConsoleKey.Enter)
                        {
                            pass += key.KeyChar;
                            Console.Write("*");
                        }

                    }
                    else
                    {
                        Console.Write("\b");
                    }
                }

                while (key.Key != ConsoleKey.Enter);

                if (pass.ToLower() == res.ToLower())
                {
                    Console.WriteLine("\n\tПароль верный "+ pass);
                    break;
                }
                else
                {
                    Console.WriteLine("\n\tПароль неверный");
                    pass = "";
                }
               
            }
           
            
           


            
            Console.ReadKey();




            char Symbol_1(string slovo1, string slovo3)
            {
                int len = slovo1.Length + slovo3.Length-1;
                
                if (len >= 26)
                {
                    int num = len % 26;
                    return alphabet[num];
                }
               
                return alphabet[len];
            }

            char Symbol_1v2(string slovo1)
            {
                string firstsym = slovo1[0].ToString().ToLowerInvariant();


                int num = Array.FindIndex(alphabet, val => val == firstsym[0]);
                if (num == 25)
                {
                    return alphabet[0];
                }
                return alphabet[num + 1];
            }

            char Symbol_2(string slovo2)
            {
                int len = slovo2.Length;
                char lastsym = slovo2[len-1];
                int num = Array.FindIndex(alphabet, val => val == lastsym);

                
                    
                if (num==0)
                {
                    return alphabet[25];
                }

                return alphabet[num-1];
            }

            char Symbol_3(string slovo3)
            {
                int len = slovo3.Length;
                
                if (len %2 == 0)
                {
                    
                    int polovina = len / 2;

                    char centersym = slovo3[polovina-1];
                
                    int num = Array.FindIndex(alphabet, val => val == centersym);

                    if (num == 25)
                    {
                        return alphabet[0];
                    }
                    return alphabet[num + 1];

                }
                
                if(len %2 != 0)
                {
                    int polovina =len /2;
                   
                    char centersym = slovo3[polovina];
                    int num = Array.FindIndex(alphabet, val => val==centersym);

                    if (num==25)
                    {
                        return alphabet[0];
                    }
                    return alphabet[num+1];

                }


                return '1';
                
            }

            

        }


        
    }
}

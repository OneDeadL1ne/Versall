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


            //функия на первый символ(условие номер 1)

            char Symbol_1(string slovo1, string slovo3)
            {
                //суммарная длина 1 и 2 слова
                int len = slovo1.Length + slovo3.Length - 1;

                //проверка если суммарная длина больше букв в алфавите
                if (len >= 26)
                {
                    //остаток от деления 
                    int num = len % 26;

                    //возврашиение результата
                    return alphabet[num];
                }

                //возврашиение результата
                return alphabet[len];
            }


            //функция на первый символ(условие номер 4)
            char Symbol_1v2(string slovo1)
            {
                //нахожу первый символ слова
                string firstsym = slovo1[0].ToString().ToLowerInvariant();


                //ищу порядковый номер в алфавите первой буквы слова 
                int num = Array.FindIndex(alphabet, val => val == firstsym[0]);

                //проверка на букву Z
                if (num == 25)
                {
                    //возваращяю букву A
                    return alphabet[0];
                }
                //возвращаю следущую букву
                return alphabet[num + 1];
            }


            //функция на последную букву слова (условие номер 2)
            char Symbol_2(string slovo2)
            {
                //нахожу длину слова
                int len = slovo2.Length;
                
                //нахожу последнюю букву в слове
                char lastsym = slovo2[len - 1];

                //ищу порядковый номер в алфавите первой буквы слова
                int num = Array.FindIndex(alphabet, val => val == lastsym);


                //проверяю на букву A
                if (num == 0)
                {
                    //возваращаю букву Z
                    return alphabet[25];
                }

                //возвращаю предыдущую букву
                return alphabet[num - 1];
            }


            //функция на четность /нечетность (условие номер 3)
            char Symbol_3(string slovo3)
            {
                //узнаю длинну слова
                int len = slovo3.Length;

                //проверяю на четность 
                if (len % 2 == 0)
                {
                    //узнаю половину количества симолов в слове
                    int polovina = len / 2;

                    //нахожу первый центральный символ
                    char centersym = slovo3[polovina - 1];

                    //ищу порядковый номер в алфавите первой буквы слова
                    int num = Array.FindIndex(alphabet, val => val == centersym);


                    //проверяю на букву А
                    if (num == 0)
                    {
                        //возвращаю букву Z
                        return alphabet[25];
                    }
                    //возвращаю предыдущую букву
                    return alphabet[num - 1];

                }

                //проверяю на нечетность
                if (len % 2 != 0)
                {
                    //узнаю половину количества симолов в слове
                    int polovina = len / 2;

                    //нахожу центральный символ
                    char centersym = slovo3[polovina];

                    //ищу порядковый номер в алфавите первой буквы слова
                    int num = Array.FindIndex(alphabet, val => val == centersym);

                    //проверяю на букву Z
                    if (num == 25)
                    {
                        //возвращаю букву А
                        return alphabet[0];
                    }
                    //возвращаю следующую букву
                    return alphabet[num + 1];

                }


                return '1';

            }


            string word1 = "Sony";

            string word2 = "Hewlett";

            string word3 = "Packard";

            string res = "";

            res+=Symbol_1(word1,word3);

            res+=Symbol_2(word2);

            res+=Symbol_3(word3);

            //res += Symbol_1v2(word1);


            //вывод результата на консоль
            
            Console.WriteLine(res);


            
            string pass = "";

            //создаю обьект класса клавиатуры
            ConsoleKeyInfo key;

            //цикл While
            while (true)
            {
                Console.Write("Введи пароль: ");

                //цикл do while
                do
                {
                    key = Console.ReadKey(true);

                    
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
                    Console.WriteLine("\n\tПароль верный " + pass);
                    break;
                }
                else
                {
                    Console.WriteLine("\n\tПароль неверный");
                    pass = "";
                }

            }

            Console.ReadKey();

        }


        
    }
}

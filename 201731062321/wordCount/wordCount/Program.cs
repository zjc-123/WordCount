using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;


namespace wordCount
{
    class Program
    {
<<<<<<< HEAD
        static void Main(string[] args)
        {
          /*  string path = null ;
            string Len = null ;
            string outpath = null;


            for (int i = 0; i < args.Length; i++)//附加功能
            {
                switch (args[i])
                {
                    case "-i":
                        path = args[i + 1];
                        break;
                    case "-n":
                        Len = args[i + 1];
                        break;
                    case "-o":
                        outpath = args[i + 1];
                        break;
                        
                }
            }*/
           Console.WriteLine("输入读入文件的详细位置：");
            string path = Console.ReadLine();
          Console.WriteLine("输入输出文件的详细位置：");
           string outpath = Console.ReadLine();


            //outpath = Console.ReadLine();
            ReadChar.readFilechar(path,outpath);//统计文件的行数和字符数

            Console.WriteLine("输入要查询单词的长度:(length>3)");
            int len = Convert.ToInt32(Console.ReadLine());
           // int lens = Convert.ToInt32(Len);
           ReadWord.readW(path,len,outpath);//统计文件中单词频率和出现次数最多的十个单词
           

            Console.ReadLine();
        }
=======
        static void Main()
        {

            Console.WriteLine("输入读入文件的详细位置：");
            string path = Console.ReadLine();
            // readFileLines(path);
            readFilechar(path); //统计文件的行数和字符数
            //readWord(path);

            string text = File.ReadAllText(path);
            readW(text);//统计文件中单词频率



            Console.ReadLine();
        }

        /* public static void readFileLines(string path)  //统计文件中的行数和字符数
         {
             string despath = @"C:\Users\Administrator\Desktop\wordCount\write.txt";
             int lines = 0;  //用来统计txt行数
             string str;
             if (File.Exists(path))
             {
                 StreamReader sr = new StreamReader(path);

                 while (sr.ReadLine() != null)
                 {
                     lines++;
                 }
                 StreamWriter sw = File.AppendText(despath);
                 sw.WriteLine("该文件行数为：" + lines);
                 Console.WriteLine("该文件行数为:" + lines);
                 sw.Flush();
                 sw.Close();
             }
             else
             {
                 Console.WriteLine("文件不存在，以为你在相应位置创建,可在此处写入内容。");
                 File.Create(path).Dispose();
             }

         }*/

        public static void readFilechar(string path)
        {

            try
            {
                string str = File.ReadAllText(path);
                int hz = Regex.Matches(str, @"[\u4E00-\u9FFF]").Count;//汉字
                // int en = Regex .Matches ( str , "[A-Za-z]" ) .Count; 
                int en = str.Length;//字符
                int num = Regex.Matches(str, @"\d").Count;//数字
                int hang = Regex.Matches(str, @"\r").Count + 1;//行数
                // int yin= Regex.Matches(str, @"\w").Count;

                Console.WriteLine("汉字个数={0}\n字符个数(包括空格、标点、换行符)={1}\n数字个数={2}\n行数={3}", hz, en, num, hang);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }

        public static void readW(string path)
        {

            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            frequencies = new Dictionary<string, int>();

            string[] words = Regex.Split(path, @"\W");

            foreach (string word in words)
            {
                if (frequencies.ContainsKey(word))
                {
                    frequencies[word]++;
                }
                else
                {
                    frequencies[word] = 1;
                }
                if (word.Length < 4)
                {
                    frequencies.Remove(word);
                }
            }

            Dictionary<string, int> ff = frequencies.OrderByDescending(o => o.Value).ThenBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);
            foreach (KeyValuePair<string, int> entry in ff.Take(10))
            {
                string word = entry.Key;
                int frequency = entry.Value;
                Console.WriteLine("{0}: {1}", word, frequency);
            }

        }




>>>>>>> a05ab4c54d485fbf0f194380f142f6a320b088fc


    }
}


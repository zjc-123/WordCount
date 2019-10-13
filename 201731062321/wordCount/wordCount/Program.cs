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


    }
}


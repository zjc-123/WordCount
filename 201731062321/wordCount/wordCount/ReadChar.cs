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
    class ReadChar
    {
        public static void readFilechar(string path, string outpath)
        {
            try
            {
                string str = File.ReadAllText(path);
                StreamWriter sw = File.AppendText(outpath);
                int hz = Regex.Matches(str, @"[\u4E00-\u9FFF]").Count;//汉字
                int en = str.Length;//字符
                int num = Regex.Matches(str, @"\d").Count;//数字
                int hang = Regex.Matches(str, @"\r").Count + 1;//行数
                Console.WriteLine("汉字个数={0}\n字符个数(包括空格、标点、换行符)={1}\n数字个数={2}\n行数={3}", hz, en, num, hang);
                sw.WriteLine("汉字个数={0}\n字符个数(包括空格、标点、换行符)={1}\n数字个数={2}\n行数={3}", hz, en, num, hang);
                sw.Flush();
                sw.Close();
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
        }
    }
}

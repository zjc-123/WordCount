using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;



namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void TestMethod1()
        {
            
   
            try
            {
                string str = File.ReadAllText(@"C:\Users\Administrator\Desktop\WordCount\201731062321\test1.txt");
                StreamWriter sw = File.AppendText(@"C:\Users\Administrator\Desktop\WordCount\201731062321\testout1.txt");
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
        [TestMethod]
        public void TestMethod2()
        {

            int Len = 8;
            string paths = File.ReadAllText(@"C:\Users\Administrator\Desktop\WordCount\201731062321\test1.txt");
            StreamWriter sw = File.AppendText( @"C:\Users\Administrator\Desktop\WordCount\201731062321\testout1.txt");
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            frequencies = new Dictionary<string, int>();
            string[] words = Regex.Split(paths, @"\W");
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
            Dictionary<string, int> ff = frequencies.OrderByDescending(o => o.Value).ThenBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);//利用key和value排序
            int count = 0;
            Dictionary<string, int>.Enumerator hh = ff.GetEnumerator();
            while (hh.MoveNext())
            {
                if (Len.Equals(hh.Current.Key.Length))
                    count = count + hh.Current.Value;
            }
            Console.WriteLine("文件中长度为" + Len + "的单词数：" + count + "个");
            Console.WriteLine("文件中单词出现频率最高的前十个单词：");
            sw.WriteLine("文件中长度为" + Len + "的单词数：" + count + "个");
            sw.WriteLine("文件中单词出现频率最高的前十个单词：");
            foreach (KeyValuePair<string, int> entry in ff.Take(10))
            {
                string word = entry.Key;
                int frequency = entry.Value;
                Console.WriteLine("{0}: {1}", word, frequency);
                sw.WriteLine("{0}: {1}", word, frequency);
            }
            //Console.WriteLine("输出结果已经写入到文件：{0}", outpath);
            sw.Flush();
            sw.Close();
        }

        [TestMethod]
        public void TestMethod3()
        {

            int Len = 5;
            string paths = File.ReadAllText(@"C:\Users\Administrator\Desktop\WordCount\201731062321\test1.txt");
            StreamWriter sw = File.AppendText(@"C:\Users\Administrator\Desktop\WordCount\201731062321\testout1.txt");
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            frequencies = new Dictionary<string, int>();
            string[] words = Regex.Split(paths, @"\W");
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
            Dictionary<string, int> ff = frequencies.OrderByDescending(o => o.Value).ThenBy(p => p.Key).ToDictionary(p => p.Key, o => o.Value);//利用key和value排序
            int count = 0;
            Dictionary<string, int>.Enumerator hh = ff.GetEnumerator();
            while (hh.MoveNext())
            {
                if (Len.Equals(hh.Current.Key.Length))
                    count = count + hh.Current.Value;
            }
            Console.WriteLine("文件中长度为" + Len + "的单词数：" + count + "个");
            Console.WriteLine("文件中单词出现频率最高的前十个单词：");
            sw.WriteLine("文件中长度为" + Len + "的单词数：" + count + "个");
            sw.WriteLine("文件中单词出现频率最高的前十个单词：");
            foreach (KeyValuePair<string, int> entry in ff.Take(10))
            {
                string word = entry.Key;
                int frequency = entry.Value;
                Console.WriteLine("{0}: {1}", word, frequency);
                sw.WriteLine("{0}: {1}", word, frequency);
            }
            //Console.WriteLine("输出结果已经写入到文件：{0}", outpath);
            sw.Flush();
            sw.Close();
        }



    }
}

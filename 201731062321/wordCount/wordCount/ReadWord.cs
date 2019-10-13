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
    class ReadWord
    {

        public static void readW(string path, int Len, string outpath)
        {

            string paths = File.ReadAllText(path);
            StreamWriter sw = File.AppendText(outpath);
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
            Console.WriteLine("输出结果已经写入到文件：{0}",outpath);
            sw.Flush();
            sw.Close();
        }
    }
}

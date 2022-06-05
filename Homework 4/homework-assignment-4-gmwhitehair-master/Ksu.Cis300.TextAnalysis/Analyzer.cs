/* Analyzer.cs
 * Author: Gabriel Whitehair
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Ksu.Cis300.TextAnalysis
{
    /// <summary>
    /// Analyzer class for getting differences and frequency tables
    /// </summary>
    public static class Analyzer
    {
        /// <summary>
        /// Formatting for reading in strings
        /// </summary>
        private const string _splitExpression = "[^a-z]+";
        /// <summary>
        /// Public Method 1: GetFrequencyTables. Iterates through file in directory and returns a frequency table. Method calls private methods ReadIn on each iteration.
        /// </summary>
        /// <param name="path">Full path to folder.</param>
        /// <returns>Frequency table with key as file name and value as dictionary with key as word and value as frequency.</returns>
        public static Dictionary<string, Dictionary<string, float>> GetFrequencyTables(string path)
        {
            DirectoryInfo folder = new DirectoryInfo(path);
            Dictionary<string, Dictionary<string, float>> frequencyTable = new Dictionary<string, Dictionary<string, float>>();
            foreach (FileInfo file in folder.GetFiles()) // for each file
            {
                ReadIn(file, frequencyTable);
            }
            return frequencyTable;
        }
        /// <summary>
        /// Private Method 1: ReadIn. Uses a StreamReader to read in each file and count the number of words. Calls ConvertTable to convert to a frequency table after done reading in.
        /// </summary>
        /// <param name="file">FileInfo of the file to be read in.</param>
        /// <param name="frequencyTable">Frequency table to be added to. Value will make a call to ConvertTable in add method.</param>
        private static void ReadIn(FileInfo file, Dictionary<string, Dictionary<string, float>> frequencyTable)
        {
            using (StreamReader sr = new StreamReader(file.FullName))
            {
                string line;
                Dictionary<string, int> wordCount = new Dictionary<string, int>();
                int totalCount = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    line = line.ToLower();
                    string[] words = Regex.Split(line, _splitExpression);
                    int count = 0;
                    foreach (string s in words)
                    {
                        int occurances = 0;
                        bool found = wordCount.TryGetValue(s, out occurances);
                        if (found)
                        {
                            wordCount[s] = occurances + 1;
                            count++;
                        }
                        else if (s != "" && !found)
                        {
                            wordCount.Add(s, 1);
                            count++;
                        }
                    }
                    totalCount += count;
                }
                frequencyTable.Add(file.Name, ConvertTable(wordCount, totalCount));
            }
        }
        /// <summary>
        /// Private Method 2: ConvertTable. Converts the value int dictionary to a value float dictionary while dividing by the total number of words. 
        /// </summary>
        /// <param name="wordCount">Dictionary with words as keys and their count as values.</param>
        /// <param name="totalCount">Total number of words in the file.</param>
        /// <returns>Dictionary with key as the word and float as the frequency.</returns>
        private static Dictionary<string, float> ConvertTable(Dictionary<string,int> wordCount, int totalCount)
        {
            Dictionary<string, float> frequencies = new Dictionary<string, float>();
            foreach (KeyValuePair<string, int> kvp in wordCount)
            {
                float countValue = kvp.Value;
                float freqValue = countValue / totalCount;
                frequencies.Add(kvp.Key, freqValue);
            }
            return frequencies;
        }
        /// <summary>
        /// Public Method 2: GetDifference. Get's the difference for the difference column and makes a call to PQBuilder to build a priority queue.
        /// </summary>
        /// <param name="d1">Dictionary of key string and value float (word, frequency) to be compared to d2.</param>
        /// <param name="d2">Dictionary of key string and value float (word, frequency) to be compared to d1.</param>
        /// <param name="maxWords">Max words as set by the user in the up/down.</param>
        /// <returns>Float of the difference algorithm.</returns>
        public static float GetDifference(Dictionary<string,float> d1, Dictionary<string,float> d2, int maxWords)
        {
            MinPriorityQueue<float, string> pq = PQBuilder(d1, d2, maxWords);
            if (pq.Count == 0)
            {
                return float.PositiveInfinity;
            }
            float sum = 0;
            while (pq.Count > 0)
            {
                string pqWord = pq.RemoveMinimumPriority();
                float difference = d1[pqWord] - d2[pqWord];
                sum += difference * difference;
            }
            sum = (float) Math.Sqrt(sum);
            return sum;
        }
        /// <summary>
        /// Private Method 3: PQBuilder. Builds a MinPriorityQueue using 2 dictionaries and max words. If the priority queue's count goes over max words, the code will remove the min priority. 
        /// </summary>
        /// <param name="d1">Dictionary of key string and value float (word, frequency) to be compared to d2.</param>
        /// <param name="d2">Dictionary of key string and value float (word, frequency) to be compared to d1.</param>
        /// <param name="maxWords">Max words as set by the user in the up/down.</param>
        /// <returns>MinPriorityQueue with priority as min frequency and value as the word.</returns>
        private static MinPriorityQueue<float, string> PQBuilder(Dictionary<string, float> d1, Dictionary<string, float> d2, int maxWords)
        {
            MinPriorityQueue<float, string> pq = new MinPriorityQueue<float, string>();
            foreach (KeyValuePair<string, float> word in d1)
            {
                float v;
                if (d2.TryGetValue(word.Key, out v))
                {
                    float min = Math.Min(word.Value, v);
                    pq.Add(min, word.Key);
                    if (pq.Count > maxWords)
                    {
                        pq.RemoveMinimumPriority();
                    }
                }
            }
            return pq;
        }
    }
}

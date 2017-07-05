using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class StringConcatenation
    {
        //public IList<int> FindSubstring(string s, string[] words)
        //{
        //    IList<int> res = new List<int>();
        //    if (string.IsNullOrEmpty(s) || words == null || words.Length == 0 || words[0].Length * words.Length > s.Length)
        //    {
        //        return res;
        //    }

        //    var list = GenerateList(words);
        //    int len = words[0].Length * words.Length;
        //    for(int i = 0; i + len <= s.Length; i++)
        //    {
        //        var substr = s.Substring(i, len);
        //        if(list.Contains(substr))
        //        {
        //            res.Add(i);
        //        }
        //    }

        //    return res;
        //}

        //private IList<string> GenerateList(string[] words)
        //{
        //    IList<string> res = new List<string>();
        //    IList<string> source = new List<string>(words);
        //    GenerateList(source, "", res);
        //    return res;
        //}

        //private void GenerateList(IList<string> source, string str, IList<string> res)
        //{
        //    if (source.Count == 0)
        //    {
        //        if(!res.Contains(str)) res.Add(str);
        //        return;
        //    }

        //    IList<string> copy = new List<string>(source);
        //    for (int i = 0; i < source.Count; i++)
        //    {
        //        var item = copy[i];
        //        copy.RemoveAt(i);
        //        GenerateList(copy, str + item, res);
        //        copy.Insert(i, item);
        //    }
        //}

        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> res = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null) return res;

            var hash = new Dictionary<string, int>();            
            foreach (var word in words)
            {
                if (hash.ContainsKey(word)) hash[word]++;
                else hash.Add(word, 1);
            }

            int len = words[0].Length;
            int left = 0;
            for(int i = 0; i < len; i++)
            {
                var curHash = new Dictionary<string, int>();
                int count = 0;
                for(int j = i; j + len <= s.Length; j+= len)
                {
                    var sub = s.Substring(j, len);
                    if(!hash.ContainsKey(sub))
                    {
                        left = j + len;
                        curHash = new Dictionary<string, int>();
                        count = 0;
                    }
                    else
                    {
                        if (curHash.ContainsKey(sub)) curHash[sub]++;
                        else curHash.Add(sub, 1);

                        if (curHash[sub] <= hash[sub]) count++;
                        else
                        {
                            while(curHash[sub] > hash[sub])
                            {
                                var first = s.Substring(left, len);
                                curHash[first]--;
                                if(hash[first] > curHash[first]) count--;
                                left += len;
                            }
                        }

                        if(count == words.Length)
                        {
                            res.Add(left);
                            curHash[s.Substring(left, len)]--;
                            count--;
                            left += len;
                        }
                    }
                }
            }
            
            return res;
        }

        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0) return res;

            int len = nums.Length;
            var source = new List<int>(nums);
            source.Sort();
            GetList(res, source, new List<int>());
            return res;
        }

        private void GetList(IList<IList<int>> res, List<int> source, List<int> list)
        {
            res.Add(new List<int>(list));

            var copy = new List<int>(source);
            for (int i = 0; i < source.Count; i++)
            {
                if (i > 0 && source[i - 1] == source[i]) continue;
                int val = copy[i];
                copy.RemoveAt(i);
                list.Add(val);
                GetList(res, copy, list);
                copy.Insert(i, val);
                list.RemoveAt(list.Count - 1);
            }
        }


        IList<string> list;
        /** Initialize your data structure here. */
        public void WordDictionary()
        {
            list = new List<string>();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            if (!list.Contains(word)) list.Add(word);
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            foreach (var item in list)
            {
                if (Matched(item, word)) return true;
            }

            return false;
        }

        private bool Matched(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            if (!str1.Contains(".") && !str2.Contains(".") && str1 != str2) return false;

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] == '.' || str2[i] == '.' || str1[i] == str2[i]) continue;
                return false;
            }
            return true;
        }

        public int FindLUSlength(string[] strs)
        {
            if (strs == null || strs.Length == 0) return 0;
            var hash = new Dictionary<string, int>();

            var list = new List<string>(strs);
            list.Sort((i, j) => {
                if (i.Length < j.Length) return 1;
                if (i.Length > j.Length) return -1;
                return 0;
            });

            for (int i = 0; i < list.Count; i++)
            {
                bool longest = true;
                for (int j = 0; j < list.Count; j++)
                {
                    if (i == j) continue;
                    longest &= GetLen(list[i], list[j]) != -1;
                }
                if (!longest) return list[i].Length;
            }

            return -1;
        }

        private int GetLen(string s1, string s2)
        {
            if (s1.Length == s2.Length)
            {
                if (s1 != s2) return s1.Length;
                return -1;
            }

            if (s1.Length < s2.Length)
            {
                string t = s1;
                s1 = s2;
                s2 = t;
            }

            int j = 0;
            for (int i = 0; i < s2.Length; i++)
            {
                if (s2[j] == s1[i]) j++;
                else continue;
                if (j == s2.Length) return -1;
            }

            return s2.Length;
        }
    }
}

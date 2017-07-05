using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class WordBreak
    {
        public bool GetPossibleList(string str, IList<string> dict)
        {
            if (str == null || str.Length == 0)
            {
                return false;
            }

            bool[] arr = new bool[str.Length + 1];
            arr[0] = true;
            for (int i = 1; i <= str.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    string subStr = str.Substring(j, i - j);
                    if (dict.Contains(subStr) && arr[j] == true)
                    {
                        arr[i] = true;
                        break;
                    }
                }
            }

            return arr[str.Length];
        }

        public IList<string> WorkBreakII(string str, IList<string> dict)
        {
            IList<string> result = new List<string>();
            if (str == null || str.Length == 0)
            {
                return result;
            }

            Trie root = new Trie();
            foreach (string item in dict)
            {
                root.Insert(item);
            }

            //helper(result, root, "", str, 0);
            return result;
        }

        private void helper(IList<string> result, Trie node, string cur, string target, int index)
        {
            if (index >= target.Length)
            {
                result.Add(cur.Trim());
            }

            for (int i = index + 1; i <= target.Length; i++)
            {
                string substr = target.Substring(index, i - index);
                if (!node.IsStartWith(substr))
                {
                    break;
                }

                if (node.IsContains(substr))
                {
                    string newstr = cur + " " + substr;
                    string newTarget = target.Remove(index, i - index);
                    helper(result, node, newstr, newTarget, 0);
                }
            }
        }

        class TrieNode
        {
            public TrieNode[] children;
            public bool isEnd;
            public TrieNode()
            {
                children = new TrieNode[26];
                isEnd = false;
            }
        }

        class Trie
        {
            private TrieNode root;
            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string str)
            {
                TrieNode node = root;
                for (int i = 0; i < str.Length; i++)
                {
                    int index = str[i] - 'a';
                    if (node.children[index] != null)
                    {
                        node = node.children[index];
                    }
                    else
                    {
                        TrieNode cur = new TrieNode();
                        node.children[index] = cur;
                        node = node.children[index];
                    }
                }
                node.isEnd = true;
            }

            public bool IsStartWith(string str)
            {
                var node = this.Contains(str);
                if (node != null)
                {
                    return true;
                }

                return false;
            }

            public bool IsContains(string str)
            {
                var node = this.Contains(str);
                if (node != null && node.isEnd)
                {
                    return true;
                }

                return false;
            }

            private TrieNode Contains(string str)
            {
                if (string.IsNullOrEmpty(str))
                {
                    return null;
                }

                TrieNode node = root;
                for (int i = 0; i < str.Length; i++)
                {
                    int index = str[i] - 'a';
                    if (node.children[index] == null)
                    {
                        return null;
                    }
                    else
                    {
                        node = node.children[index];
                    }
                }

                return node;
            }
        }


        //public List<String> wordBreak(String s, Set<String> wordDict)
        //{
        //    return DFS(s, wordDict, new HashMap<String, LinkedList<String>>());
        //}

        //// DFS function returns an array including all substrings derived from s.
        //List<String> DFS(String s, Set<String> wordDict, HashMap<String, LinkedList<String>> map)
        //{
        //    if (map.containsKey(s))
        //        return map.get(s);

        //    LinkedList<String> res = new LinkedList<String>();
        //    if (s.length() == 0)
        //    {
        //        res.add("");
        //        return res;
        //    }
        //    for (String word : wordDict)
        //    {
        //        if (s.startsWith(word))
        //        {
        //            List<String> sublist = DFS(s.substring(word.length()), wordDict, map);
        //            for (String sub : sublist)
        //                res.add(word + (sub.isEmpty() ? "" : " ") + sub);
        //        }
        //    }
        //    map.put(s, res);
        //    return res;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class AddAndSearchWord
    {
        /** Initialize your data structure here. */

        Trie trie;
        public AddAndSearchWord()
        {
            trie = new Trie();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            trie.AddValue(word);
        }

        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            return Trie.SearchWithExpress(word, trie.node);
        }

        public class TrieNode
        {
            public TrieNode[] nodes;
            public bool isEnd;
            public TrieNode()
            {
                nodes = new TrieNode[26];
            }
        }

        public class Trie
        {
            public TrieNode node;

            public Trie()
            {
                node = new TrieNode();
            }

            public void AddValue(string str)
            {
                var cur = node;
                int i = 0;
                while (i < str.Length)
                {
                    int val = str[i++] - 'a';
                    if (cur.nodes[val] == null)
                    {
                        cur.nodes[val] = new TrieNode();
                    }
                    cur = cur.nodes[val];
                }

                cur.isEnd = true;
            }

            public static bool SearchWithExpress(string str, TrieNode trie)
            {
                if (trie == null) return false;
                if (str == string.Empty) return trie.isEnd;

                int i = 0;
                while (i < str.Length)
                {
                    if (str[i] != '.')
                    {
                        trie = trie.nodes[str[i] - 'a'];
                        if (trie == null) return false;
                    }
                    else
                    {
                        str = str.Substring(i + 1);
                        for (int j = 0; j < 26; j++)
                        {
                            var res = SearchWithExpress(str, trie.nodes[j]);
                            if (res) return true;
                        }
                        return false;
                    }

                    i++;
                }

                if (trie.isEnd) return true;
                return false;
            }
        }
    }
}

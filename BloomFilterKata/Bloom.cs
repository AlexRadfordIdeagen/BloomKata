using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloomFilterKata
{
    public class Bloom
    {
        const int m = 6496427;
        const int k = 13;
        BitArray _bloom = new BitArray(m);
        private int[] Hashk(string s, int k)
        {
            int[] hashes = new int[k];
            hashes[0] = Math.Abs(s.GetHashCode());
            Random R = new Random(hashes[0]);
            for (int i = 0; i < k; i++)
            {
                hashes[i] = R.Next();
            }
            return hashes;
        }
        public void AddData(string s)
        {
            int[] hashes = Hashk(s, k);
            for (int i = 0; i < k; i++)
            {
                _bloom.Set(hashes[i] % m, true);
            }
        }

        public Boolean Lookup(string s)
        {
            int[] hashes = Hashk(s, k);
            for (int i = 0; i < k; i++)
            {
                if (_bloom[hashes[i] % m] == false)
                    return false;
            }
        return true;
        }
    }
}

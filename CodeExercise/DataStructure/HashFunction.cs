using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class HashFunction
    {
        private readonly int MagiNumber = 33;

        /// <summary>
        /// lint 128
        /// https://www.lintcode.com/en/old/problem/hash-function/
        /// In data structure Hash, hash function is used to convert a string(or any other type) into an integer smaller than hash size and bigger or equal to zero. The objective of designing a hash function is to "hash" the key as unreasonable as possible. A good hash function can avoid collision as less as possible. A widely used hash function algorithm is using a magic number 33, consider any string as a 33 based big integer like follow:
        /// hashcode("abcd") = (ascii(a) * 333 + ascii(b) * 332 + ascii(c) *33 + ascii(d)) % HASH_SIZE 
        /// 
        ///                               = (97* 333 + 98 * 332 + 99 * 33 +100) % HASH_SIZE
        /// 
        ///                               = 3595978 % HASH_SIZE
        /// 
        /// here HASH_SIZE is the capacity of the hash table(you can assume a hash table is like an array with index 0 ~HASH_SIZE-1).
        /// 
        /// Given a string as a key and the size of hash table, return the hash value of this key.f
        /// 

        ///Example
        ///For key= "abcd" and size = 100, return 78
        /// </summary>
        /// <param name="key"></param>
        /// <param name="HASH_SIZE"></param>
        /// <returns></returns>
        public int HashCode(char[] key, int HASH_SIZE)
        {
            int len = key.Length;
            int code = 0;

            foreach(var c in key)
            {
                code = (code * MagiNumber + c)%HASH_SIZE;
            }

            return code;
        }
    }
}

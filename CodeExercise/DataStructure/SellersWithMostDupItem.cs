using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    /// <summary>
    /// Amazon question.
    /// 
    /// [seller]    sell product
    /// seller1    {prod1, prod2,prod3}
    /// seller2,          {prod2,prod3}
    /// seller3,                {prod3}
    /// seller4,                       {prod4}
    /// 
    /// find sellers whos sells the most duplicate products
    /// 
    /// sol
    /// prod2, prod3 are dup products,  both s1 and s2 sells them  (s3 only sell one of it, so not the most canididate), return {s1, s2}
    /// 
    /// </summary>
    class SellersWithMostDupItem
    {
        /// <summary>
        /// {"s1,p1", "s1,p2", "s1,p3", "s2,p2", "s2,"p3", "s3,p3", "s4, p4"}
        /// </summary>
        /// <param name="sellerProdPairs"></param>
        /// <returns></returns>
        public List<string> FindSellers(List<string> sellerProdPairs)
        {
            Dictionary<string, HashSet<string>> sellerProd = new Dictionary<string, HashSet<string>>();
            Dictionary<string, int> prodSellFreq = new Dictionary<string, int>();
            HashSet<string> dupProd = new HashSet<string>();

            foreach(var pairStr in sellerProdPairs)
            {
                var pair = pairStr.Split(',');
                
                // seller - {products}
                if (!sellerProd.ContainsKey(pair[0]))
                {
                    sellerProd.Add(pair[0], new HashSet<string>());
                }
                sellerProd[pair[0]].Add(pair[1]);

                // products freq
                if (!prodSellFreq.ContainsKey(pair[1]))
                {
                    prodSellFreq.Add(pair[1], 0);
                }
                prodSellFreq[pair[1]]++;

                // find dup prods
                if (prodSellFreq[pair[1]]> 1)
                {
                    dupProd.Add(pair[1]);
                }
            }

            // find each seller's dup prod count
            int maxcount = 0;
            Dictionary<string, int> sellerDupCount = new Dictionary<string, int>();
            foreach(var seller in sellerProd.Keys)
            {
                var products = sellerProd[seller];
                foreach(var prod in products)
                {
                    if (dupProd.Contains(prod))
                    {
                        if (!sellerDupCount.ContainsKey(seller))
                        {
                            sellerDupCount.Add(seller, 0);
                        }
                        sellerDupCount[seller]++;

                        maxcount = Math.Max(maxcount, sellerDupCount[seller]);
                    }
                }
            }
            List<string> ans = new List<string>();
            foreach(var seller in sellerDupCount.Keys)
            {
                if (sellerDupCount[seller] == maxcount)
                {
                    ans.Add(seller);
                }
            }

            return ans;
        }
    }
}

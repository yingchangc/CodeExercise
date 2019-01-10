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
            HashSet<string> allProds = new HashSet<string>();
            HashSet<string> dupProd = new HashSet<string>();

            // get dup prods
            foreach(var pairStr in sellerProdPairs)
            {
                var pair = pairStr.Split(',');
                
                // products freq
                if (!allProds.Contains(pair[1]))
                {
                    allProds.Add(pair[1]);
                }
                else
                {
                    dupProd.Add(pair[1]);
                }        
            }

            // find each seller's dup prod count
            int maxcount = 0;
            Dictionary<string, int> sellerDupCount = new Dictionary<string, int>();
            foreach (var pairStr in sellerProdPairs)
            {
                var pair = pairStr.Split(',');

                if (dupProd.Contains(pair[1]))
                {
                    if (!sellerDupCount.ContainsKey(pair[0]))
                    {
                        sellerDupCount.Add(pair[0], 0);
                    }
                    var dupCount = ++sellerDupCount[pair[0]];
                    maxcount = Math.Max(maxcount, dupCount);
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

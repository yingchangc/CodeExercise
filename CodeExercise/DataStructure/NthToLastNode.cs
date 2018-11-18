using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.DataStructure
{
    class NthToLastNode
    {
        /// <summary>
        /// Amazon
        /// 
        /// Return Nth to last node of the LL
        /// 
        /// ex
        /// 
        /// 1 -> 2 -> 3 -> 4    k = 2
        /// 
        /// return 3
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public ListNode FindNtoLastNode(ListNode head, int k)
        {
            ListNode nF = head;
            
            // move k steps
            for(int i = 0; i <k; i++)
            {
                if (nF ==null)
                {
                    return null;
                }
                nF = nF.next;
            }

            ListNode nB = head;
            while(nF != null)
            {
                nF = nF.next;
                nB = nB.next;
            }

            return nB;
        }
    }
}

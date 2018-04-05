using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{
    class Document
    {
        public int id;
        public String content;
    }

    class InvertedIndex
    {
        /// <summary>
        /// Given a list of documents with id and content. (class Document)
        ///[
        ///    {
        ///    "id": 1,
        ///            "content": "This is the content of document 1 it is very short"
        ///    },
        ///  {
        ///    "id": 2,
        ///    "content": "This is the content of document 2 it is very long bilabial bilabial heheh hahaha ..."
        ///  },
        ///]
        ///Return an inverted index(HashMap with key is the word and value is a list of document ids).
        ///
        ///{
        ///   "This": [1, 2],
        ///   "is": [1, 2],
        ///   ...
        ///}
        /// </summary>
        /// <param name="docs"></param>
        /// <returns></returns>
        public Dictionary<String, List<int>> InvertedIndexInjection(List<Document> docs)
        {
            Dictionary<string, List<int>> termsPosting = new Dictionary<string, List<int>>();

            foreach(var doc in docs)
            {
                Injection(doc, termsPosting);
            }

            return termsPosting;
        }

        private void Injection(Document doc, Dictionary<string, List<int>> termsPosting)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string content = doc.content;

            string[] tokens = content.Split(delimiterChars);

            foreach(var token in tokens)
            {
                if (!termsPosting.ContainsKey(token))
                {
                    termsPosting.Add(token, new List<int>());
                }
                termsPosting[token].Add(doc.id);
            }
        }
    }
}

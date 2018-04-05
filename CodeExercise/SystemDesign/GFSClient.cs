using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeExercise.SystemDesign
{

    class BaseGFSClient {
        private Dictionary<String, String> chunk_list;
        public BaseGFSClient()
        {
            chunk_list = new Dictionary<string, string>();
        }
        public String readChunk(String filename, int chunkIndex) {

            string key = filename + "_" + chunkIndex;
            if (chunk_list.ContainsKey(key))
            {
                return chunk_list[key];
            }

            return string.Empty;

        }
        public void writeChunk(String filename, int chunkIndex,
                               String content) {
            chunk_list.Add(filename + "_" + chunkIndex, content);
        }
    }



    /// <summary>
    /// 566 lint
    /// http://www.lintcode.com/en/problem/gfs-client/
    /// Implement a simple client for GFS (Google File System, a distributed file system), it provides the following methods:

    ///read(filename). Read the file with given filename from GFS.
    ///write(filename, content). Write a file with given filename & content to GFS.
    ///There are two private methods that already implemented in the base class:
    ///
    ///readChunk(filename, chunkIndex). Read a chunk from GFS.
    ///writeChunk(filename, chunkIndex, chunkData). Write a chunk to GFS.
    ///To simplify this question, we can assume that the chunk size is chunkSize bytes. (In a real world system, it is 64M). The GFS Client's job is splitting a file into multiple chunks (if need) and save to the remote GFS server. chunkSize will be given in the constructor. You need to call these two private methods to implement read & write methods.
    ///
    /// ex
    /// var ans = client.Read("a.txt");
    //>> null
    /// client.Write("a.txt", "Wor");
    /// //>> You don't need to return anything, but you need to call writeChunk("a.txt", 0, "World") to write a 5 bytes chunk to GFS.
    /// ans = client.Read("a.txt");
    /// //>> "Wor"
    /// client.Write("b.txt", "111112222233");
    /// ans = client.Read("b.txt");
    /// //>> You need to save "11111" at chink 0, "22222" at chunk 1, "33" at chunk 2.
    /// client.Write("c.txt", "aaaaabbbbb");
    /// ans = client.Read("c.txt");
    //>> "aaaaabbbbb"
    /// 
    /// Sol:
    /// 
    /// Important client maintains the chunck ids of the file.  Master maintains the id to ChunckServer lookup
    /// 
    /// </summary>
    class GFSClient : BaseGFSClient
    {
        Dictionary<string, int> chunkLookup;

        int cutSize = 0;

        public GFSClient(int chunkSize)
        {
            chunkLookup = new Dictionary<string, int>();
            cutSize = chunkSize;
        }

        public String Read(String filename)
        {
            StringBuilder sb = new StringBuilder();
            if (chunkLookup.ContainsKey(filename))
            {
                int NumOfChunks = chunkLookup[filename];

                for (int i = 0; i < NumOfChunks; i++)
                {
                    
                    sb.Append(readChunk(filename, i));
                }
            }

            return sb.ToString();

        }

        public void Write(String filename, String content)
        {
            int N = content.Length;
            int NumOfChunkNeeded = (N % cutSize == 0) ? N / cutSize : N / cutSize + 1;    // yic  for case 5/5 = 1  4/5 = 0,  these 2 case num chunk should be the same

            for (int i = 0; i < NumOfChunkNeeded; i++)
            {
                int start = i * cutSize;
                int len = (i * cutSize + (cutSize-1) < N) ? cutSize : (N - i * cutSize);
                string substr = content.Substring(i * cutSize, len);
                writeChunk(filename, i, substr);
            }

            chunkLookup.Add(filename, NumOfChunkNeeded);

            
        }
    }
}

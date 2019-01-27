using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace CodeExercise.SystemDesign
{
    public class TokenBucket
    {
        private float qps;
        private int tokens;
        private static readonly object _obj = new object();
        private readonly Stopwatch clock;
        private long lastAddTime;
        private readonly int maxTokens;

        public TokenBucket(float qps, int initSize)
        {
            this.qps = qps;
            this.tokens = initSize;
            clock = Stopwatch.StartNew();
            this.lastAddTime = clock.ElapsedMilliseconds;
            maxTokens = initSize;
        }

        public bool Use()
        {
            if (tokens <= 0)
            {
                AddTokens();
            }
            
            if (tokens > 0)
            {
                // allow overrdraft
                Interlocked.Decrement(ref this.tokens);
                return true;
            }

            return false;
        }

        private void AddTokens()
        {
            lock (_obj)
            {
                var now = clock.ElapsedMilliseconds;
                var pre = this.lastAddTime;

                var toAdd = (now - pre) * qps / 1000;
                toAdd = toAdd < maxTokens ? maxTokens : toAdd;  // prevent no traffic case

                if (toAdd > 0 && (tokens + toAdd) > 0)
                {
                    tokens += tokens;
                    lastAddTime = now;
                }

            }

        }
    }
}

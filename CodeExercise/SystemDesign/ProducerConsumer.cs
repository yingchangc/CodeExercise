using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CodeExercise.SystemDesign
{
    class CakeStore
    {

        public CakeStore(int maxCount)
        {
            this.maxCakeAvaliable = maxCount;
            this.CakeCount = maxCount;
            semaphoreProducer = new SemaphoreSlim(0, maxCakeAvaliable);   // init, max  (0, 5)
            semaphoreConsumer = new SemaphoreSlim(maxCakeAvaliable, maxCakeAvaliable);  // (init, max) (5,5)  can consume immediately
        }

        private long CakeCount;
        private LinkedList<string> CakeQueue = new LinkedList<string>();
        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private Random rd = new Random();

        private int maxCakeAvaliable;

        private SemaphoreSlim semaphoreProducer;  
        private SemaphoreSlim semaphoreConsumer;  // init, max 

        public async Task<string> BuyCake()
        {
            string cakeName = string.Empty;
            semaphoreConsumer.Wait();   // max 5 init can enter

            var currCakeCount = Interlocked.Decrement(ref CakeCount);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":BuyCake: current Count" + currCakeCount);

            semaphoreProducer.Release();  // now producer can have room to produce

            //[1]
            ////var currentCakeCount = Interlocked.Read(ref CakeCount);
            //long currCakeCount = CakeCount;
            //var spinner = new SpinWait();
            //while (((currCakeCount = Interlocked.Read(ref CakeCount)) <= 0)
            //        || (Interlocked.CompareExchange(ref CakeCount, currCakeCount - 1, currCakeCount) != currCakeCount))
            //{
            //    spinner.SpinOnce();        
            //}
            //PrintCakeCount(Thread.CurrentThread.ManagedThreadId + ":BuyCake: before Count" + currCakeCount);

            //[2]
            //bool succeeded = false;
            //while (!succeeded)
            //{
            //    try
            //    {
            //        await semaphore.WaitAsync();

            //        var tempCakeCont = Interlocked.Read(ref CakeCount);
            //        if (CakeCount > 0)
            //        {
            //            Interlocked.Decrement(ref CakeCount);
            //            cakeName = CakeQueue.LastOrDefault();
            //            CakeQueue.RemoveLast();
            //            PrintCakeCount(Thread.CurrentThread.ManagedThreadId + ":BuyCake");
            //            succeeded = true;
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("BuyCake Exception {0}." + e);
            //    }
            //    finally
            //    {
            //        semaphore.Release();
            //        await Task.Delay(rd.Next(10));
            //    }
            //}

            return cakeName;
        }

        private void PrintCakeCount(string action)
        {
            Console.WriteLine("After {0}, Cake Count {1}", action, CakeCount);
        }

        // can 
        public async Task PruduceCake()
        {
            semaphoreProducer.Wait();   // inti 0 means full cakes and cannot produce

            var currCakeCount = Interlocked.Increment(ref CakeCount);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + ":PruduceCake: current Count" + currCakeCount);

            semaphoreConsumer.Release(); //now consumer can move

            //[1]
            //var spinner = new SpinWait();
            //long currCakeCount = 0;
            //while (((currCakeCount = Interlocked.Read(ref CakeCount)) > maxCakeAvaliable) ||
            //    (Interlocked.CompareExchange(ref CakeCount, currCakeCount + 1, currCakeCount) != currCakeCount))     
            //{
            //    spinner.SpinOnce();
            //}

            //PrintCakeCount(Thread.CurrentThread.ManagedThreadId + ":ProduceCake: before Count:" + currCakeCount);

            //[2]
            //bool succeeded = false;
            //// Asynchronously wait to enter the Semaphore.If no-one has been granted access to the Semaphore, 
            //// code execution will proceed, otherwise this thread waits here until the semaphore is released

            //while (!succeeded)
            //{
            //    await semaphore.WaitAsync();
            //    try
            //    {
            //        if (CakeCount < maxCakeAvaliable)
            //        {
            //            Interlocked.Increment(ref CakeCount);
            //            CakeQueue.AddFirst("Cake" + DateTime.Now.Millisecond);
            //            succeeded = true;
            //            PrintCakeCount(Thread.CurrentThread.ManagedThreadId + ":ProduceCake");
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine("Produce Cake Exception {0}." + e);
            //    }
            //    finally
            //    {
            //        //When the task is ready, release the semaphore. It is vital to ALWAYS release the semaphore when we are ready, or else we will end up with a Semaphore that is forever locked.
            //        //This is why it is important to do the Release within a try...finally clause; program execution may crash or take a different path, this way you are guaranteed execution
            //        semaphore.Release();
            //        await Task.Delay(rd.Next(10));
            //    }
            //}

        }
    }

    public class ProducerConsumer
    {
        Random rd = new Random();
        CakeStore store;
        public void Simulate()
        {
            store = new CakeStore(10);

            List<Task> tasks = new List<Task>();

            int count = 40;
            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0)
                {
                    tasks.Add(CustomerBuyCake());
                }
                else
                {
                    tasks.Add(ChefProduceCake());
                }
            }
            
            Task result = Task.WhenAll(tasks);

            try
            {
                result.Wait();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

        }

        private Task CustomerBuyCake()
        {
            Task.Delay(rd.Next(100));
            return Task.Run(() => store.BuyCake());
        }

        private Task ChefProduceCake()
        {
            Task.Delay(rd.Next(100)).Wait();
            return Task.Run(()=>store.PruduceCake());
        }
    }


    
}

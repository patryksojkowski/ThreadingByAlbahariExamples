using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingByAlbahariExamples
{
    public class QueueOfTaskOneAtTime
    {
        private static readonly SemaphoreQueue semaphoreQueue = new SemaphoreQueue(2, 2);

        public static void Test()
        {
            var workers = new List<Worker>();
            var tasks = new List<Task>();

            for (int i = 0; i < 5; i ++)
            {
                var worker = new Worker(i);
                workers.Add(worker);
                tasks.Add(new Task(() => worker.Work()));
            }


            foreach (var task in tasks)
            {
                task.Start();
            }


        }

        public class Worker
        {
            int _number;
            public Worker(int number)
            {
                _number = number;
            }
            public void Work()
            {
                Console.WriteLine($"Task {_number} called and waits.");
                semaphoreQueue.Wait();

                Console.WriteLine($"Task {_number} started");
                Thread.Sleep(5000);
                Console.WriteLine($"Task {_number} done.");

                semaphoreQueue.Release();
            }
        }
    }

    public class SemaphoreQueue
    {
        private SemaphoreSlim semaphore;
        private ConcurrentQueue<TaskCompletionSource<bool>> queue =
            new ConcurrentQueue<TaskCompletionSource<bool>>();
        public SemaphoreQueue(int initialCount)
        {
            semaphore = new SemaphoreSlim(initialCount);
        }
        public SemaphoreQueue(int initialCount, int maxCount)
        {
            semaphore = new SemaphoreSlim(initialCount, maxCount);
        }
        public void Wait()
        {
            WaitAsync().Wait();
        }
        public Task WaitAsync()
        {
            var tcs = new TaskCompletionSource<bool>();
            queue.Enqueue(tcs);
            semaphore.WaitAsync().ContinueWith(t =>
            {
                TaskCompletionSource<bool> popped;
                if (queue.TryDequeue(out popped))
                    popped.SetResult(true);
            });
            return tcs.Task;
        }
        public void Release()
        {
            semaphore.Release();
        }
    }



    //public class SemaphoreQueue2
    //{
    //    private readonly SemaphoreSlim _semaphore;

    //    private readonly Queue<Task> _queue = new Queue<Task>();

    //    public SemaphoreQueue2(int count, int maxcount)
    //    {
    //        _semaphore = new SemaphoreSlim(count, maxcount);
    //    }

    //    public void Add(Task task)
    //    {
    //        _queue.Enqueue(new Task(() => 
    //        {
    //            _semaphore.Wait();
    //            task.Start();
    //            task.Wait();
    //            _semaphore.Release();
    //        }));
    //    }

    //}
}

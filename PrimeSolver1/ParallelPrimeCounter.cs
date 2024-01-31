using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PrimeSolver1
{
    internal class ParallelPrimeCounter
    {
        private Int64 size = 0;
        private Int64 tasks = 0;
        private Int64 steps = 0;
        private Int64 count = 0;
        private Int64 currentStep = 0;
        private Range.DividedRange stepRange;
        private Byte[] eratosthenes1;
        private State state = State.Idol;
        private readonly object stateLock = new object();

        private enum State
        {
            Idol,
            Computing,
            Accessing
        }

        public ParallelPrimeCounter()
        {

        }

        // メインスレッドから呼び出す関数
        public void Init(long size, long tasks, long steps)
        {
            // ワーカースレッドの計算が完了するまで待機する
            while (true)
            {
                lock (stateLock)
                {
                    if (state != State.Computing)
                    {
                        state = State.Accessing;
                        break;
                    }
                }
            }

            this.size = size;
            this.tasks = tasks;
            this.steps = steps;
            this.count = 0;
            this.currentStep = 0;
            this.stepRange = Range.Divide(new Range(1, size), steps);
            this.eratosthenes1 = Eratosthenes1.Solve(Helper.Sqrt(size));

            lock (stateLock)
            {
                state = State.Idol;
            }
        }

        public Int64 Size { get { return size; } }
        public Int64 Tasks { get {  return tasks; } }
        public Int64 Steps { get {  return steps; } }
        public Int64 Count { get { return count; } }
        public Int64 CurrentStep { get {  return currentStep; } }

        public int Progress { get { return (int)(100.0 * currentStep / steps); } }

        private class Args
        {
            public Range range;
            public Byte[] eratosthenes1;

            public Args(Range range, byte[] eratosthenes1)
            {
                this.range = range;
                this.eratosthenes1 = eratosthenes1;
            }
        }

        static private Int64 Calc(Object obj)
        {
            Args args = obj as Args;
            Eratosthenes2 e = new Eratosthenes2(args.range.Start, args.range.End, args.eratosthenes1);
            Int64 c = 0;
            for (Int64 i = args.range.Start; i <= args.range.End; ++i)
            {
                if (e.IsPrime(i)) ++c;
            }
            return c;
        }

        // ワーカースレッドで呼び出す関数
        public bool MoveNext()
        {
            // メインスレッドのアクセスが完了するまで待機する
            while (true)
            {
                lock (stateLock)
                {
                    if (state == State.Idol)
                    {
                        state = State.Computing;
                        break;
                    }
                }
            }

            if (currentStep == steps)
            {
                lock (stateLock)
                {
                    state = State.Idol;
                }
                return false;
            }

            Task<Int64>[] taskArray = new Task<Int64>[tasks];
            Range.DividedRange taskRange = Range.Divide(stepRange.Current, tasks);
            for (Int64 task = 0; task < tasks; ++task)
            {
                taskArray[task] = Task<Int64>.Factory.StartNew((Object obj) => Calc(obj), new Args(taskRange.Current, eratosthenes1));
                taskRange.MoveNext();
            }
            for (Int64 task = 0; task < tasks; ++task)
            {
                count += taskArray[task].Result;
            }

            ++currentStep;
            stepRange.MoveNext();

            lock (stateLock)
            {
                state = State.Idol;
            }
            return true;
        }

        // メインスレッドで呼び出す関数
        public void Save(TextWriter writer)
        {
            // ワーカースレッドの計算が完了するまで待機する
            while (true)
            {
                lock (stateLock)
                {
                    if (state == State.Idol)
                    {
                        state = State.Accessing;
                        break;
                    }
                }
            }

            writer.WriteLine("uuid-of-filetype : e9e6172b-8740-e2f2-39fd-8f7e8530be5e");
            writer.WriteLine("size : " + size);
            writer.WriteLine("tasks : " + tasks);
            writer.WriteLine("steps : " + steps);
            writer.WriteLine("count : " + count);
            writer.WriteLine("currentStep : " + currentStep);

            lock (stateLock)
            {
                state = State.Idol;
            }
        }

        // メインスレッドで呼び出す関数
        public bool Load(TextReader reader)
        {
            // ワーカースレッドの計算が完了するまで待機する
            while (true)
            {
                lock (stateLock)
                {
                    if (state == State.Idol)
                    {
                        state = State.Accessing;
                        break;
                    }
                }
            }

            long _size, _tasks, _steps, _count, _currentStep;
            try
            {
                var line1 = reader.ReadLine();
                if (line1 == null) { throw new Exception(); }
                if (line1 != "uuid-of-filetype : e9e6172b-8740-e2f2-39fd-8f7e8530be5e") { throw new Exception(); }

                string line;
                string[] strs;

                line = reader.ReadLine();
                if (line == null) { throw new Exception(); }
                strs = line.Split(' ');
                if (strs.Length != 3) { throw new Exception(); }
                if (strs[0] != "size") { throw new Exception(); }
                if (strs[1] != ":") { throw new Exception(); }
                if (!Int64.TryParse(strs[2], out _size)) {  throw new Exception(); }

                line = reader.ReadLine();
                if (line == null) { throw new Exception(); }
                strs = line.Split(' ');
                if (strs.Length != 3) { throw new Exception(); }
                if (strs[0] != "tasks") { throw new Exception(); }
                if (strs[1] != ":") { throw new Exception(); }
                if (!Int64.TryParse(strs[2], out _tasks)) { throw new Exception(); }

                line = reader.ReadLine();
                if (line == null) { throw new Exception(); }
                strs = line.Split(' ');
                if (strs.Length != 3) { throw new Exception(); }
                if (strs[0] != "steps") { throw new Exception(); }
                if (strs[1] != ":") { throw new Exception(); }
                if (!Int64.TryParse(strs[2], out _steps)) { throw new Exception(); }

                line = reader.ReadLine();
                if (line == null) { throw new Exception(); }
                strs = line.Split(' ');
                if (strs.Length != 3) { throw new Exception(); }
                if (strs[0] != "count") { throw new Exception(); }
                if (strs[1] != ":") { throw new Exception(); }
                if (!Int64.TryParse(strs[2], out _count)) { throw new Exception(); }

                line = reader.ReadLine();
                if (line == null) { throw new Exception(); }
                strs = line.Split(' ');
                if (strs.Length != 3) { throw new Exception(); }
                if (strs[0] != "currentStep") { throw new Exception(); }
                if (strs[1] != ":") { throw new Exception(); }
                if (!Int64.TryParse(strs[2], out _currentStep)) { throw new Exception(); }

                size = _size;
                tasks = _tasks;
                steps = _steps;
                count = _count;
                currentStep = _currentStep;
                stepRange = Range.Divide(new Range(1, size), steps);
                eratosthenes1 = Eratosthenes1.Solve(Helper.Sqrt(size));
                for (long i = 0; i < currentStep; ++i)
                {
                    stepRange.MoveNext();
                }
            }
            catch (Exception ex)
            {
                lock (stateLock)
                {
                    state = State.Idol;
                }
                return false;
            }

            lock (stateLock)
            {
                state = State.Idol;
            }
            return true;
        }
    }
}

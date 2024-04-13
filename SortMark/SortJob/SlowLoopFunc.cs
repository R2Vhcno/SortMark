using System.Diagnostics;

namespace SortMark.SortJob {
    internal abstract class SlowLoopFunc<TReturn> {
        public int IterationCount { get; private set; }
        public TimeSpan Duration { get; private set; }
        public long OverallTicks { get; private set; } = 0;

        private Stopwatch _timer;

        public SlowLoopFunc(int iterationCount, TimeSpan duration) {
            IterationCount = iterationCount;
            Duration = duration;

            _timer = new Stopwatch();
        }

        protected abstract void Func(int iteration);
        protected abstract void SlowUpdate(int iteration);
        public abstract TReturn GetReturnValue();

        private void Dispatch() {
            int iteration = 0;

            int iterationsPerPeriod = (int)(IterationCount / (Duration.TotalSeconds * 20.0));
            if (iterationsPerPeriod < 1) iterationsPerPeriod = 1;

            while (iteration < IterationCount) {
                long timeSpent = 0;

                for (int i = 0; i < iterationsPerPeriod; i++) {
                    if (iteration >= IterationCount) break;

                    _timer.Restart();
                    Func(iteration++);
                    _timer.Stop();

                    timeSpent += _timer.ElapsedMilliseconds;
                    OverallTicks += _timer.ElapsedTicks;
                }

                SlowUpdate(iteration);

                if (timeSpent < 50) {
                    Thread.Sleep((int)(50l - timeSpent));
                }
            }
        }

        public async void RunAsync() {
            OverallTicks = 0;

            await Task.Run(Dispatch);
        }

        public void Run() {
            OverallTicks = 0;

            Dispatch();
        }
    }
}

using System.Diagnostics;

namespace SortMark.SortJob {
    internal abstract class SlowJob<TReturn> {
        private Stopwatch _intervalTimer;
        private long _msInterval;

        CancellationTokenSource _cancellationTokenSource;
        CancellationToken _cancellationToken;
        private Task _updateTask;

        //Stopwatch _timer;
        //public long OverallTicks { get; private set; } = 0;

        public SlowJob(TimeSpan updateInterval) {
            _msInterval = updateInterval.Milliseconds;

            _intervalTimer = new Stopwatch();
            //_timer = new Stopwatch();

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            _updateTask = new Task(RunUpdate, _cancellationToken);
        }

        public void QuietSleep(int milliseconds) {
            //_sleepedMs += milliseconds;
            //_timer.Stop();

            Thread.Sleep(milliseconds);

            //_timer.Start();
        }

        protected abstract void Perform();

        protected abstract void Update();

        public abstract TReturn GetReturnValue();

        private void RunPerform() {
            //_timer.Restart();
            Perform();
            //_timer.Stop();

            //OverallTicks = _timer.ElapsedTicks - _sleepedMs * TimeSpan.TicksPerMillisecond;
            //OverallTicks = _timer.ElapsedTicks;
        }

        private void RunUpdate() {
            while (true) {
                _intervalTimer.Restart();
                Update();
                _intervalTimer.Stop();

                if (_cancellationToken.IsCancellationRequested) break;

                if (_intervalTimer.ElapsedMilliseconds < _msInterval) {
                    Thread.Sleep((int)(_msInterval - _intervalTimer.ElapsedMilliseconds));
                }
            }
        }

        public async Task RunAsync() {
            _updateTask = new Task(RunUpdate, _cancellationToken);
            _updateTask.Start();

            await Task.Run(RunPerform);

            _cancellationTokenSource.Cancel();

            await _updateTask;
        }
    }
}

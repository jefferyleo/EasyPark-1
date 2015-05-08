using System;

namespace EasyPark.Timer
{
    public class PCLTimer
    {
        private System.Threading.Timer timer;
        private Action<object> action;

        public PCLTimer(Action<object> action, object state, int dueTimeMilliseconds, int periodMilliseconds)
        {
            this.action = action;
            timer = new System.Threading.Timer(PCLTimerCallback, state, dueTimeMilliseconds, periodMilliseconds);
        }

        public PCLTimer(Action<object> action, object state, TimeSpan dueTimeMilliseconds, TimeSpan periodMilliseconds)
        {
            this.action = action;
            timer = new System.Threading.Timer(PCLTimerCallback, state, dueTimeMilliseconds, periodMilliseconds);
        }

        private void PCLTimerCallback(object state)
        {
            action.Invoke(state);
        }

        public bool Change(int dueTimeMilliseconds, int periodMilliseconds)
        {
            return timer.Change(dueTimeMilliseconds, periodMilliseconds);
        }

        public bool Change(TimeSpan dueTimeMilliseconds, TimeSpan periodMilliseconds)
        {
            return timer.Change(dueTimeMilliseconds, periodMilliseconds);
        }

        public new void Dispose()
        {
            timer.Dispose();
        }
    }
}

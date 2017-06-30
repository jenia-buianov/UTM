namespace System.Windows.Forms
{
    internal class EventHandler
    {
        private Action<object, EventArgs> tmrMoving_Tick;

        public EventHandler(Action<object, EventArgs> tmrMoving_Tick)
        {
            this.tmrMoving_Tick = tmrMoving_Tick;
        }
    }
}
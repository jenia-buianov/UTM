namespace System.Windows.Forms
{
    internal class MoveEventHandler
    {
        private Action<object, EventArgs> tmrMoving_Tick;

        public MoveEventHandler(Action<object, EventArgs> tmrMoving_Tick)
        {
            this.tmrMoving_Tick = tmrMoving_Tick;
        }
    }
}
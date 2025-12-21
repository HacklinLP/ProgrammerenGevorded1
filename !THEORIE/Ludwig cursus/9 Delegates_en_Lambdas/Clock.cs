namespace Domein
{
    public class Clock
    {
        private int hour;
        private int minute;
        private int second;

        // set the clock running
        // it will raise an event for each new second
        public void Run()
        {
            for (; ; )
            {
                // sleep 100 milliseconds
                Thread.Sleep(100);

                // get the current time
                System.DateTime dt = System.DateTime.Now;

                if (dt.Second != second)
                {
                    // A second has changed!
                    Console.WriteLine("A second has changed!");
                }

                // update the state
                this.second = dt.Second;
                this.minute = dt.Minute;
                this.hour = dt.Hour;
            }
        }
    }
}
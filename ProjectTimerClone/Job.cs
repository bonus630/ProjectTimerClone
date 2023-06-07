using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectTimerClone
{
    public class Job : NotifyPropertyChangedBase
    {
        

        private string formatedTime;
        private string startDateTime;
        private string endDateTime;
        private DateTime start;
        private DateTime end;
        private string name;
        private int counter;
        private Thread mainThread;
        private bool running = false;
        private bool isSelected = false;
        public string FormatedTime { get { return formatedTime; } set { formatedTime = value; OnPropertyChanged("FormatedTime"); } }
        public string StartDateTime { get { return startDateTime; } set { startDateTime = value; OnPropertyChanged("StartDateTime"); } }
        public string EndDateTime { get { return endDateTime; } set { endDateTime = value; OnPropertyChanged("EndDateTime"); } }
        public string Name { get { return name; } set { name = value;OnPropertyChanged("Name"); } }
        public bool IsSelected { get { return isSelected; } set { isSelected = value;OnPropertyChanged("IsSelected"); } }
        public bool Running { get { return running; } set { running = value;OnPropertyChanged("Running"); } }

        public event Action<TimeSpan> EllapseTimeEvent;
        public TimeSpan EllapseTime { get; private set; }
        public Job(string name)
        {
            Name = name;
            mainThread = new Thread(new ThreadStart(process));
            mainThread.IsBackground = true;
        }
        public Job()
        {
            mainThread = new Thread(new ThreadStart(process));
            mainThread.IsBackground = true;
        }
        public Job(int index)
        {
            this.Name = string.Format("Job {0}", index);
            mainThread = new Thread(new ThreadStart(process));
            mainThread.IsBackground = true;
        } 
        public void Start()
        {
            start = DateTime.Now;
            Running = true;
            counter = 0;
            mainThread.Start();
        }
        public void Stop()
        {
            end = DateTime.Now;
            counter = 0;
            Running = false;
            this.StartDateTime = start.ToString("G");
            this.EndDateTime = end.ToString("G");
        }
        public void Pause()

        {
            Running = false;
        }
        public void Resume()
        {
            Running = true;
        }
        private void process()
        {
            while(running)
            {
                counter++;
                TimeSpan time = (start.AddSeconds(counter)) - start;
                FormatedTime = time.ToString("T");
                EllapseTime = time;
                if (EllapseTimeEvent != null)
                    EllapseTimeEvent(time);
                Thread.Sleep(1000);
            }
        }
        public override string ToString()
        {
            return String.Format("{0} ({1})",this.name,this.end - this.start);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ProjectTimerClone
{
    public class Jobs : NotifyPropertyChangedBase
    {
        ObservableCollection<Job> jobs = new ObservableCollection<Job>();
        public ObservableCollection<Job> JobList { get { return jobs; } set { jobs = value; OnPropertyChanged("JobList"); } }
        private int jobIndex = 1;

        private Job currentJob;

        public Job CurrentJob
        {
            get { return currentJob; }
            set { currentJob = value;
                OnPropertyChanged("CurrentJob"); }
        }
        public Job CreateJob(bool running = false)
        {
            if (JobList.Count > 0)
                JobList[JobList.Count - 1].Stop();
            Job job = new Job(jobIndex);
            if (running)
                job.Start();
            this.CurrentJob = job;
            this.JobList.Add(job);
            return job;
        }

    }
}

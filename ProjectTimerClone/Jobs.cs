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
        private bool popupOpened = false;

        public bool PopupOpened
        {
            get { return popupOpened; }
            set { popupOpened =  value;
                OnPropertyChanged("PopupOpened");
            }
        }

        public Job CreateJob(bool running = false)
        {
            if (JobList.Count > 0)
                JobList[JobList.Count - 1].Stop();
            jobIndex = JobList.Count + 1;
            Job job = new Job(jobIndex);
            if (running)
                job.Start();
            this.CurrentJob = job;
            this.JobList.Add(job);
            job.EllapseTimeEvent += Job_EllapseTimeEvent;
            return job;
        }

        private void Job_EllapseTimeEvent(TimeSpan obj)
        {
            TimeSpan total = TimeSpan.Zero;
            for (int i = 0; i < JobList.Count; i++)
            {
                total.Add(JobList[i].EllapseTime);
            }
            this.TotalTime = total.ToString("T");
        }

        public void Resume()
        {
            if (this.CurrentJob == null && JobList.Count > 0)
                this.CurrentJob = JobList[0];
            if (this.CurrentJob == null)
                CreateJob(true);
            else
                this.currentJob.Resume();

        }
        private string totalTime = "00:00:00";

        public string TotalTime
        {
            get { return totalTime ; }
            set { totalTime  = value;
                OnPropertyChanged("TotalTime");
            }
        }


    }
}

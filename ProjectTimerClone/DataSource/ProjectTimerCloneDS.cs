using Corel.Interop.VGCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjectTimerClone.DataSource
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class ProjectTimerCloneDS : DataSourceBase
    {
        private Jobs jobs = new Jobs();
        public ProjectTimerCloneDS(DataSourceProxy proxy) : base(proxy)
        {
            
        }
        private string formatedTime = "1:10:20";
        public string FormatedTime
        {
            get
            {
                return formatedTime;
            }
            set
            {
                formatedTime = value;
                OnPropertyChanged("FormatedTime");
            }
        }
        private bool running;

        public bool Running
        {
            get { return running; }
            set { running = value; 
                OnPropertyChanged("Running"); }
        }
        public Jobs Jobs
        {
            //resolve marshal issue
            get { return this.jobs; }
            set { this.jobs = value;
                OnPropertyChanged("Jobs");
            }
        }

    }
}

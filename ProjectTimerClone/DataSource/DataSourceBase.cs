using Corel.Interop.VGCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ProjectTimerClone.DataSource
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class DataSourceBase : INotifyPropertyChanged
    {
        protected DataSourceProxy m_AppProxy;

        public DataSourceBase(DataSourceProxy proxy)
        {
            this.m_AppProxy = proxy;
        }

    
        public event PropertyChangedEventHandler PropertyChanged;
        protected  void OnPropertyChanged(string propertyName = "")
        {
            try
            {
                this.m_AppProxy.UpdateListeners(propertyName);
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            catch { }
        }

    }
}

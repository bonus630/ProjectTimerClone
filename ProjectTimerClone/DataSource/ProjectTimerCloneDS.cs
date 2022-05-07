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
    public class ProjectTimerCloneDS: DataSourceBase
    {
        public ProjectTimerCloneDS(DataSourceProxy proxy):base(proxy)
        {

        }
    }
}

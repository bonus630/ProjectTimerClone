using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using corel = Corel.Interop.VGCore;

namespace ProjectTimerClone
{

    public partial class ControlUI : UserControl
    {
        public static corel.Application corelApp;
        private Styles.StylesController stylesController;
        public ControlUI(object app)
        {
            InitializeComponent();
            try
            {
                ControlUI.corelApp = app as corel.Application;
                stylesController = new Styles.StylesController(this.Resources, ControlUI.corelApp);
                var dsf = new DataSource.DataSourceFactory();
                dsf.AddDataSource("ProjectTimerCloneDS", typeof(DataSource.ProjectTimerCloneDS));
                dsf.Register();
                var dsp = corelApp.FrameWork.Application.DataContext.GetDataSource("ProjectTimerCloneDS");
                ck_startTimer.Click += (s, e) => { dsp.SetProperty("Running", ck_startTimer.IsChecked); };
            }
            catch
            {
                global::System.Windows.MessageBox.Show("VGCore Erro");
            }
            //btn_Command.Click += (s, e) => {
               
               //corel.DataSourceProxy proxy =  corelApp.FrameWork.Application.DataContext.GetDataSource("ProjectTimerDS"); 
               // object o = proxy.GetProperty("OnProjectTimerPopupDialogShow");
               // corelApp.FrameWork.ShowDialog("79c72097-2da1-4fbf-8436-f89abb1478b6");

           // };
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            stylesController.LoadThemeFromPreference();
        }

    }
}

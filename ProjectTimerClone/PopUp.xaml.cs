using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : UserControl
    {
        private corel.Application corelApp;
        private Styles.StylesController stylesController;
        private Jobs Jobs;
        public PopUp(object app)
        {
            InitializeComponent();
            try
            {
                this.corelApp = app as corel.Application;
                stylesController = new Styles.StylesController(this.Resources, this.corelApp);
                var dsp = corelApp.FrameWork.Application.DataContext.GetDataSource("ProjectTimerCloneDS");
                object o = dsp.GetProperty("FormatedTime");
                
                this.DataContext = this.Jobs;
            }
            catch
            {
                global::System.Windows.MessageBox.Show("VGCore Erro");
            }
         
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            stylesController.LoadThemeFromPreference();
        }

        private void btn_newJob_Click(object sender, RoutedEventArgs e)
        {
            Jobs.CreateJob(true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Support_EDI
{
    /// <summary>
    /// Interaction logic for EDI_Home.xaml
    /// </summary>
    public partial class EDI_Home : UserControl
    {
        public EDI_Home()
        {
            InitializeComponent();
            this.grdInOut.Children.Add(new InItInOut());
            this.grdCode.Children.Add(new InItCode());
            //if (checkIP() == true)
            //{
            //    this.grdChangesResource.Children.Add(new tabChangesCommon());
            //}
            //else
            //{
            //    for (int i = 0; i < this.grdChangesResource.Children.Count; i++)
            //    {
            //        UIElement xControl = grdChangesResource.Children[i];
            //        this.grdChangesResource.Children.Remove(xControl);
            //    }
            //    MessageBox.Show("Please contact H2Team!");
            //}
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (tabItemCommon.IsSelected)
            //{
            //    this.grdCommonResource.Children.Add(new TabGetCommonResource());
            //}
            //if (tabItemGrid.IsSelected)
            //{
            //    this.grdTool.Children.Add(new tabGridCreater());
            //}
            //if (tabItemResource.IsSelected)
            //{
            //    if (checkIP() == true)
            //    {
            //        this.grdChangesResource.Children.Add(new tabChangesCommon());
            //    }
            //    else
            //    {
            //        for (int i = 0; i < this.grdChangesResource.Children.Count; i++)
            //        {
            //            UIElement xControl = grdChangesResource.Children[i];
            //            this.grdChangesResource.Children.Remove(xControl);
            //        }
            //        MessageBox.Show("Please contact H2Team!");
            //    }
            //}
        }
        private bool checkIP() {
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            Console.WriteLine(hostName);
           // Get the IP
            string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            if (myIP.Equals("10.0.12.96"))
                return true;
            else
                return false;
        }
    
    }
}

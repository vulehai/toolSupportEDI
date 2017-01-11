using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;

namespace Support_EDI
{
    /// <summary>
    /// Interaction logic for InItCode.xaml
    /// </summary>
    public partial class InItCode : UserControl
    {
        private DataTable tDtObject = null;
        public InItCode()
        {
            InitializeComponent();
            InitDataTable();
            InitGridMap();
        }
        public void InitDataTable()
        {
            tDtObject = new DataTable();
            tDtObject.Columns.Add("STT");
            tDtObject.Columns.Add("Name");
            tDtObject.Columns.Add("Parent");
            tDtObject.Columns.Add("Index");
        }
        public void InitGridMap()
        {
            Binding bindingExpression = null;
            GridColumn xColumn = new GridColumn();

            xColumn.Header = "STT";
            bindingExpression = new Binding("STT") { Mode = BindingMode.TwoWay };
            xColumn.Width = 30;
            xColumn.Binding = bindingExpression;
            xColumn.ReadOnly = true;
            grdMain.Columns.Add(xColumn);

            xColumn = new GridColumn();
            xColumn.Header = "Name";
            xColumn.Width = 80;
            bindingExpression = new Binding("Name") { Mode = BindingMode.TwoWay };
            xColumn.Binding = bindingExpression;
            grdMain.Columns.Add(xColumn);

            xColumn = new GridColumn();
            xColumn.Header = "Parent";
            xColumn.Width = 80;
            bindingExpression = new Binding("Parent") { Mode = BindingMode.TwoWay };
            xColumn.Binding = bindingExpression;
            grdMain.Columns.Add(xColumn);

            xColumn = new GridColumn();
            xColumn.Header = "Index";
            xColumn.Width = 200;
            bindingExpression = new Binding("Index") { Mode = BindingMode.TwoWay };
            xColumn.Binding = bindingExpression;
            grdMain.Columns.Add(xColumn);
        }
        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            InitDataTable();
            getNode(FileNameTextBox.Text, "//hvnsp:INPUT//hvnsp:EDISyntax//hvnsp:Group");
        }
        public void getNode(string filename, string nodeLink)
        {
            bool check = false;
            StreamReader sr = new StreamReader(filename);
            string rows = sr.ReadToEnd();
            sr.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(rows);

            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("hvnsp", "http://www.stercomm.com/SI/Map");
            //string xId = "//hvnsp:OUTPUT//hvnsp:Group";

            XmlNode root = doc.SelectSingleNode(nodeLink, ns);
            getData(root, ns, "", "");
            MessageBox.Show("Okay");
            grdMain.ItemsSource = tDtObject;
        }

        public void getData(XmlNode xNode, XmlNamespaceManager ns, string Parent, string Index)
        {
            XmlNodeList xGroupList = xNode.SelectNodes("hvnsp:Group", ns);
            XmlNodeList xSegmentList = xNode.SelectNodes("hvnsp:Segment", ns);
            XmlNodeList xCompositeList = xNode.SelectNodes("hvnsp:Composite", ns);
            XmlNodeList xElementList = xNode.SelectNodes("hvnsp:Field", ns);
            string strTempIndex = Index;
            if (xGroupList != null)
            {
                foreach (XmlNode nodeGroup in xGroupList)
                {
                    getData(nodeGroup, ns, nodeGroup.SelectSingleNode("hvnsp:Name", ns).InnerText, Index + "[idx" + nodeGroup.SelectSingleNode("hvnsp:Name", ns).InnerText.Replace("_", "") + "]");
                }
            }
            if (xSegmentList != null)
            {
                foreach (XmlNode nodeSegment in xSegmentList)
                {
                    if (!nodeSegment.SelectSingleNode("hvnsp:Max", ns).InnerText.Equals("1"))
                    {
                        Parent = nodeSegment.SelectSingleNode("hvnsp:Name", ns).InnerText;
                        strTempIndex = Index + "[idx" + nodeSegment.SelectSingleNode("hvnsp:Name", ns).InnerText.Replace("_", "") + "]";
                    }
                    getData(nodeSegment, ns, Parent, strTempIndex);
                }
            }
            if (xCompositeList != null)
            {
                foreach (XmlNode nodeComposite in xCompositeList)
                {
                    getData(nodeComposite, ns, Parent, Index);
                }
            }
            if (xElementList != null)
            {
                foreach (XmlNode nodeElement in xElementList)
                {
                    setDataToDataTable(nodeElement.SelectSingleNode("hvnsp:Name", ns).InnerText, Parent, Index);
                }
            }
        }
        public void setDataToDataTable(string Name, string Parent, string Index)
        {
            tDtObject.Rows.Add();
            tDtObject.Rows[tDtObject.Rows.Count - 1]["STT"] = tDtObject.Rows.Count;
            tDtObject.Rows[tDtObject.Rows.Count - 1]["Name"] = Name;
            tDtObject.Rows[tDtObject.Rows.Count - 1]["Parent"] = Parent;
            tDtObject.Rows[tDtObject.Rows.Count - 1]["Index"] = Index;
        }
        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "All *.mxl|*.mxl";
            Nullable<bool> results = dlg.ShowDialog();
            if (results == true)
            {
                string filename = dlg.FileName;
                FileNameTextBox.Text = filename;
            }
        }
        private void btnGetObject_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder Code = new StringBuilder();
            String[] CodeLineList = Regex.Split(txtCode.Text.Trim(), "\r\n");
            foreach (string linecode in CodeLineList)
            {
                String[] CodeList = Regex.Split(linecode, " ");
                //string X = CodeList[58].ToString();
                foreach (string code in CodeList)
                {
                    if (code == "") continue;
                    if (code.ToUpper().Equals("IF"))
                    {
                        Code.Append(code + " ");
                    }
                    else if (code.Trim().Substring(0, 1).Equals("#"))
                    {
                        String[] xGroup_Code = Regex.Split(code.Trim(), @"\.");
                        if (xGroup_Code.Length == 2)
                        {
                            Code.Append(getParentAndIndexByName(xGroup_Code[1].Trim()) + " ");
                        }
                        else
                        {
                            Code.Append(getParentAndIndexByName(code.Trim().Substring(1)) + " ");
                        }
                    }
                    else if (code.Trim().Equals("="))
                    {
                        Code.Append(" = ");
                    }
                    else if (code.Trim().Substring(0, 1).Equals("\""))
                    {
                        Code.Append(" " + code + " ");
                    }
                    else if (code.Trim().ToUpper().Equals("THEN"))
                    {
                        Code.Append(" THEN ");
                    }
                    else if (code.Trim().Equals(";"))
                    {
                        Code.Append("; \r\n");
                    }
                }
            }
           
            txtKetQua.Text = Code.ToString();

        }
        public string getParentAndIndexByName(string name)
        {
            bool tmp = false;
            DataRow[] xRowList = tDtObject.Select("Name like '" + name + "'");
            if (xRowList.Length == 0)
            {
                xRowList = tDtObject.Select("Name like 'TMP_" + name + "'");
                tmp = true;
                if (xRowList.Length == 0)
                {
                    MessageBox.Show(name + " Không tồn tại trong Map!");
                }

            }
            DataRow xRow = xRowList.First();
            if (tmp) return "#" + xRow["Name"].ToString();
            return "$" + xRow["Parent"].ToString() + xRow["Index"].ToString() + ".#" + xRow["Name"].ToString();
        }

    }
}

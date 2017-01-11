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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using System.Xml;
using System.Xml.Linq;
using NodeFormat = Support_EDI.NodeFormat;


namespace Support_EDI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class InItInOut : UserControl
    {
        private List<int> IdListGroup = new List<int>();
        DataTable tdtGrid = new DataTable();//Data binding to Grid
        XmlDocument doc = new XmlDocument();//Data Xml of Mapping
        StringBuilder tmpFromEDI = new StringBuilder();
        XmlDocument docRollBack = new XmlDocument();//Data Xml of Mapping

        int startText = 4;
        public InItInOut()
        {
            InitializeComponent();
            InitGridMap();
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Init Grid View
        /// </summary>
        public void InitGridMap()
        {
            tdtGrid.Columns.Add("Prefix");
            tdtGrid.Columns.Add("Item");
            tdtGrid.Columns.Add("MCO");
            tdtGrid.Columns.Add("Loop");
            tdtGrid.Columns.Add("Max");
            Binding bindingExpression = null;
            GridColumn xColumn = new GridColumn();

            xColumn = new DevExpress.Xpf.Grid.GridColumn();
            xColumn.Header = "Prefix";
            xColumn.Width = 200;
            bindingExpression = new Binding("Prefix") { Mode = BindingMode.TwoWay };
            xColumn.Binding = bindingExpression;
            grdMain.Columns.Add(xColumn);

            xColumn = new GridColumn();
            xColumn.Header = "Item";
            xColumn.Width = 200;
            bindingExpression = new Binding("Item") { Mode = BindingMode.TwoWay };
            xColumn.Binding = bindingExpression;
            grdMain.Columns.Add(xColumn);

            xColumn = new GridColumn();
            xColumn.Header = "MCO";
            xColumn.Width = 80;
            bindingExpression = new Binding("MCO") { Mode = BindingMode.TwoWay };
            xColumn.Binding = bindingExpression;
            grdMain.Columns.Add(xColumn);

            xColumn = new GridColumn();
            xColumn.Header = "Loop";
            xColumn.Width = 80;
            bindingExpression = new Binding("Loop") { Mode = BindingMode.TwoWay };
            xColumn.Binding = bindingExpression;
            grdMain.Columns.Add(xColumn);

            xColumn = new GridColumn();
            xColumn.Header = "Max";
            xColumn.Width = 80;
            bindingExpression = new Binding("Max") { Mode = BindingMode.TwoWay };
            xColumn.Binding = bindingExpression;
            grdMain.Columns.Add(xColumn);
            grdMain.DataSource = tdtGrid;
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Browse Click => Select map file
        /// </summary>
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
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Start Click 
        /// </summary>
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (tdtGrid.Rows.Count <= 0) return;
            StreamReader sr = new StreamReader(FileNameTextBox.Text);
            string rows = sr.ReadToEnd();
            sr.Close();

            doc.LoadXml(rows);
            docRollBack.LoadXml(rows);
            String[] refix = (from tRow in tdtGrid.AsEnumerable()
                              select tRow["Prefix"].ToString()).ToArray<string>();
            String[] item = (from tRow in tdtGrid.AsEnumerable()
                             select tRow["Item"].ToString()).ToArray<string>();
            String[] mc = (from tRow in tdtGrid.AsEnumerable()
                           select tRow["MCO"].ToString()).ToArray<string>();
            String[] max = (from tRow in tdtGrid.AsEnumerable()
                            select tRow["Max"].ToString()).ToArray<string>();
            String[] loop = (from tRow in tdtGrid.AsEnumerable()
                             //where tRow.Field<string>(sColumnName) != Common.ComboBox.ALL
                             select tRow["Loop"].ToString()).ToArray<string>();

            if (EDI_FF.IsChecked.Value)
            {
                if (MessageBox.Show("Would do you like to write EDI to F/F?", "Warning EDI To F/F!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (InitEdiToFlatFile(refix, mc, max, loop, item))
                        MessageBox.Show("Write successful! Please reopen this file map.");
                }
            }
            else if (FF_EDI.IsChecked.Value)
            {
                if (MessageBox.Show("Would do you like to write F/F to EDI?", "Warning F/F To EDI!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (InitFlatFieldToEDI(refix, mc, max, loop, item))
                        if (GetDataFromEDIStype())
                            MessageBox.Show("Write successful! Please reopen this file map.");
                }

            }
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Import Prefix from Excel file
        /// </summary>
        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            tdtGrid.Clear();
            dlg.Filter = "All *.xlsx|*.xlsx";
            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> results = dlg.ShowDialog();
            // Get the selected file name and display in a TextBox
            if (results == true)
            {
                string filename = dlg.FileName;
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + filename + "';Extended Properties=Excel 8.0;");
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection);
                MyCommand.TableMappings.Add("Table", "Net-informations.com");
                MyCommand.Fill(tdtGrid);
                grdMain.DataSource = tdtGrid;
                MyConnection.Close();
            }
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Rollback data for map file
        /// </summary>
        private void btnRollback_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to rollback file mapping?", "Warning!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                rollbackAction();
                MessageBox.Show("Rollback successful!");
            }

        }
        private void rollbackAction()
        {
            StreamWriter sw = new StreamWriter(FileNameTextBox.Text);
            sw.WriteLine(docRollBack.InnerXml);
            sw.Close();
            sw.Dispose();
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Check Validate
        /// </summary>
        public bool CheckValidate(String[] refix, String[] mc, String[] max, String[] loop)
        {
            if (refix.Length <= 0 || mc.Length <= 0 || max.Length <= 0 || loop.Length <= 0)
            {
                MessageBox.Show("Pleasa input data");
                return false;
            }
            if (refix.Length != mc.Length || refix.Length != max.Length || refix.Length != loop.Length)
            {
                MessageBox.Show("Please check again all data input(Contact to admin if you want support)");
                return false;
            }
            if (string.IsNullOrEmpty(FileNameTextBox.Text))
            {
                MessageBox.Show("Please choose a file!");
                return false;
            }
            return true;
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: input Xml to file Xml Parent
        /// </summary>
        public bool writeMapFile(string filename, StringBuilder valueNew, string nodeLink)
        {
            try
            {
                XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
                ns.AddNamespace("hvnsp", "http://www.stercomm.com/SI/Map");

                XmlNode root = doc.SelectSingleNode(nodeLink, ns);
                XmlDocumentFragment fragment = doc.CreateDocumentFragment();
                fragment.InnerXml = valueNew.ToString();
                root.AppendChild(fragment);
                string strXMLPattern = @"xmlns=""""";
                doc.InnerXml = Regex.Replace(doc.InnerXml, strXMLPattern, "");
                StreamWriter sw = new StreamWriter(filename);
                sw.WriteLine(doc.InnerXml);
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Have an issue in handling process, maybe you chose the wrong format for file mapping! Please try again or contact to Admin!");
                rollbackAction();
                return false;
            }
            return true;
        }
        #region EDI => Flat Field
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Event write from EDI to Flat File
        /// </summary>
        public bool InitEdiToFlatFile(String[] refix, String[] mc, String[] max, String[] loop, String[] item)
        {
            StringBuilder dataReturnInput = new StringBuilder();
            StringBuilder dataReturnOutput = new StringBuilder();
            IdListGroup = new List<int>();
            int Id = 9999999;
            if (!CheckValidate(refix, mc, max, loop)) return false;
            int refixCount = refix.Length;
            for (int i = 0; i < refixCount; i++)
            {
                dataReturnInput.Append(genInPut(refix[i].ToString(), mc[i].ToString(), max[i].ToString(), loop[i].ToString(), Id - i, item[i].ToString()));
                dataReturnOutput.Append(genOutPut(refix[i].ToString(), mc[i].ToString(), max[i].ToString(), loop[i].ToString().Trim(), Id - i, Id - refixCount - i, item[i].ToString()));
            }
            //txtShowLog.Text = dataReturnOutput.ToString();
            if (writeMapFile(FileNameTextBox.Text, dataReturnInput, "//hvnsp:INPUT//hvnsp:EDISyntax//hvnsp:Group"))
                if (writeMapFile(FileNameTextBox.Text, dataReturnOutput, "//hvnsp:OUTPUT//hvnsp:Group"))
                    return true;
            return false;
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Write Prefix for Output
        /// </summary>
        public StringBuilder genOutPut(string name, string mc, string max, string loop, int IdLink, int Id, string item)
        {

            StringBuilder dataReturn = new StringBuilder();
            try
            {
                if (name.Substring(0, 1).Equals("{"))
                {
                    IdListGroup.Add(IdLink);
                    dataReturn.Append(NodeFormat.genGroupOutPut(name.Trim(), loop, 1, 1));
                    dataReturn.Append(NodeFormat.genPosRecord("OPEN_" + name.Trim().Substring(1), loop, 1, 1, string.Empty));
                    dataReturn.Append(NodeFormat.genFieldOutput(name.Trim().Substring(1), mc.Trim(), max.ToString().Trim(), IdLink, Id, item, 1, name.Length + 1));
                    dataReturn.Append(" </PosRecord>                                ");
                }
                else if (name.Trim().Substring(0, 1).Equals("}"))
                {
                    dataReturn.Append(NodeFormat.genPosRecord("CLOSE_" + name.Trim().Substring(1), loop, 1, 1, string.Empty));
                    dataReturn.Append(NodeFormat.genFieldOutput(name.Trim().Substring(1), mc.Trim(), max.ToString().Trim(), IdListGroup[IdListGroup.Count - 1], Id, item, 1, name.Length + 1));
                    IdListGroup.RemoveAt(IdListGroup.Count - 1);
                    dataReturn.Append(" </PosRecord>                                ");
                    dataReturn.Append("</Group>");
                }
                else
                {
                    dataReturn.Append(NodeFormat.genPosRecord(name.Trim(), loop, 1, 1, string.Empty));
                    dataReturn.Append(NodeFormat.genFieldOutput(name.Trim(), mc.Trim(), max.ToString().Trim(), IdLink, Id, item, 1, name.Length + 1));
                    dataReturn.Append(" </PosRecord>                                ");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataReturn;
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Write Prefix for Input
        /// </summary>
        public StringBuilder genInPut(string name, string mc, string max, string loop, int Id, string item)
        {
            StringBuilder dataReturn = new StringBuilder();
            try
            {
                if (name.Substring(0, 1).Equals("{"))
                {
                    dataReturn.Append(NodeFormat.genGroupInput(name.Trim() + "_GRP", loop));
                    dataReturn.Append(NodeFormat.genSegment(name.Trim().Substring(1) + "_TAG_REC", ""));
                    dataReturn.Append(NodeFormat.genFieldInput(name.Trim().Substring(1) + "_TAG", mc, max, Id, item));
                    dataReturn.Append(" </Segment>                                   ");
                }
                else if (name.Trim().Substring(0, 1).Equals("}"))
                {
                    dataReturn.Append(" </Group>                                ");
                }
                else
                {
                    dataReturn.Append(NodeFormat.genSegment(name.Trim() + "_REC", loop));
                    dataReturn.Append(NodeFormat.genFieldInput(name.Trim(), mc, max, Id, item));
                    dataReturn.Append(" </Segment>                                   ");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataReturn;
        }
        #endregion
        #region Flat Field => EDI

        public bool InitFlatFieldToEDI(String[] refix, String[] mc, String[] max, String[] loop, String[] item)
        {
            StringBuilder dataReturnInput = new StringBuilder();
            IdListGroup = new List<int>();
            int Id = 9999999;
            if (!CheckValidate(refix, mc, max, loop)) return false;
            int refixCount = refix.Length;
            for (int i = 0; i < refixCount; i++)
            {
                dataReturnInput.Append(genOutPut(refix[i].ToString(), mc[i].ToString(), max[i].ToString(), loop[i].ToString().Trim(), Id - i, Id - refixCount - i, item[i].ToString()));
            }
            //txtShowLog.Text = dataReturnOutput.ToString();
            if (writeMapFile(FileNameTextBox.Text, dataReturnInput, "//hvnsp:INPUT//hvnsp:PosSyntax//hvnsp:Group")) return true;
            return false;
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: refine Node from Parent Node
        /// </summary>
        public bool GetDataFromEDIStype()
        {
            bool check = false;
            string nodeLink = "//hvnsp:OUTPUT//hvnsp:EDISyntax//hvnsp:Group";


            XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);
            ns.AddNamespace("hvnsp", "http://www.stercomm.com/SI/Map");
            //string xId = "//hvnsp:OUTPUT//hvnsp:Group";

            XmlNode root = doc.SelectSingleNode(nodeLink, ns);
            XmlNodeList rootList = root.ChildNodes;

            foreach (XmlNode xNode in rootList)
            {
                if (xNode.Name.Equals("Group") || xNode.Name.Equals("Segment") || xNode.Name.Equals("Composite") || xNode.Name.Equals("Field"))
                {
                    startText = 4;
                    ReadNode(xNode, ns);
                }
            }
            if (writeMapFile(FileNameTextBox.Text, tmpFromEDI, "//hvnsp:INPUT//hvnsp:PosSyntax//hvnsp:Group")) return true;
            return false;
        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Read Node in Xml Child and Identify Node Name and Call To genarate xml child
        /// </summary>
        /// <param name="xNode"></param>
        /// <param name="ns"></param>
        public void ReadNode(XmlNode xNode, XmlNamespaceManager ns)
        {
            XmlNodeList xNodeList = xNode.ChildNodes;

            //if (xNodeList.Count == 0) return;
            string xNameNode = xNode.Name;
            switch (xNameNode)
            {
                case "Group":
                    //string n = xNode.SelectSingleNode("hvnsp:Name", ns).InnerText;
                    tmpFromEDI.Append(InitTMP(xNode.SelectSingleNode("hvnsp:Name", ns).InnerText, string.Empty, string.Empty, xNode.SelectSingleNode("hvnsp:Max", ns).InnerText, Convert.ToInt32(xNode.SelectSingleNode("hvnsp:ID", ns).InnerText) + 9999999, string.Empty, xNameNode, Convert.ToInt32(xNode.SelectSingleNode("hvnsp:ChildCount", ns).InnerText), Convert.ToInt32(xNode.SelectSingleNode("hvnsp:Active", ns).InnerText)));
                    foreach (XmlNode xNodeChild in xNodeList)
                    {
                        ReadNode(xNodeChild, ns);
                    }
                    tmpFromEDI.Append("</Group>");
                    break;
                case "Segment":
                    startText = 4;
                    tmpFromEDI.Append(InitTMP(xNode.SelectSingleNode("hvnsp:Name", ns).InnerText, string.Empty, string.Empty, xNode.SelectSingleNode("hvnsp:Max", ns).InnerText, Convert.ToInt32(xNode.SelectSingleNode("hvnsp:ID", ns).InnerText) + 9999999, string.Empty, xNameNode, Convert.ToInt32(xNode.SelectSingleNode("hvnsp:ChildCount", ns).InnerText), Convert.ToInt32(xNode.SelectSingleNode("hvnsp:Active", ns).InnerText)));
                    foreach (XmlNode xNodeChild in xNodeList)
                    {
                        ReadNode(xNodeChild, ns);
                    }
                    tmpFromEDI.Append("</PosRecord>");
                    break;
                case "Composite":
                    foreach (XmlNode xNodeChild in xNodeList)
                    {
                        ReadNode(xNodeChild, ns);
                    }
                    break;
                case "Field":
                    XmlDocumentFragment fragment2 = doc.CreateDocumentFragment();
                    int Id = Convert.ToInt32(xNode.SelectSingleNode("hvnsp:ID", ns).InnerText) + 99999999;
                    fragment2.InnerXml = "<Link>" + Id + "</Link>";
                    xNode.InsertAfter(fragment2, xNode.SelectSingleNode("hvnsp:StoreLimit", ns));

                    tmpFromEDI.Append(InitTMP(xNode.SelectSingleNode("hvnsp:Name", ns).InnerText, "0", "512", string.Empty, Id, string.Empty, xNameNode, Convert.ToInt32(xNode.SelectSingleNode("hvnsp:ChildCount", ns).InnerText), Convert.ToInt32(xNode.SelectSingleNode("hvnsp:Active", ns).InnerText)));
                    startText += 512;
                    break;
            }

        }
        /// <summary>
        /// Writer: Hai.Vu
        /// Purpose: Write Group - Segment - Field for TMP_ value
        /// <param name="name"></param>
        /// <param name="mc"></param>
        /// <param name="max"></param>
        /// <param name="loop"></param>
        /// <param name="Id"></param>
        /// <param name="item"></param>
        /// <param name="xNodeName"></param>
        /// <param name="xChildCount"></param>
        /// <param name="xActive"></param>
        /// <returns></returns>
        public StringBuilder InitTMP(string name, string mc, string max, string loop, int Id, string item, string xNodeName, int xChildCount, int xActive)
        {
            StringBuilder dataReturn = new StringBuilder();
            try
            {
                if (xNodeName.Equals("Group"))
                {
                    dataReturn.Append(NodeFormat.genGroupOutPut("-TMP_" + name.Trim().Replace("_", ""), loop, xChildCount, xActive));
                }
                else if (xNodeName.Equals("Segment"))
                {
                    dataReturn.Append(NodeFormat.genPosRecord("TMP_" + name.Trim(), loop, xChildCount, xActive, "$%%$"));
                }
                else if (xNodeName.Equals("Field"))
                {
                    dataReturn.Append(NodeFormat.genFieldOutput("TMP_" + name.Trim(), mc.Trim(), max.ToString().Trim(), 0, Id, item, xActive, startText));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataReturn;
        }

        #endregion


    }
}

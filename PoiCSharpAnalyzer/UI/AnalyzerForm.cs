using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using PoiLanguage;
using PerCederberg.Grammatica.Runtime;

namespace PoiCSharpAnalyzer.UI
{
    public partial class AnalyzerForm : Form
    {
        private AutoresizeForm sizeControl = new AutoresizeForm();

        public AnalyzerForm()
        {
            InitializeComponent();
            InitializeVariableTypeView(variableTypeListView);
            sizeControl.InitializeForm(this);
            this.WindowState = (System.Windows.Forms.FormWindowState)2;
        }

        private void parseButton_Click(object sender, EventArgs e)
        {
            String code = codeInput.Text;
            PoiBasicAnalyzer analyzer = new PoiBasicAnalyzer();
            analyzer.InitializeAnalyzerStatus();
            PoiParser parser = new PoiParser(new StringReader(code), analyzer);
            //PoiParser arithmeticParser = new PoiParser(new StringReader(code), new PoiArithmeticAnalyzer());
            Node parseTree = null;
            try
            {
                parseTree = parser.Parse();
                if (parseTree.Values.Count > 0)
                    codeOutput.Text = (parseTree.GetValue(0) as PoiObject).ToString();
                else
                    codeOutput.Text = "";

                parseTreeOutput.BeginUpdate();
                DeleteParseTree(parseTreeOutput.Nodes);
                CreateParseTree(parseTree, parseTreeOutput.Nodes);
                //parseTreeOutput.CollapseAll();
                parseTreeOutput.ExpandAll();
                parseTreeOutput.EndUpdate();

                variableTypeListView.BeginUpdate();
                DeleteVariableType(variableTypeListView.Items);
                CreateVariableType(analyzer, variableTypeListView.Items);
                variableTypeListView.EndUpdate();
            }
            catch (PerCederberg.Grammatica.Runtime.ParserLogException ex)
            {
                parseTreeOutput.Nodes.Add(ex.GetMessage());
            }
            catch (PoiAnalyzeException ex)
            {
                codeOutput.Text = ex.Message;
            }
        }

        private void DeleteParseTree(TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                DeleteParseTree(nodes[i].Nodes);
            }
            nodes.Clear();
        }

        private void CreateParseTree(Node current, TreeNodeCollection nodes)
        {
            TreeNode currentNode = new TreeNode(CreateNodeString(current));

            int childCount = current.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                CreateParseTree(current.GetChildAt(i), currentNode.Nodes);
            }

            nodes.Add(currentNode);
        }

        private void InitializeVariableTypeView(ListView view)
        {
            view.Columns.Clear();

            view.Columns.Add("Variable Name", (int)(view.Width * 0.5), HorizontalAlignment.Left);
            view.Columns.Add("Variable Type", (int)(view.Width * 0.5), HorizontalAlignment.Left);

            view.View = View.Details;
        }

        private void DeleteVariableType(ListView.ListViewItemCollection items)
        {
            items.Clear();
        }

        private void CreateVariableType(PoiBasicAnalyzer analyzer, ListView.ListViewItemCollection items)
        {
            List<KeyValuePair<String, PoiVariableType>> variables = analyzer.GetTypeInformation();
            foreach (KeyValuePair<String, PoiVariableType> pair in variables)
            {
                ListViewItem lvi = new ListViewItem(pair.Key);
                lvi.SubItems.Add(pair.Value.ToString());
                
                items.Add(lvi);
            }
        }

        private String CreateNodeString(Node node)
        {
            String nodeString = node.ToString();
            int valueCount = node.GetValueCount();

            if (valueCount != 0)
            {
                nodeString += " [Values:";
                nodeString += " " + (node.GetValue(0) as PoiObject).ToString();
                nodeString += "]";

                nodeString += " [Types:";
                nodeString += " " + (node.GetValue(0) as PoiObject).VariableType.ToString();
                nodeString += "]";
            }

            return nodeString;
        }

        private void AnalyzerForm_Load(object sender, EventArgs e)
        {
            sizeControl.InitializeForm(this);
        }

        private void AnalyzerForm_SizeChanged(object sender, EventArgs e)
        {
            sizeControl.Resize(this);

            // Resize columns in variableTypeListView
            try
            {
                variableTypeListView.Columns[0].Width = (int)(variableTypeListView.Width * 0.5);
                variableTypeListView.Columns[1].Width = (int)(variableTypeListView.Width * 0.5);
            }
            catch (Exception)
            {
            }
        }
    }
}

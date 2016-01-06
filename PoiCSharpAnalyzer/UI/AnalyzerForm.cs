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
        private bool collapsed = false;

        public AnalyzerForm()
        {
            InitializeComponent();
            InitializeVariableTypeView(variableTypeListView);
            sizeControl.InitializeForm(this);
            this.WindowState = (System.Windows.Forms.FormWindowState)2;
        }

        private void parseButton_Click(object sender, EventArgs e)
        {
            analyzerLog.Text = "";
            codeOutput.Text = "";
            DeleteParseTree(parseTreeOutput);
            DeleteVariableType(variableTypeListView);

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

                CreateParseTree(parseTree, parseTreeOutput);
                parseTreeOutput.CollapseAll();
                collapsed = true;
                //parseTreeOutput.ExpandAll();

                CreateVariableType(analyzer, variableTypeListView);
            }
            catch (PerCederberg.Grammatica.Runtime.ParserLogException ex)
            {
                analyzerLog.Text += ex.GetMessage();
            }
            catch (PoiAnalyzeException ex)
            {
                analyzerLog.Text += ex.Message;
            }
            /*catch (Exception ex)
            {
                analyzerLog.Text += ex.Message;
            }*/

            PoiTypeChecker.GetWarnings().ForEach(delegate(string warning)
            {
                analyzerLog.Text += warning + "\r\n";
            });
        }

        private void DeleteParseTree(TreeView view)
        {
            view.BeginUpdate();
            DeleteParseTreeNodes(view.Nodes);
            view.EndUpdate();
        }

        private void DeleteParseTreeNodes(TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                DeleteParseTreeNodes(nodes[i].Nodes);
            }
            nodes.Clear();
        }

        private void CreateParseTree(Node root, TreeView view)
        {
            view.BeginUpdate();
            CreateParseTreeNodes(root, view.Nodes);
            view.EndUpdate();
        }

        private void CreateParseTreeNodes(Node current, TreeNodeCollection nodes)
        {
            TreeNode currentNode = new TreeNode(CreateNodeString(current));

            int childCount = current.GetChildCount();
            for (int i = 0; i < childCount; i++)
            {
                CreateParseTreeNodes(current.GetChildAt(i), currentNode.Nodes);
            }

            nodes.Add(currentNode);
        }

        private void InitializeVariableTypeView(ListView view)
        {
            view.Columns.Clear();

            view.Columns.Add("Variable Name", (int)(view.Width * 0.4), HorizontalAlignment.Left);
            view.Columns.Add("Variable Type", (int)(view.Width * 0.6), HorizontalAlignment.Left);

            view.View = View.Details;
        }

        private void DeleteVariableType(ListView view)
        {
            view.BeginUpdate();
            view.Items.Clear();
            view.EndUpdate();
        }

        private void CreateVariableType(PoiBasicAnalyzer analyzer, ListView view)
        {
            view.BeginUpdate();
            ListView.ListViewItemCollection items = view.Items;
            List<KeyValuePair<String, PoiType>> variables = analyzer.GetTypeInformation();
            foreach (KeyValuePair<String, PoiType> pair in variables)
            {
                ListViewItem lvi = new ListViewItem(pair.Key);
                lvi.SubItems.Add(pair.Value.ToString());
                
                items.Add(lvi);
            }
            view.EndUpdate();
        }

        private String CreateNodeString(Node node)
        {
            String nodeString = node.ToString();
            int valueCount = node.GetValueCount();

            if (valueCount != 0)
            {
                try
                {
                    nodeString += " [Values:";
                    nodeString += " " + (node.GetValue(0) as PoiObject).ToString();
                    nodeString += "]";

                    nodeString += " [Types:";
                    nodeString += " " + (node.GetValue(0) as PoiObject).VariableType.ToString();
                    nodeString += "]";
                }
                catch (Exception)
                {
                }
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
                variableTypeListView.Columns[0].Width = (int)(variableTypeListView.Width * 0.4);
                variableTypeListView.Columns[1].Width = (int)(variableTypeListView.Width * 0.6);
            }
            catch (Exception)
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            parseTreeOutput.BeginUpdate();
            if (collapsed)
            {
                parseTreeOutput.ExpandAll();
                collapsed = false;
            }
            else
            {
                parseTreeOutput.CollapseAll();
                collapsed = true;
            }
            parseTreeOutput.EndUpdate();
        }

        private void codeInput_TextChanged(object sender, EventArgs e)
        {
            TextBoxLineNumbers.UpdateLabelRowIndex(codeInputLineNumbers, codeInput);
        }

        private void codeInput_FontChanged(object sender, EventArgs e)
        {
            TextBoxLineNumbers.UpdateLabelRowIndex(codeInputLineNumbers, codeInput);
            codeInput_VScroll(null, null);
        }

        private void codeInput_Resize(object sender, EventArgs e)
        {
            codeInput_VScroll(null, null);
        }

        private void codeInput_VScroll(object sender, EventArgs e)
        {
            TextBoxLineNumbers.UpdateLabelRowIndex(codeInputLineNumbers, codeInput);
        }
    }
}

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

namespace PoiCSharpAnalyzer
{
    public partial class AnalyzerForm : Form
    {
        public AnalyzerForm()
        {
            InitializeComponent();
        }

        private void parseButton_Click(object sender, EventArgs e)
        {
            String code = codeInput.Text;
            PoiParser parser = new PoiParser(new StringReader(code), new PoiBasicAnalyzer());
            //PoiParser arithmeticParser = new PoiParser(new StringReader(code), new PoiArithmeticAnalyzer());
            Node parseTree = null;
            try
            {
                parseTree = parser.Parse();
                if (parseTree.Values.Count > 0)
                    codeOutput.Text = (parseTree.GetValue(0) as PoiObject).ToString();
                else
                    codeOutput.Text = "";
                //parseTree = arithmeticParser.Parse();
                deleteParseTree(parseTreeOutput.Nodes);
                CreateParseTree(parseTree, parseTreeOutput.Nodes);
                //parseTreeOutput.CollapseAll();
                parseTreeOutput.ExpandAll();
            }
            catch (PerCederberg.Grammatica.Runtime.ParserLogException ex)
            {
                parseTreeOutput.Nodes.Add(ex.GetMessage());
            }
            /*catch (Exception ex)
            {
                codeOutput.Text = ex.Message;
            }*/
        }

        private void deleteParseTree(TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                deleteParseTree(nodes[i].Nodes);
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
    }
}

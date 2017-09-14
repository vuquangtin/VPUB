using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TreeViewColumnsProject
{
    public partial class Form1 : Form
    {
        private Font startupNodeFont;
        private TreeNode selectedVoucherNode;
        private TreeNode selectedVoucherParentNode;
        private TreeNode rootNode;
        private TreeNode selectedGroupNode;
        private TreeNode selectedGroupParentNode;
        private BackgroundWorker bgwLoadGroupWorker;
        private BackgroundWorker bgwLoadItemWorker;
        public Form1()
        {
            InitializeComponent();
            RegistryEvent();
            //TreeNode treeNode = new TreeNode("test");
            //treeNode.Tag = new string[] { "col1", "col2" };

            //// Some random node
            //this.treeViewColumns1.TreeView.Nodes[0].Nodes[0].Nodes.Add(treeNode);

            //this.treeViewColumns1.TreeView.SelectedNode = treeNode;

        }


        public void RegistryEvent()
        {
            //flowLayoutPanel1.a
            //treeViewColumns1.TreeView.BeforeSelect += trvGroup_AfterExpand;
            //treeViewColumns1.TreeView.AfterSelect += trvGroup_BeforeSelect;
            //treeViewColumns1.TreeView.AfterSelect += trvGiftVoucher_AfterSelect;
        }
        private void trvGroup_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadGroupWorker.IsBusy)
            {
                e.Cancel = true;
                return;
            }

            // Change node font style to normal
            if (selectedGroupNode != null)
            {
                selectedGroupNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedGroupNode.Text = selectedGroupNode.Text;
            }
        }

        private void trvGroup_AfterExpand(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.IsExpanded && node != e.Node)
                {
                    node.Collapse();
                }
            }


        }
        private void trvGiftVoucher_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                // selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;

                if (selectedVoucherNode != null && selectedNode == selectedVoucherNode)
                {
                    return;
                }

                selectedVoucherParentNode = selectedNode.Parent;
                selectedVoucherNode = selectedNode;

                if (selectedVoucherNode.Level == 1)
                {

                    //LoadContentList();
                    //SetShowOrHideButton(true);
                    //btnSyncData.Enabled = false;
                }
                else
                {
                    //SetShowOrHideButton(false);
                    //btnSyncData.Enabled = false;
                }
                //currentPageIndex = 1;
            }


        }

        private void treeViewColumns1_Click(object sender, EventArgs e)
        {

        }

        private void treeViewColumns1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;
using Microsoft.VisualBasic;


namespace WebBrowser.UI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            
        
           
            
        }
       

          private void MainWindow_Load(object sender, EventArgs e)
          {

          }

          private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
          {

          }

          private void TabPage2_Click(object sender, EventArgs e)
          {
            MessageBox.Show("Hello");
          }

        private void ExitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ManageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var historyManager = new HistoryManagerForm();

            try
            {
                historyManager.ShowDialog();
            }
            catch (System.Data.ConstraintException)
            {

            }

            



        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi! My name is Mohammad and my student Id is mrz0008. This is my web browser called Pied Piper which has a menu strip, tab bar and toolstrip and is based off the tv show Silicon Valley");
        }

     

       

        public void NewTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPagesControl tb = new TabPagesControl();
            tb.Dock = DockStyle.Fill;
            TabPage newTab = new TabPage("New Tab");
            newTab.Controls.Add(tb);
            tabControl1.TabPages.Add(newTab);
            newTab.Text= tb.getTabName();
            newTab.Focus();
          
            
            

            //open new tab from file
        }

        private void TabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && (e.KeyCode == Keys.T))
            {
                NewTabToolStripMenuItem_Click(sender, e);
                //ctrl t add tab
                

            }
            if (e.Control && (e.KeyCode == Keys.W))
            {
                this.tabControl1.TabPages.RemoveAt(this.tabControl1.SelectedIndex);
                //ctrl w close current tab
            }
        }

        private void CloseCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //close current tab
            this.tabControl1.TabPages.RemoveAt(this.tabControl1.SelectedIndex);
        }

        private void manageBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bookmarkManager = new BookmarkManagerForm();
            bookmarkManager.ShowDialog();
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistoryManager.ClearHistory();
           
        }

        private void printPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(tabControl1.Name,new Font("Times New Roman",14),Brushes.Black,new PointF(100,100));

        }

        private void savePageAsHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            var current = tabControl1.SelectedIndex;
            int totalPages = tabControl1.TabPages.Count;

            if (current > 0) 
            {
                var temp = tabControl1.SelectedTab;
                tabControl1.TabPages.RemoveAt(current);
    
                tabControl1.TabPages.Insert(current - 1, temp);
                tabControl1.SelectedIndex = current - 1;

            } else
            {
                if (current < totalPages - 1) 
                {
                    var temp = tabControl1.SelectedTab;
                    tabControl1.TabPages.RemoveAt(current);

                    tabControl1.TabPages.Insert(current + 1, temp);
                    tabControl1.SelectedIndex = current + 1;

                }
            }
            
        }
    }
}

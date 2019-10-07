using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using WebBrowser.Logic;


namespace WebBrowser.UI
{
    public partial class TabPagesControl : UserControl
    {
        
        Stack<string> backField = new Stack<string>();
        Stack<string> forwardLinks = new Stack<string>();
        public TabPagesControl()
        {
            InitializeComponent();
        }
        public TabPagesControl(MainWindow mw)
        {

        }
      

        private void ToolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void ToolStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                ToolStripButton5_Click(sender, e);
                webBrowser1.ScriptErrorsSuppressed = true;

                
            }
        }

        public void ToolStripButton5_Click(object sender, EventArgs e)
        {
            


                webBrowser1.Navigate(toolStripTextBox1.Text);
                backField.Push(toolStripTextBox1.Text);
                webBrowser1.ScriptErrorsSuppressed = true;





            //var page = new HistoryItem();
            //string title = ((HtmlDocument)webBrowser1.Document).Title;
            //page.Title = title;
            //page.URL = toolStripTextBox1.Text;
            //page.Date = DateTime.Now;
            //HistoryManager.AddItem(page);





        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            //webBrowser1.Navigate(toolStripTextBox1.Text.ToString());
            webBrowser1.Refresh();
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {

            try
            {
                //back button
                if (backField.Count == 0)
                {
                    return;
                }
                forwardLinks.Push(toolStripTextBox1.Text);
                
                webBrowser1.Navigate(backField.Pop());
            }
            catch
            {
                return;
            }
        }



        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            //forward button
            try
            {
                if (forwardLinks.Count == 0)
                {
                    return;
                }
                backField.Push(toolStripTextBox1.Text);
                webBrowser1.Navigate(forwardLinks.Pop());
            }
            catch
            {
                return;
            }

           

        }

        public string getTabName()
        {
            string tabname= "New Tab";
            if (toolStripTextBox1.Text == "")
            {
                return tabname;
            }
            return tabname + webBrowser1.DocumentTitle;
        }

        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {

          
            Uri uri = new Uri(webBrowser1.Url.ToString());
            toolStripTextBox1.Text = uri.ToString();

            
           

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            var bookmark = new BookmarkItem();
            string title = ((HtmlDocument)webBrowser1.Document).Title;
            bookmark.Title = title;
            bookmark.URL = toolStripTextBox1.Text;
            var AlreadyExists = BookmarkManager.GetItems();
            if (!AlreadyExists.Contains(bookmark))
            {
                BookmarkManager.AddItem(bookmark);
            }
            

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {


            //removed history
            var page = new HistoryItem();
            string title = ((HtmlDocument)webBrowser1.Document).Title;
            page.Title = title;
            page.URL = toolStripTextBox1.Text;
            page.Date = DateTime.Now;
            HistoryManager.AddItem(page);
            toolStripStatusLabel1.Text = "Done";
          



        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            try
            {
                if (e.MaximumProgress > 0 && e.CurrentProgress > 0)
                {
                    toolStripProgressBar1.ProgressBar.Maximum = Convert.ToInt32(e.MaximumProgress);
                    toolStripProgressBar1.ProgressBar.Value = Convert.ToInt32(e.CurrentProgress);
                }
                if (e.CurrentProgress > toolStripProgressBar1.ProgressBar.Maximum)
                {
                    toolStripProgressBar1.ProgressBar.Value = 0;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
                return;
            }
           
            
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            toolStripStatusLabel1.Text = "Loading";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = true;
            toolStripTextBox1.Text = "csonline.eng.auburn.edu";
            ToolStripButton5_Click(sender, e);
        }
    }
}

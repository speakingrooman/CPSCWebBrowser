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

namespace WebBrowser.UI
{
    public partial class HistoryManagerForm : Form
    {
        public HistoryManagerForm()
        {
            InitializeComponent();
        }

        private void HistoryManagerForm_Load(object sender, EventArgs e)
        {
            
                var history = HistoryManager.GetItems();
                listBox1.Items.Clear();
                foreach (var pages in history)
                {
                    listBox1.Items.Add(string.Format("[{0}] {1}({2})", pages.Date, pages.Title, pages.URL));
                }
          
            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

           HistoryManager.deleteSingle(listBox1.GetItemText(listBox1.SelectedItem));
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            listBox1.Update();
            listBox1.Refresh();


        }



        private void buttonclrHist_Click(object sender, EventArgs e)
        {
           
            HistoryManager.ClearHistory();
            listBox1.Items.Clear();
            listBox1.Refresh();
        }

        private void buttonSearchTerm_Click(object sender, EventArgs e)
        {
            var search = textBoxSearchTerm.Text;
            for(int i=listBox1.Items.Count-1;i>=0;i--)
            {
                if (!listBox1.Items[i].ToString().ToLower().Contains(search.ToLower()))
                {
                    listBox1.Items.Remove(listBox1.Items[i]);
                    listBox1.Refresh();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }
    }
}

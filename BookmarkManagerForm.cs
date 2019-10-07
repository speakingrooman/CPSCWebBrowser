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
using WebBrowser.UI;

namespace WebBrowser.UI
   
{
    public partial class BookmarkManagerForm : Form
    {
        public BookmarkManagerForm()
        {
            InitializeComponent();
        }

        private void BookmarkManagerForm_Load(object sender, EventArgs e)
        {
            var bookmarks = BookmarkManager.GetItems();
            listBox1.Items.Clear();
            foreach (var bookmark in bookmarks)
            {
                listBox1.Items.Add(string.Format("{0} ({1})", bookmark.Title, bookmark.URL));
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var search = textBoxSearch.Text;
            
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (!listBox1.Items[i].ToString().ToLower().Contains(search.ToLower()))
                {
                    listBox1.Items.Remove(listBox1.Items[i]);
                    listBox1.Refresh();
                }
            }
            textBoxSearch.Text = "";
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

          

            BookmarkManager.deleteSingle(listBox1.GetItemText(listBox1.SelectedItem));
            listBox1.Refresh();
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            listBox1.Refresh();


        

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.BookmarkDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class BookmarkManager
    {
        public static void AddItem(BookmarkItem item)
        {
            var adapter = new BookmarksTableAdapter();
            adapter.Insert(item.Title, item.URL);
        }
        public static List<BookmarkItem> GetItems()
        {

                var adapter = new BookmarksTableAdapter();
                var results = new List<BookmarkItem>();
                try
                {
                    var rows = adapter.GetData();
                foreach (var row in rows)
                {
                    var item = new BookmarkItem();
                    item.Title = row.Title;
                    item.URL = row.URL;
                    item.ID = row.Id;


                    results.Add(item);
                }
                return results;
            }
            catch (System.Data.ConstraintException)
            {
                return results;
            }
        }
        public static void deleteItem(int idx)
        {
            var adapter = new BookmarksTableAdapter();
            adapter.DeleteBM(idx);
        }

        public static void deleteSingle(string idx)
        {
            var adapter = new BookmarksTableAdapter();
            var rows = adapter.GetData();

            //(string.Format("[{0}] {1}({2})", pages.Date, pages.Title, pages.URL));

            foreach (var row in rows)
            {
                if (string.Format("{0} ({1})", row.Title, row.URL) == idx)
                {
                    row.Delete();
                }
            }
            adapter.Update(rows);
        }

    }
}

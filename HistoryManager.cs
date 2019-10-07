using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBrowser.Data.HistoryDataSetTableAdapters;

namespace WebBrowser.Logic
{
    public class HistoryManager
    {
        public static void AddItem(HistoryItem item)
        {
            var adapter = new HistoryTableAdapter();
            adapter.Insert(item.Title, item.URL, item.Date);
        }
        public static List<HistoryItem> GetItems()
        {


            var adapter = new HistoryTableAdapter();
            var results = new List<HistoryItem>();
            try
            {
                var rows = adapter.GetData();
                foreach (var row in rows)
                {
                    var item = new HistoryItem();
                    item.Title = row.Title;
                    item.URL = row.URL;
                    item.ID = row.Id;
                    item.Date = row.Date;

                    results.Add(item);
                }
                return results;
            }
            catch (System.Data.ConstraintException)
            {
                return results;
            }
        }
        public static void ClearHistory()
        {
            var pages = new HistoryTableAdapter();
            var rows = pages.GetData();
            foreach (var row in rows)
            {
                row.Delete();
            }
            pages.Update(rows);

        }

        public static void deleteItem(int idx)
        {
            var adapter = new HistoryTableAdapter();
            //adapter.DeleteHP(idx+1);

            var rows = adapter.GetData();
            foreach (var row in rows)
            {
                if (row.Id == (idx + 1))
                {
                    row.Delete();
                }
            }
            adapter.Update(rows);



        }

        public static void deleteSingle(string idx)
        {
            var adapter = new HistoryTableAdapter();
            var rows = adapter.GetData();

            //(string.Format("[{0}] {1}({2})", pages.Date, pages.Title, pages.URL));

            foreach (var row in rows)
            {
                if (string.Format("[{0}] {1}({2})", row.Date, row.Title, row.URL) == idx)
                {
                    row.Delete();
                }
            }
            adapter.Update(rows);
        }
    }
        
}

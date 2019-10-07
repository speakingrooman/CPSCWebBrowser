using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Logic
{
    public class HistoryItem
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public int ID { get; set; }
        public DateTime Date { get; set; }
    }
}

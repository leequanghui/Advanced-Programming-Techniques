using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convenience_App
{
    public class Item
    {
        public string Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public string When { get { return StartTime.ToString("dd MMMM yyyy HH:mm:ss"); } }
        public string Subject { get; set; }
        public string Details { get; set; }
    }
}

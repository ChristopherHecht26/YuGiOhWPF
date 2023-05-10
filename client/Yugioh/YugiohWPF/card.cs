using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YugiohWPF
{
    internal class card : INotifyCollectionChanged
    {
        public string name { get; set; }
        public string type { get; set; }
        public string frameType { get; set; }
        public string desc { get; set; }
        public string atk { get; set; }
        public string def { get; set; }
        public string level { get; set; }
        public string race { get; set; }
        public string attribute { get; set; }
        public string archetype { get; set; }
        public string cardimage { get; set; }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
    }
}

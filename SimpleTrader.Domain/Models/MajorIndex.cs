using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.EntityFramework.Models
{

    public enum MajorIndexType
    {
        DowJones,
        Nasdaq,
        SP500
    }
    public class MajorIndex
    {
        public double price { get; set; }
        public double changes { get; set; }
        public MajorIndexType Type { get; set; }
        public string indexName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Classes.ColdChain
{
    public class Buffer
    {
        public List<BufferRow> Rows { get; private set; }

        public Buffer()
        {
            Rows = new List<BufferRow>();
        }
    }

    public class BufferRow
    {
        public List<BufferCell> Cells { get; private set; }

        public BufferRow()
        {
            Cells = new List<BufferCell>();
        }

        public BufferRow(IEnumerable<object> values)
            : this()
        {
            foreach (var value in values)
                Cells.Add(new BufferCell(value));
        }
    }

    public class BufferCell
    {
        public object Value { get; private set; }

        public BufferCell(object value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return string.Format("{0}", Value);
        }
    }
}

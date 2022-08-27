using System;
using System.Collections.Generic;
using System.Text;

namespace ShiftManagement.Entitties
{
    public class Shift : BaseEntity
    {
        public DateTime StartShift { get; set; }
        public DateTime EndShift { get; set; }
        public DateTime StartBreak { get; set; }
        public DateTime EndBreak { get; set; }
    }
}

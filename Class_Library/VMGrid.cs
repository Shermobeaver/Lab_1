using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public class VMGrid
    {
        // Properties
        public int Length { get; set; }
        public double LeftEnd { get; set; }
        public double RightEnd { get; set; }
        public double Step
        {
            get
            {
                return Math.Abs(RightEnd - LeftEnd) / Length;
            }
        }
        public VMf CurFunction { get; set; }

        // Constructor
        public VMGrid(int inLength, double inLeftEnd, double inRightEnd, double inStep, VMf inCurFunction)
        {
            Length = inLength;
            LeftEnd = inLeftEnd;
            RightEnd = inRightEnd;
            CurFunction = inCurFunction;
        }

        // Clone Constructor
        public VMGrid(VMGrid other)
        {
            Length = other.Length;
            LeftEnd = other.LeftEnd;
            RightEnd = other.RightEnd;
            CurFunction = other.CurFunction;
        }
    }
}

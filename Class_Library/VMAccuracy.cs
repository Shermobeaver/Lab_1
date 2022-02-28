using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public struct VMAccuracy
    {
        // Properties
        public VMGrid Grid { get; set; }
        public double Abs_of_Max_Diff { get; set; }
        public double Arg_for_Max_Diff { get; set; }
        public double WML_HA_value { get; set; }
        public double WML_EP_value { get; set; }

        // Output
        override public string ToString()
        {
            return string.Format($"Grid: Length: {Grid.Length}, LeftEnd: {Grid.LeftEnd:0.00000000}, RightEnd: {Grid.RightEnd:0.00000000}, Step: {Grid.Step:0.00000000}, CurFunction: {Grid.CurFunction}\nAbs_of_Diff: {Abs_of_Max_Diff:0.00000000}; Arg_for_Max_Diff: {Arg_for_Max_Diff:0.00000000}; WML_HA_value: {WML_HA_value:0.00000000}; WML_EP_value: {WML_EP_value:0.00000000}.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Library
{
    public struct VMTime
    {
        // Properties
        public VMGrid Grid { get; set; }
        public double VML_HA_Time { get; set; }
        public double WML_EP_Time { get; set; }
        public double WML_HA_Coef { get; set; }
        public double WML_EP_Coef { get; set; }

        // Output
        override public string ToString()
        {
            return string.Format($"Grid: Length: {Grid.Length}, LeftEnd: {Grid.LeftEnd:0.00000000}, RightEnd: {Grid.RightEnd:0.00000000}, Step: {Grid.Step:0.00000000}, CurFunction: {Grid.CurFunction}\nVML_HA_Time: {VML_HA_Time:0.00000000}; WML_EP_Time: {WML_EP_Time:0.00000000}; WML_HA_Coef: {WML_HA_Coef:0.00000000}; WML_EP_Coef: {WML_EP_Coef:0.00000000}.");
        }
    }
}

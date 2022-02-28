using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Class_Library
{
    public class VMBenchmark : INotifyPropertyChanged
    {
        // Properties
        public ObservableCollection<VMTime> Collection1 { get; set; }
        public ObservableCollection<VMAccuracy> Collection2 { get; set; }
        public double Min_WML_HA_Coef {
            get
            {
                if (Collection1.Count < 1)
                {
                    return -1;
                }
                double minCoef = Collection1[0].WML_HA_Coef;
                foreach (VMTime item in Collection1)
                {
                    if (item.WML_HA_Coef < minCoef)
                    {
                        minCoef = item.WML_HA_Coef;
                    }
                }
                return minCoef;
            }
        }
        public double Max_WML_HA_Coef {
            get
            {
                if (Collection1.Count < 1)
                {
                    return -1;
                }
                double minCoef = Collection1[0].WML_HA_Coef;
                foreach (VMTime item in Collection1)
                {
                    if (item.WML_HA_Coef > minCoef)
                    {
                        minCoef = item.WML_HA_Coef;
                    }
                }
                return minCoef;
            }
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;

        // Constructor
        public VMBenchmark()
        {
            Collection1 = new();
            Collection2 = new();
            Collection1.CollectionChanged += Collection_CollectionChanged;
        }

        private void Collection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Min_WML_HA_Coef)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Max_WML_HA_Coef)));
        }

        // Externs
        [DllImport("..\\..\\..\\..\\x64\\Debug\\MKL_DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GlobMKLFunc(int length, double[] vector, int CurFunction, double[] res1, double[] res2, double[] res3, double[] res4);

        // Methods
        public void AddVMTime(VMGrid Grid)
        {
            VMTime item = new();
            item.Grid = new(Grid);
            double[] vector = new double[Grid.Length];
            for(int i = 0; i < Grid.Length; i++)
            {
                vector[i] = Grid.LeftEnd + (i * Grid.Step);
            }
            double[] res_HA = new double[Grid.Length];
            double[] res_EP = new double[Grid.Length];
            double[] res_NOMKL = new double[Grid.Length];
            double[] Times = new double[3];
            double status = GlobMKLFunc(Grid.Length, vector, (int)Grid.CurFunction, res_HA, res_EP, res_NOMKL, Times);
            if (status != 0)
            {
                throw new InvalidCastException($"GlobMKLFunc faild with: {status}");
            }
            item.VML_HA_Time = Times[0];
            item.WML_EP_Time = Times[1];
            item.WML_HA_Coef = Times[0] / Times[2];
            item.WML_EP_Coef = Times[1] / Times[2];
            Collection1.Add(item);
        }

        public void AddVMAccuracy(VMGrid Grid)
        {
            VMAccuracy item = new();
            item.Grid = new(Grid);
            double[] vector = new double[Grid.Length];
            for (int i = 0; i < Grid.Length; i++)
            {
                vector[i] = Grid.LeftEnd + (i * Grid.Step);
            }
            double[] res_HA = new double[Grid.Length];
            double[] res_EP = new double[Grid.Length];
            double[] res_NOMKL = new double[Grid.Length];
            double[] Times = new double[3];
            double status = GlobMKLFunc(Grid.Length, vector, (int)Grid.CurFunction, res_HA, res_EP, res_NOMKL, Times);
            item.Abs_of_Max_Diff = 0;
            for (int i = 0; i < Grid.Length; i++)
            {
                if (Math.Abs(res_HA[i] - res_EP[i]) > item.Abs_of_Max_Diff)
                {
                    item.Abs_of_Max_Diff = Math.Abs(res_HA[i] - res_EP[i]);
                    item.Arg_for_Max_Diff = vector[i];
                    item.WML_HA_value = res_HA[i];
                    item.WML_EP_value = res_EP[i];
                }
            }
            Collection2.Add(item);
        }
    }
}

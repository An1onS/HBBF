using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models.Output
{
	public class Income
	{
		public double O2_HeatCapacity { set; get; }
		public double N2_HeatCapacity { set; get; }
		public double H2O_HeatCapacity { set; get; }
		public double CokeHeat { set; get; }
		public double CokeHeatPercent { set; get; }
		public double AirHeat { set; get; }
		public double AirHeatPercent { set; get; }
		public double GasHeat { set; get; }
		public double GasHeatPercent { set; get; }
		public double SlagHeat { set; get; }
		public double SlagHeatPercent { set; get; }
		public double Sum { set; get; }
		public double SumPercent { set; get; }
	}
}

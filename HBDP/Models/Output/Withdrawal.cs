using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models.Output
{
	public class Withdrawal
	{
		public double CO_HeatCapacity { set; get; }
		public double CO2_HeatCapacity { set; get; }
		public double H2_HeatCapacity { set;get;}
		public double H2O_HeatCapacity { set; get; }
		public double N2_HeatCapacity { set; get; }
		public double FeReduction { set; get; }
		public double FeReductionPercent { set; get; }
		public double ResidualsReduction { set; get; }
		public double ResidualsReductionPercent { set; get; }
		public double Desulfuration { set; get; }
		public double DesulfurationPercent { set; get; }
		public double Fe_H2_Reduction { set; get; }
		public double Fe_H2_ReductionPercent { set; get; }
		public double PigIronHeating { set; get; }
		public double PigIronHeatingPercent { set; get; }
		public double SlagHeating { set; get; }
		public double SlagHeatingPercent { set; get; }
		public double DegradingAirH20 { set; get; }
		public double DegradingAirH20_Percent { set; get; }
		public double DegradingStock { set; get; }
		public double DegradingStockPercent { set; get; }
		public double TopGas{set;get;}
		public double TopGasPercent{set;get;}
		public double Losses{set;get;}
		public double LossesPercent{ set;get;}
		public double Sum { set; get; }
		public double SumPercent { set; get; }
	}
}

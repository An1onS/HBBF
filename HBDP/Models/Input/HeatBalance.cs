using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models.Input
{
	public class HeatBalance
	{
		public HeatBalance(Regime regime,PigIron iron, Coke coke)
		{
			this.iron = iron;
			this.coke = coke;
		}
		Regime regime;
		PigIron iron;
		Coke coke;
		/// <summary>
		/// Расход углерода кокса на прямое восстановление оксидов Fe
		/// </summary>
		public double CarbonToFeReduction => iron.Fe * 10 * regime.StraightReduction * 12 / 56;
		/// <summary>
		/// Количество углерода, сгорающего у фурм
		/// </summary>
		/*public double CarbonBurnt => coke.Carbon - (CarbonToFeReduction +
			iron.CarbonToResidualsReduction + iron.Carbon + coke.CarbonToMethane);*/
	}
}

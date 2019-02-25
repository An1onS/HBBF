using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models.Input
{
	public class PigIron
	{
		public double Si { set; get; }
		public double Mn { set; get; }
		public double S { set; get; }
		public double P { set; get; }
		public double Ti { set; get; }
		public double Cr { set; get; }
		public double V { set; get; }
		public double C { set; get; }
		public int Temperature { set; get; }
		public double HeatCapacity { set; get; }

		/// <summary>
		/// Содержание Fe в чугуне
		/// </summary>
		public double Fe => 100 - Si - Mn - P - S - Ti - Cr - V - C;
		/// <summary>
		/// Переход углерода в чугун ??
		/// </summary>
		/// #rename
		public double Carbon => 10 * C;
		/// <summary>
		/// Расход углерода на прямое восстановление примесей чугуна: Mn,P,Si,S,V,Ti,Cr
		/// </summary>
		/// numbers => constatns
		public double CarbonToResidualsReduction => 10 * (Mn * 12 / 55 + P * 60 / 62 +
			Si * 24 / 28 + S * 12 / 32 +
			V * 60 / 110 + Ti * 12 / 48 +
			Cr * 48 / 104);
	}
}

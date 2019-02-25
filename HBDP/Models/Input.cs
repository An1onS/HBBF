using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models
{
	public class Input
	{
		#region PigIron
		public double Si { set; get; }
		public double Mn { set; get; }
		public double S { set; get; }
		public double P { set; get; }
		public double Ti { set; get; }
		public double Cr { set; get; }
		public double V { set; get; }
		public double C { set; get; }
		public double Temperature { set; get; }
		public double HeatCapacity { set; get; }
		#endregion
		/// <summary>
		/// Степень прямого восстановления железа
		/// </summary>
		public double StraightReduction { set; get; }
		#region Coke
		/// <summary>
		/// Удельный расход кокса
		/// </summary>		
		public double Consumption { set; get; }
		/// <summary>
		/// Зола кокса
		/// </summary>
		public double Ash { set; get; }
		/// <summary>
		/// Сера кокса
		/// </summary>
		public double Sulfur { set; get; }
		/// <summary>
		/// Летучие кокса
		/// </summary>
		public double Volatiles { set; get; }
		/// <summary>
		/// Влага кокса
		/// </summary>
		public double Dampness { set; get; }
		#endregion
		#region AirBlasting
		public double AirBlastingTemperature { set; get; }
		/// <summary>
		/// Влажность дутья
		/// </summary>
		public double AirBlastingDampness { set; get; }
		public double OxygenPercent { set; get; }
		public double AirBlastingConsumption { set; get; }
		public double Methane { set; get; }
		public double Ethane { set; get; }
		public double CarbonDioxide { set; get; }
		/// <summary>
		/// Содержание С в природном газе
		/// </summary>
		public double Carbon { set; get; }
		/// <summary>
		/// Содержание  Н2 в природном газе
		/// </summary>
		public double Hydrogen { set; get; }
		#endregion
		#region Limestone
		public double LimestoneConsumption { set; get; }
		public double LimestoneDampness { set; get; }
		/// <summary>
		/// Потеря массы при прокаливании
		/// </summary>
		public double MassLose { set; get; }
		#endregion
		#region Slag
		public double Ratio { set; get; }
		public double SlagSulfur { set; get; }
		public double SlagHeatCapacity { set; get; }
		#endregion
		#region TopGas
		public double TopGasTemperature { set; get; }
		public double CO2 { set; get; }
		public double CO { set; get; }
		public double H2 { set; get; }
		public double N2 { set; get; }
		#endregion
		#region IronOrematerials
		public double Consumption_IronMaterial { set; get; }
		public double Consumption_IronAddings { set; get; }
		public double IOMDampness { set; get; }
		#endregion
	}
}

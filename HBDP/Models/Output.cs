using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models
{
	public class Output
	{
		#region Income
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
		#endregion
		#region Withdrawal
		public double CO_HeatCapacity { set; get; }
		public double CO2_HeatCapacity { set; get; }
		public double H2_HeatCapacity { set; get; }
		public double W_H2O_HeatCapacity { set; get; }
		public double W_N2_HeatCapacity { set; get; }
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
		public double TopGas { set; get; }
		public double TopGasPercent { set; get; }
		public double Losses { set; get; }
		public double LossesPercent { set; get; }
		public double W_Sum { set; get; }
		public double W_SumPercent { set; get; }
		#endregion
		#region Influence
		/// <summary>
		/// Приход тепла от горения кокса у фурм и горячего дутья за вычетом тепла,
		/// уносимого колошниковым газом
		/// </summary>
		public double Q { set; get; }
		/// <summary>
		/// Q, отнесенное к количеству углерода, сгорающего у фурм
		/// </summary>
		public double QtoC { set; get; }
		/// <summary>
		/// Содержание углерода в коксе
		/// </summary>
		public double CokeC { set; get; }
		#region 1.Влияние степени прямого восстановления на расход кокса
		/// <summary>
		/// Снижение статьи расхода тепла на прямое восстановление при уменьшении rd на 0,01
		/// </summary>
		public double Rd { set; get; }
		/// <summary>
		/// Снижение расхода кокса
		/// </summary>
		public double RdCoke { set; get; }
		#endregion
		#region 2.Влияние ввода в печь сырого известняка на расход кокса
		/// <summary>
		/// Снижение статьи расхода тепла на разложение известняка при выводе его из шихты в количетве 10 кг  
		/// </summary>
		public double Limestone { set; get; }
		/// <summary>
		/// Эквивалентное снижение расхода кокса
		/// </summary>
		public double LimestoneCoke { set; get; }
		/// <summary>
		/// Экономия кокса от полного вывода известняка (учет устранения статьи расхода тепла на разложение известняка)
		/// </summary>
		public double LimestoneFull { set; get; }
		#endregion
		#region 3.Влияние температуры горячего дутья на расход кокса
		/// <summary>
		/// Прирост статьи притока тепла горячего дутья при повышении его температуры на 10 °C
		/// </summary>
		public double AirBlasting { set; get; }
		/// <summary>
		/// Экономия кокса при повышении температуры дутья на 10 °C
		/// </summary>
		public double AirBlastingCoke { set; get; }
		#endregion
		#region 4.Влияние состава комбинированного дутья на расход кокса
		/// <summary>
		/// Прирост статьи притока тепла от конверсии природного газа при повышении его расхода на 10 м3/т
		/// </summary>
		public double Conversion { set; get; }
		/// <summary>
		/// Экономия кокса при повышении расхода природного газа на 10 м3/т
		/// </summary>
		public double ConversionCoke { set; get; }
		#endregion
		#region 5.Влияние влажности комбинированного дутья на расход кокса
		/// <summary>
		/// Снижение статьи расхода тепла на разложение влаги дутья при уменьшении влажности дутья на 1 г/м3
		/// </summary>
		public double Dampness { set; get; }
		/// <summary>
		/// Экономия кокса при снижении влажности дутья на 1 г/м3
		/// </summary>
		public double DampnessCoke { set; get; }
		#endregion
		#region 6.Влияние выхода шлака на расход кокса
		/// <summary>
		/// Экономия тепла при снижении выхода шлака на 10 кг
		/// </summary>
		public double SlagHeatEconomy { set; get; }
		/// <summary>
		/// Экономия кокса при снижении выхода шлака на 10 кг
		/// </summary>
		public double SlagCokeEconomy { set; get; }
		#endregion
		#region 7.Влияние тепловых потерь доменной печи на расход кокса
		/// <summary>
		/// Экономия тепла при снижении тепловых потерь печи на 1 %
		/// </summary>
		public double LossesHeatEconomy { set; get; }
		/// <summary>
		/// Экономия кокса при снижении тепловых потерь печи на 1 %
		/// </summary>
		public double LossesCokeEconomy { set; get; }
		#endregion
		#endregion
	}
}

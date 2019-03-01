namespace HBDP.Models
{
	public class InfluenceData
	{
		/// <summary>
		/// Приход тепла от горения кокса у фурм и горячего дутья за вычетом тепла, уносимого колошниковым газом
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
		/// <summary>
		/// Снижение статьи расхода тепла на прямое восстановление при уменьшении rd на 0,01
		/// </summary>
		public (double value, double economy) Rd { set; get; }
		/// <summary>
		/// Снижение статьи расхода тепла на разложение известняка при выводе его из шихты в количетве 10 кг  
		/// </summary>
		public (double value, double coke, double full) Limestone { set; get; }
		/// <summary>
		/// Прирост статьи притока тепла горячего дутья при повышении его температуры на 10 °C
		/// </summary>
		public (double value, double economy) AirBlasting { set; get; }
		/// <summary>
		/// Прирост статьи притока тепла от конверсии природного газа при повышении его расхода на 10 м3/т
		/// </summary>
		public (double value, double economy) Combined { set; get; }
		/// <summary>
		/// Снижение статьи расхода тепла на разложение влаги дутья при уменьшении влажности дутья на 1 г/м3
		/// </summary>
		public (double value, double economy) Dampness { set; get; }
		/// <summary>
		/// Экономия при снижении выхода шлака на 10 кг
		/// </summary>
		public (double heat, double coke) SlagProduction { set; get; }
		/// <summary>
		/// Экономия при снижении тепловых потерь печи на 1 %
		/// </summary>
		public (double heat, double coke) HeatLosses { set; get; }
	}
}

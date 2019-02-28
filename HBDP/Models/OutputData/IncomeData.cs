namespace HBDP.Models
{
	public class IncomeData
	{
		/// <summary>
		/// 1. Количество тепла, получающегося при горении углерода кокса
		/// </summary>
		public double CokeHeat { set; get; }
		public double CokeHeatPercent { set; get; }
		public double O2_HeatCapacity { set; get; }
		public double N2_HeatCapacity { set; get; }
		public double H2O_HeatCapacity { set; get; }
		/// <summary>
		/// 2. Количество тепла от нагретого дутья
		/// </summary>
		public double AirHeat { set; get; }
		public double AirHeatPercent { set; get; }
		/// <summary>
		/// 3. Количество тепла от конверсии природного газа
		/// </summary>
		public double GasHeat { set; get; }
		public double GasHeatPercent { set; get; }
		/// <summary>
		/// 4. Количество тепла от шлакообразования
		/// </summary>
		public double SlagHeat { set; get; }
		public double SlagHeatPercent { set; get; }
		/// <summary>
		/// Сумма приходных статей теплового баланса
		/// </summary>
		public double Sum { set; get; }
		public double SumPercent { set; get; }
	}
}

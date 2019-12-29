namespace HBDP.Models
{
	public class IncomeData
	{
		/// <summary>
		/// 1. Количество тепла, получающегося при горении углерода кокса
		/// </summary>
		public double CokeHeat { set; get; }
		/// <summary>
		/// % Тепла от кокса
		/// </summary>
		public double CokeHeatPercent { set; get; }
		/// <summary>
		/// Теплоемкость O2
		/// </summary>
		public double O2_HeatCapacity { set; get; }
		/// <summary>
		/// Теплоемкость N2
		/// </summary>
		public double N2_HeatCapacity { set; get; }
		/// <summary>
		/// Теплоемкость H2O
		/// </summary>
		public double H2O_HeatCapacity { set; get; }
		/// <summary>
		/// 2. Количество тепла от нагретого дутья
		/// </summary>
		public double AirHeat { set; get; }
		/// <summary>
		/// % Тепла от дутья
		/// </summary>
		public double AirHeatPercent { set; get; }
		/// <summary>
		/// 3. Количество тепла от конверсии природного газа
		/// </summary>
		public double GasHeat { set; get; }
		/// <summary>
		/// % Тепла от природного газа
		/// </summary>
		public double GasHeatPercent { set; get; }
		/// <summary>
		/// 4. Количество тепла от шлакообразования
		/// </summary>
		public double SlagHeat { set; get; }
		/// <summary>
		/// % Тепла от шлакообразования
		/// </summary>
		public double SlagHeatPercent { set; get; }
		/// <summary>
		/// Сумма приходных статей теплового баланса
		/// </summary>
		public double Sum { set; get; }
		/// <summary>
		/// Суммарный процент
		/// </summary>
		public double SumPercent { set; get; }
	}
}

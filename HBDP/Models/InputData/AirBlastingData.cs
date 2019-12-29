namespace HBDP.Models
{
	/// <summary>
	/// Свойства дутья
	/// </summary>
	public class AirBlastingData
	{
		/// <summary>
		/// Температура
		/// </summary>
		public double Temperature { set; get; }
		/// <summary>
		/// Влажность
		/// </summary>
		public double Dampness { set; get; }
		/// <summary>
		/// Процент кислорода
		/// </summary>
		public double OxygenPercent { set; get; }
		/// <summary>
		/// Расход
		/// </summary>
		public double Consumption { set; get; }
		/// <summary>
		/// Доля метана
		/// </summary>
		public double Methane { set; get; }
		/// <summary>
		/// Доля этана
		/// </summary>
		public double Ethane { set; get; }
		/// <summary>
		/// Содержание CO2
		/// </summary>
		public double CarbonDioxide { set; get; }
		/// <summary>
		/// Содержание С
		/// </summary>
		public double Carbon { set; get; }
		/// <summary>
		/// Содержание  Н2
		/// </summary>
		public double Hydrogen { set; get; }
	}
}

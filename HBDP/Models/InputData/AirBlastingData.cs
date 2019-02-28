namespace HBDP.Models
{
	public class AirBlastingData
	{
		public double Temperature { set; get; }
		/// <summary>
		/// Влажность дутья
		/// </summary>
		public double Dampness { set; get; }
		public double OxygenPercent { set; get; }
		public double Consumption { set; get; }
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
	}
}

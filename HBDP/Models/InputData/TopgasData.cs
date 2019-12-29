namespace HBDP.Models
{
	/// <summary>
	/// Свойства доменного газа
	/// </summary>
	public class TopGasData
	{
		/// <summary>
		/// Температура
		/// </summary>
		public double Temperature { set; get; }
		/// <summary>
		/// % CO2
		/// </summary>
		public double CO2 { set; get; }
		/// <summary>
		/// % CO
		/// </summary>
		public double CO { set; get; }
		/// <summary>
		/// % H2
		/// </summary>
		public double H2 { set; get; }
		/// <summary>
		/// % N2
		/// </summary>
		public double N2 { set; get; }
	}
}
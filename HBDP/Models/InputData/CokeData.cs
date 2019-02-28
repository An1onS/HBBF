namespace HBDP.Models
{
	public class CokeData
	{
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
	}
}

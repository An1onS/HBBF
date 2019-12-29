namespace HBDP.Models
{
	/// <summary>
	/// Свойства кокса
	/// </summary>
	public class CokeData
	{
		/// <summary>
		/// Удельный расход
		/// </summary>
		public double Consumption { set; get; }
		/// <summary>
		/// Зола
		/// </summary>
		public double Ash { set; get; }
		/// <summary>
		/// Сера
		/// </summary>
		public double Sulfur { set; get; }
		/// <summary>
		/// Летучие
		/// </summary>
		public double Volatiles { set; get; }
		/// <summary>
		/// Влага
		/// </summary>
		public double Dampness { set; get; }
	}
}

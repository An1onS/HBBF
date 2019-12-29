namespace HBBF.Models
{
	/// <summary>
	/// Свойства шлака
	/// </summary>
	public class SlagData
	{
		/// <summary>
		/// Коэффициент шлакообразования ?
		/// </summary>
		public double Ratio { set; get; }
		/// <summary>
		/// Процент серы
		/// </summary>
		public double Sulfur { set; get; }
		/// <summary>
		/// Теплоемкость
		/// </summary>
		public double HeatCapacity { set; get; }
	}
}

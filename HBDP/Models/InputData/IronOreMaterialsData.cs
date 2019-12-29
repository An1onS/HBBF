namespace HBDP.Models
{
	/// <summary>
	/// Свойства Железнорудных материалов
	/// </summary>
	public class IronOreMaterialsData
	{
		/// <summary>
		/// Расход
		/// </summary>
		public double Consumption_IronMaterial { set; get; }
		/// <summary>
		/// РАсход добавок
		/// </summary>
		public double Consumption_IronAddings { set; get; }
		/// <summary>
		/// Влажность
		/// </summary>
		public double IOMDampness { set; get; }
	}
}

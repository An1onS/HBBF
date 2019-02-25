using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models.Input
{
	public class Coke
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
		/// <summary>
		/// Содержание нелетучих элементов в коксе
		/// </summary>
		double NonVolatiles => 100 - Ash - Sulfur - Volatiles;
		/// <summary>
		/// Количество углерода, пришедшего в печь с коксом
		/// </summary>
		double Carbon => 0.01 * Consumption * NonVolatiles;
		/// <summary>
		/// Расход углерода на образование метана
		/// </summary>
		double CarbonToMethane => 0.008 * Carbon;
	}
}

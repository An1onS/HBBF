using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models.Input
{
	public class Limestone
	{
		public double Consumption { set; get; }
		public double Dampness { set; get; }
		/// <summary>
		/// Потеря массы при прокаливании
		/// </summary>
		public double MassLose { set; get; }
	}
}

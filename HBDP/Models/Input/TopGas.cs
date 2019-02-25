using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models.Input
{
	public class TopGas
	{
		public double Temperature { set; get; }
		public double CO2
		{
			set { if (100 - CO - H2 - N2 >= value) CO2 = value; }
			get => CO2;
		}
		public double CO
		{
			set { if (100 - CO2 - H2 - N2 >= value) CO = value; }
			get => CO;
		}
		public double H2
		{
			set { if (100 - CO2 - CO - N2 >= value) H2 = value; }
			get => H2;
		}
		public double N2
		{
			set { if (100 - CO2 - CO - H2 >= value) N2 = value; }
			get => N2;
		}
	}
}

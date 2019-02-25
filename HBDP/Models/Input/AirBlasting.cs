using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBDP.Models.Input
{
	public class AirBlasting
	{
		public double Temperature { set; get; }
		/// <summary>
		/// Влажность дутья
		/// </summary>
		public double Dampness { set; get; }
		public double OxygenPercent { set; get; }
		public double Consumption { set; get; }
		public double Methane
		{
			set
			{
				if (100 - Ethane - CarbonDioxide >= value)
					Methane = value;
			}
			get => Methane;
		}
		public double Ethane
		{
			set
			{
				if (100 - Methane - CarbonDioxide >= value)
					Ethane = value;
			}
			get => Ethane;
		}
		public double CarbonDioxide
		{
			set
			{
				if (100 - Methane - Ethane >= value)
					CarbonDioxide = value;
			}
			get => CarbonDioxide;
		}
		/// <summary>
		/// Содержание С в природном газе
		/// </summary>
		public double Carbon
		{
			set { Carbon = value; }
			get
			{
				return (Methane + 2 * Ethane) / 100;
			}
		}
		/// <summary>
		/// Содержание  Н2 в природном газе
		/// </summary>
		public double Hydrogen
		{
			set
			{
				Hydrogen = value;
			}
			get
			{
				return (2 * Methane + 3 * Ethane) / 100;
			}
		}
		/// <summary>
		/// Расход сухого дутья для сжигания 1 кг углерода кокса
		/// </summary>
		double AB_toCokeBurning => 0.9333 / (0.01*OxygenPercent+0.00062*Dampness);
		/// <summary>
		/// Расход дутья для сжигания природного газа в фурменном очаге
		/// </summary>
		double AB_toNaturalGasBurning => 0.5 / (0.01 * OxygenPercent + 0.00063 * Dampness);
		double O2orN2_HeatCapacity => 1.2897 + 0.000121 * Temperature;
		double H2O_HeatCapacity => 1.456 + 0.000282 * Temperature;
	}
}

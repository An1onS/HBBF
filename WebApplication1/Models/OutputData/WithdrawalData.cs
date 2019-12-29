namespace HBBF.Models
{
	public class WithdrawalData
	{		
		/// <summary>
		/// 1. Расход тепла на прямое восстановление оксидов железа
		/// </summary>
		public double FeReduction { set; get; }
		public double FeReductionPercent { set; get; }
		/// <summary>
		/// 2. Расход тепла на прямое восстановление примесей чугуна
		/// </summary>
		public double ResidualsReduction { set; get; }
		public double ResidualsReductionPercent { set; get; }
		/// <summary>
		/// 3. Расход тепла на процесс десульфурации чугуна
		/// </summary>
		public double Desulfuration { set; get; }
		public double DesulfurationPercent { set; get; }
		/// <summary>
		/// 4. Расход тепла на восстановление оксидов железа водородом
		/// </summary>
		public double FeHydrogenicReduction { set; get; }
		public double FeHydrogenicReductionPercent { set; get; }
		/// <summary>
		/// 5. Расход тепла на нагрев жидкого чугуна
		/// </summary>
		public double MoltenIronHeating { set; get; }
		public double MoltenIronHeatingPercent { set; get; }
		/// <summary>
		/// 6. Расход тепла на нагрев жидкого шлака
		/// </summary>
		public double SlagHeating { set; get; }
		public double SlagHeatingPercent { set; get; }
		/// <summary>
		/// 7. Расход тепла на разложение влаги дутья
		/// </summary>
		public double AirDegrading { set; get; }
		public double AirDegradingPercent { set; get; }
		/// <summary>
		/// 8. Расход тепла на разложение известняка
		/// </summary>
		public double LimestoneDegrading { set; get; }
		public double LimestoneDegradingPercent { set; get; }
		/// <summary>
		/// 9. Расход тепла на разложение влаги шихты
		/// </summary>
		public double StockDegrading { set; get; }
		public double StockDegradingPercent { set; get; }
		public double CO { set; get; }
		public double CO2 { set; get; }
		public double H2 { set; get; }
		public double H2O { set; get; }
		public double N2 { set; get; }
		/// <summary>
		/// 10. Расход тепла, уносимого колошниковым газом
		/// </summary>
		public double TopGas { set; get; }
		public double TopGasPercent { set; get; }
		/// <summary>
		/// 11. Тепловые потери доменной печи
		/// </summary>
		public double Losses { set; get; }
		public double LossesPercent { set; get; }
		/// <summary>
		/// Сумма расходных статей теплового баланса
		/// </summary>
		public double Sum { set; get; }
		public double SumPercent { set; get; }
	}
}

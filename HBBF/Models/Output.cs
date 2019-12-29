using OfficeOpenXml;

using System;
using System.IO;

namespace HBBF.Models
{
	public class Output
	{
		public Output(FileInfo file)
		{
			Income = new IncomeData();
			Withdrawal = new WithdrawalData();
			Influence = new InfluenceData();
			LoadFromExcel(file);
		}
		void LoadFromExcel(FileInfo file)
		{
			using (var package = new ExcelPackage(file))
			{
				package.Workbook.Calculate();
				var cells = package.Workbook.Worksheets["Тепловой баланс"].Cells;
				for (var row = 4; row < 17; row++)
					typeof(IncomeData).GetProperties()[row - 4].SetValue(Income, Math.Round((double)cells[row, 3].Value, 3));
				for (var row = 19; row < 48; row++)
					typeof(WithdrawalData).GetProperties()[row - 19].SetValue(Withdrawal, Math.Round((double)cells[row, 3].Value, 3));
				Influence.Q = Math.Round((double)cells[50, 3].Value, 3);
				Influence.QtoC = Math.Round((double)cells[51, 3].Value, 3);
				Influence.CokeC = Math.Round((double)cells[52, 3].Value, 3);
				Influence.Rd = (Math.Round((double)cells[55, 3].Value, 3), Math.Round((double)cells[56, 3].Value, 3));
				Influence.Limestone = (Math.Round((double)cells[59, 3].Value, 3), Math.Round((double)cells[60, 3].Value, 3), Math.Round((double)cells[61, 3].Value, 3));
				Influence.AirBlasting = (Math.Round((double)cells[64, 3].Value, 3), Math.Round((double)cells[65, 3].Value, 3));
				Influence.Combined = (Math.Round((double)cells[68, 3].Value, 3), Math.Round((double)cells[69, 3].Value, 3));
				Influence.Dampness = (Math.Round((double)cells[72, 3].Value, 3), Math.Round((double)cells[73, 3].Value, 3));
				Influence.SlagProduction = (Math.Round((double)cells[76, 3].Value, 3), Math.Round((double)cells[77, 3].Value, 3));
				Influence.HeatLosses = (Math.Round((double)cells[80, 3].Value, 3), Math.Round((double)cells[81, 3].Value, 3));
			}
		}
		/// <summary>
		/// Приходная часть теплового баланса
		/// </summary>
		public IncomeData Income { set; get; }
		/// <summary>
		/// Расходная часть теплового баланса
		/// </summary>
		public WithdrawalData Withdrawal { set; get; }
		/// <summary>
		/// Влияние различных факторов на статьи ТБ и удельный расход кокса
		/// </summary>
		public InfluenceData Influence { set; get; }
	}
}

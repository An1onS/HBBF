using OfficeOpenXml;
using System.IO;

namespace HBDP.Models
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
				var cells = package.Workbook.Worksheets["Тепловой баланс"].Cells;
				for (var row = 4; row < 17; row++)
					typeof(IncomeData).GetProperties()[row - 4].SetValue(Income, (double)cells[row, 3].Value);
				for (var row = 19; row < 48; row++)
					typeof(WithdrawalData).GetProperties()[row - 19].SetValue(Withdrawal, (double)cells[row, 3].Value);
				Influence.Q = (double)cells[50, 3].Value;
				Influence.QtoC = (double)cells[51, 3].Value;
				Influence.CokeC = (double)cells[52, 3].Value;
				Influence.Rd = ((double)cells[55,3].Value, (double)cells[56, 3].Value);
				Influence.Limestone = ((double)cells[59, 3].Value, (double)cells[60, 3].Value, (double)cells[61, 3].Value);
				Influence.AirBlasting = ((double)cells[64, 3].Value, (double)cells[65, 3].Value);
				Influence.Combined = ((double)cells[68, 3].Value, (double)cells[69, 3].Value);
				Influence.Dampness = ((double)cells[72, 3].Value, (double)cells[73, 3].Value);
				Influence.SlagProduction = ((double)cells[76, 3].Value, (double)cells[77, 3].Value);
				Influence.HeatLosses = ((double)cells[80, 3].Value, (double)cells[81, 3].Value);
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

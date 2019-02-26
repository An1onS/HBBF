using OfficeOpenXml;
using System.IO;

namespace HBDP.Models
{
	public class Input
	{
		public Input(FileInfo file)
		{
			Regime = new RegimeData();
			PigIron = new PigIronData();
			Coke = new CokeData();
			AirBlasting = new AirBlastingData();
			Limestone = new LimestoneData();
			TopGas = new TopGasData();
			LoadFromExcel(file);
		}
		void LoadFromExcel(FileInfo file)
		{
			using (var package = new ExcelPackage(file))
			{
				var cells = package.Workbook.Worksheets["Исходные данные"].Cells;
				for (var row = 5; row < 15; row++)
				{
					PigIron.GetType().GetProperties()[row - 5].SetValue(PigIron, (double)cells[row, 3].Value);
				}
			}
		}
		public void WriteToExcel(FileInfo file)
		{
			using (var package = new ExcelPackage(file))
			{
				var cells = package.Workbook.Worksheets["Исходные данные"].Cells;
				for (var row = 5; row < 15; row++)
				{
					cells[row, 3].Value = PigIron.GetType().GetProperties()[row - 5].GetValue(PigIron);
				}
			}
		}
		public RegimeData Regime { set; get; }
		public PigIronData PigIron { set; get; }
		public CokeData Coke { set; get; }
		public AirBlastingData AirBlasting { set; get; }
		public LimestoneData Limestone { set; get; }
		public TopGasData TopGas { set; get; }
	}
}

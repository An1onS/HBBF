using OfficeOpenXml;
using System.IO;

namespace HBDP.Models
{
	public class Input
	{
		public Input()
		{
			Regime = new RegimeData();
			PigIron = new PigIronData();
			Coke = new CokeData();
			AirBlasting = new AirBlastingData();
			Limestone = new LimestoneData();
			Slag = new SlagData();
			TopGas = new TopGasData();
			IronOreMaterials = new IronOreMaterialsData();
		}
		public Input(FileInfo file) : this()
		{
			LoadFromExcel(file);
		}
		/// <summary>
		/// Чтение данных из Excel
		/// </summary>
		/// <param name="file"></param>
		void LoadFromExcel(FileInfo file)
		{
			using (var package = new ExcelPackage(file))
			{
				var cells = package.Workbook.Worksheets["Исходные данные"].Cells;
				// Циклы по диапазонам ячеек в xlsx
				for (var row = 5; row < 15; row++)
					typeof(PigIronData).GetProperties()[row - 5].SetValue(PigIron, (double)cells[row, 3].Value);
				Regime.StraightReduction = (double)cells[16, 3].Value;
				for (var row = 18; row < 23; row++)
					typeof(CokeData).GetProperties()[row - 18].SetValue(Coke, (double)cells[row, 3].Value);
				for (var row = 24; row < 33; row++)
					typeof(AirBlastingData).GetProperties()[row - 24].SetValue(AirBlasting, (double)cells[row, 3].Value);
				for (var row = 34; row < 37; row++)
					typeof(LimestoneData).GetProperties()[row - 34].SetValue(Limestone, (double)cells[row, 3].Value);
				for (var row = 38; row < 41; row++)
					typeof(SlagData).GetProperties()[row - 38].SetValue(Slag, (double)cells[row, 3].Value);
				for (var row = 42; row < 47; row++)
					typeof(TopGasData).GetProperties()[row - 42].SetValue(TopGas, (double)cells[row, 3].Value);
				for (var row = 48; row < 51; row++)
					typeof(IronOreMaterialsData).GetProperties()[row - 48].SetValue(IronOreMaterials, (double)cells[row, 3].Value);
			}
		}
		/// <summary>
		/// Сохранение данных в Excel
		/// </summary>
		/// <param name="file"></param>
		public void WriteToExcel(FileInfo file)
		{
			using (var package = new ExcelPackage(file))
			{
				var cells = package.Workbook.Worksheets["Исходные данные"].Cells;
				for (var row = 5; row < 15; row++)
					cells[row, 3].Value = typeof(PigIronData).GetProperties()[row - 5].GetValue(PigIron);
				for (var row = 18; row < 23; row++)
					cells[row, 3].Value = typeof(CokeData).GetProperties()[row - 18].GetValue(Coke);
				for (var row = 24; row < 33; row++)
					cells[row, 3].Value = typeof(AirBlastingData).GetProperties()[row - 24].GetValue(AirBlasting);
				for (var row = 34; row < 37; row++)
					cells[row, 3].Value = typeof(LimestoneData).GetProperties()[row - 34].GetValue(Limestone);
				for (var row = 38; row < 41; row++)
					cells[row, 3].Value = typeof(SlagData).GetProperties()[row - 38].GetValue(Slag);
				for (var row = 42; row < 47; row++)
					cells[row, 3].Value = typeof(TopGasData).GetProperties()[row - 42].GetValue(TopGas);
				for (var row = 48; row < 51; row++)
					typeof(IronOreMaterialsData).GetProperties()[row - 48].GetValue(IronOreMaterials);
				// собственно, сохранение. Без этого using закрывает поток без изменений
				package.Save();
			}
		}
		public RegimeData Regime { set; get; }
		public PigIronData PigIron { set; get; }
		public CokeData Coke { set; get; }
		public AirBlastingData AirBlasting { set; get; }
		public LimestoneData Limestone { set; get; }
		public SlagData Slag { set; get; }
		public TopGasData TopGas { set; get; }
		public IronOreMaterialsData IronOreMaterials { set; get; }
	}
}

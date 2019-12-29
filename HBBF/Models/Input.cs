using OfficeOpenXml;

using System.IO;

namespace HBBF.Models
{
	public class Input
	{
		public Input()
		{
			Regime = new RegimeData();
			MoltenIron = new MoltenIronData();
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
		/// <param name="file">Путь к файлу c методикой расчёта</param>
		void LoadFromExcel(FileInfo file)
		{
			using (var package = new ExcelPackage(file))
			{
				var cells = package.Workbook.Worksheets["Исходные данные"].Cells;
				// Циклы по диапазонам ячеек в xlsx
				for (var row = 5; row < 15; row++)
					typeof(MoltenIronData).GetProperties()[row - 5].SetValue(MoltenIron, (double)cells[row, 3].Value);
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
		/// <param name="file">Путь к файлу c методикой расчёта</param>
		public void WriteToExcel(FileInfo file)
		{
			using (var package = new ExcelPackage(file))
			{
				var cells = package.Workbook.Worksheets["Исходные данные"].Cells;
				for (var row = 5; row < 15; row++)
					cells[row, 3].Value = typeof(MoltenIronData).GetProperties()[row - 5].GetValue(MoltenIron);
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
		/// <summary>
		/// Режим плавки
		/// </summary>
		public RegimeData Regime { set; get; }
		/// <summary>
		/// Чугун
		/// </summary>
		public MoltenIronData MoltenIron { set; get; }
		/// <summary>
		/// Кокс
		/// </summary>
		public CokeData Coke { set; get; }
		/// <summary>
		/// Дутье
		/// </summary>
		public AirBlastingData AirBlasting { set; get; }
		/// <summary>
		/// Известняк
		/// </summary>
		public LimestoneData Limestone { set; get; }
		/// <summary>
		/// Шлак
		/// </summary>
		public SlagData Slag { set; get; }
		/// <summary>
		/// Доменный газ
		/// </summary>
		public TopGasData TopGas { set; get; }
		/// <summary>
		/// Железнорудные материалы
		/// </summary>
		public IronOreMaterialsData IronOreMaterials { set; get; }
	}
}

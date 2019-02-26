using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using HBDP.Models;
using OfficeOpenXml;
using System.IO;

namespace HBDP.Controllers
{
	[Produces("application/json")]
	public class HomeController : Controller
	{
		readonly IHostingEnvironment hostingEnvironment;
		public HomeController(IHostingEnvironment hostingEnvironment)
		{
			this.hostingEnvironment = hostingEnvironment;
		}

		public IActionResult Index()
		{
			var root = hostingEnvironment.WebRootPath;
			var fileName = "Тепловой баланс доменной печи.xlsx";
			var fileinfo = new FileInfo(Path.Combine(root, fileName));
			Input input = new Input(fileinfo);
			//using (var package = new ExcelPackage(fileinfo))
			//{
			//	// Соболезную человеку, который попытается что-то здесь изменить
			//	var worksheet = package.Workbook.Worksheets["Исходные данные"];
			//	input = new Input()
			//	{
			//		Si = Convert.ToDouble(worksheet.Cells[5, 3].Value),
			//		Mn = Convert.ToDouble(worksheet.Cells[6, 3].Value),
			//		S = Convert.ToDouble(worksheet.Cells[7, 3].Value),
			//		P = Convert.ToDouble(worksheet.Cells[8, 3].Value),
			//		Ti = Convert.ToDouble(worksheet.Cells[9, 3].Value),
			//		Cr = Convert.ToDouble(worksheet.Cells[10, 3].Value),
			//		V = Convert.ToDouble(worksheet.Cells[11, 3].Value),
			//		C = Convert.ToDouble(worksheet.Cells[12, 3].Value),
			//		PigIron_Temperature = Convert.ToDouble(worksheet.Cells[13, 3].Value),
			//		PigIron_HeatCapacity = Convert.ToDouble(worksheet.Cells[14, 3].Value),
			//	};
			//	//чтобы не писать руками строку в индексе ячейки:
			//	var r = 16; var c = 3;
			//	input.StraightReduction = Convert.ToDouble(worksheet.Cells[r, c].Value); r += 2;
			//	input.Coke_Consumption = Convert.ToDouble(worksheet.Cells[r, c].Value); r ++;
			//	input.Coke_Ash = Convert.ToDouble(worksheet.Cells[r, c].Value); r++; //19 -> 20
			//	input.Sulfur = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.Volatiles = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.Dampness = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
			//	// r= 24
			//	input.AirBlastingTemperature = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.AirBlastingDampness = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.OxygenPercent = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.AirBlastingConsumption = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.Methane = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.Ethane = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.CarbonDioxide = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.Carbon = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.Hydrogen = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
			//	// r34 ;)
			//	input.LimestoneConsumption = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.LimestoneDampness = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.MassLose = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
			//	// r = 38
			//	input.Ratio = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.SlagSulfur = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.SlagHeatCapacity = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
			//	// r = 42
			//	input.TopGasTemperature = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.CO2 = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.CO = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.H2 = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.N2 = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
			//	// r= 48
			//	input.Consumption_IronMaterial = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.Consumption_IronAddings = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//	input.IOMDampness = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			//}
				
			return View(input);
		}
		//public JsonResult Serialize(Input input)
		//{
		//	return Json(input);
		//}
		
		public IActionResult Output(Input input)
		{
			var root = hostingEnvironment.WebRootPath;
			var fileName = "Тепловой баланс доменной печи.xlsx";
			var fileinfo = new FileInfo(Path.Combine(root, fileName));
			using (var package = new ExcelPackage(fileinfo))
			{
				var worksheet = package.Workbook.Worksheets["Исходные данные"];
				// цикл - перебор и заполнение строк в .xlsx
				var pigIronData = new double[10]
				{
					input.Si,
					input.Mn,
					input.S,
					input.P,
					input.Ti,
					input.Cr,
					input.V,
					input.C,
					input.PigIron_Temperature,
					input.C
				};
				for (var row = 5; row < 15; row++)
					worksheet.Cells[row, 3].Value = pigIronData[row - 5];
				worksheet.Cells[16, 3].Value = input.StraightReduction;
				var cokeData = new double[5]
				{
					input.Coke_Consumption,
					input.Coke_Ash,
					input.Sulfur,
					input.Volatiles,
					input.Dampness
				}; //Характеристики кокса
				for (var row = 18; row <23; row++)
					worksheet.Cells[row, 3].Value = cokeData[row - 18];
				var airBlastingData = new double[9]
				{
					input.PigIron_Temperature,
					input.AirBlastingDampness,
					input.OxygenPercent,
					input.AirBlastingConsumption,
					input.Methane,
					input.Ethane,
					input.CarbonDioxide,
					input.Carbon,
					input.Hydrogen
				};
				for (var row = 24; row < 33; row++)
					worksheet.Cells[row, 3].Value = airBlastingData[row - 24];
				worksheet.Cells[34, 3].Value = input.LimestoneConsumption;
				worksheet.Cells[35, 3].Value = input.LimestoneDampness;
				worksheet.Cells[36, 3].Value = input.MassLose;
				var r = 38;
				worksheet.Cells[r, 3].Value = input.Ratio; r++;
				worksheet.Cells[r, 3].Value = input.SlagSulfur; r++;
				worksheet.Cells[r, 3].Value = input.SlagHeatCapacity;
				var topGasData = new double[5]
				{
					input.TopGasTemperature,
					input.CO2,
					input.CO,
					input.H2,
					input.N2
				};
				for (var row = 42; row < 47; row++)
					worksheet.Cells[row, 3].Value = topGasData[row - 42];
				r = 48;
				worksheet.Cells[r, 3].Value = input.Consumption_IronMaterial; r++;
				worksheet.Cells[r, 3].Value = input.Consumption_IronAddings; r++;
				worksheet.Cells[r, 3].Value = input.IOMDampness; r++;
			}
			var output = new Output();
			return View(output);
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

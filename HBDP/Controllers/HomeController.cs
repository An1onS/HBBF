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
			Input input;
			using (var package = new ExcelPackage(fileinfo))
			{
				// Соболезную человеку, который попытается что-то здесь изменить
				var worksheet = package.Workbook.Worksheets["Исходные данные"];
				input = new Input()
				{
					Si = Convert.ToDouble(worksheet.Cells[5, 3].Value),
					Mn = Convert.ToDouble(worksheet.Cells[6, 3].Value),
					S = Convert.ToDouble(worksheet.Cells[7, 3].Value),
					P = Convert.ToDouble(worksheet.Cells[8, 3].Value),
					Ti = Convert.ToDouble(worksheet.Cells[9, 3].Value),
					Cr = Convert.ToDouble(worksheet.Cells[10, 3].Value),
					V = Convert.ToDouble(worksheet.Cells[11, 3].Value),
					C = Convert.ToDouble(worksheet.Cells[12, 3].Value),
					Temperature = Convert.ToDouble(worksheet.Cells[13, 3].Value),
					HeatCapacity = Convert.ToDouble(worksheet.Cells[14, 3].Value),
				};
				//чтобы не писать руками строку в индексе ячейки:
				var r = 16; var c = 3;
				input.StraightReduction = Convert.ToDouble(worksheet.Cells[r, c].Value); r += 2;
				input.Consumption = Convert.ToDouble(worksheet.Cells[r, c].Value); r ++;
				input.Ash = Convert.ToDouble(worksheet.Cells[r, c].Value); r++; //19 -> 20
				input.Sulfur = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.Volatiles = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.Dampness = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
				// r= 24
				input.AirBlastingTemperature = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.AirBlastingDampness = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.OxygenPercent = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.AirBlastingConsumption = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.Methane = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.Ethane = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.CarbonDioxide = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.Carbon = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.Hydrogen = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
				// r34 ;)
				input.LimestoneConsumption = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.LimestoneDampness = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.MassLose = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
				// r = 38
				input.Ratio = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.SlagSulfur = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.SlagHeatCapacity = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
				// r = 42
				input.TopGasTemperature = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.CO2 = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.CO = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.H2 = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.N2 = Convert.ToDouble(worksheet.Cells[r, c].Value); r+=2;
				// r= 48
				input.Consumption_IronMaterial = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.Consumption_IronAddings = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
				input.IOMDampness = Convert.ToDouble(worksheet.Cells[r, c].Value); r++;
			}
				
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
					input.Temperature,
					input.C
				};
				for (var row = 5; row < 15; row++)
					worksheet.Cells[row, 2].Value = pigIronData[row - 5];
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

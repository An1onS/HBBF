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
		private const string fileName = "Тепловой баланс доменной печи.xlsx";
		readonly string root;
		public HomeController(IHostingEnvironment hostingEnvironment)
		{
			root = hostingEnvironment.WebRootPath;
		}

		public IActionResult Index()
		{
			var fileinfo = new FileInfo(Path.Combine(root, fileName));
			Input input = new Input(fileinfo);
			return View(input);
		}
		

		public IActionResult Output()
		{
			var fileinfo = new FileInfo(Path.Combine(root, fileName));
			var output = new Output(fileinfo);
			return View(output);
		}
		public JsonResult JsonIncome()
		{
			var fileinfo = new FileInfo(Path.Combine(root, fileName));
			var output = new Output(fileinfo);
			var income = new object[]
			{
				new object[]{ "Статья прихода","Процент" },
				new object[]{ "Горение кокса",output.Income.CokeHeatPercent},
				new object[]{ "Дутьё",output.Income.AirHeatPercent},
				new object[]{ "Конверсия газа",output.Income.GasHeatPercent},
				new object[]{ "Шлакообразование", output.Income.SlagHeatPercent}
			};
			return Json(income);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

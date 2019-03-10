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
		public JsonResult JsonWi()
		{
			var fileinfo = new FileInfo(Path.Combine(root, fileName));
			var output = new Output(fileinfo).Withdrawal;
			var withdrawal = new object[]
			{
				new object[]{ "Статья расхода","Процент" },
				new object[]{ "Восстановление железа",output.FeReductionPercent},
				new object[]{ "Тепловые потери",output.LossesPercent},
				new object[]{ "Нагрев чугуна",output.PigIronHeatingPercent},
				new object[]{ "Нагрев шлака", output.SlagHeatingPercent},
				new object[]{ "Унос с колошниковым газом", output.TopGasPercent},
				new object[]{ "Прочие", output.SumPercent-output.FeReductionPercent
				-output.LossesPercent-output.PigIronHeatingPercent
				-output.SlagHeatingPercent-output.TopGasPercent}
			};
			return Json(withdrawal);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

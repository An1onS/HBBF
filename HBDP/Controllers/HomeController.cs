﻿using System.Diagnostics;
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
        /// <summary>
        /// Имя и путь к файлу Excel с расчётными формулами
        /// </summary>
        FileInfo fileinfo;
		public HomeController(IHostingEnvironment hostingEnvironment)
		{
			var root = hostingEnvironment.WebRootPath;
            fileinfo = new FileInfo(Path.Combine(root, fileName));
		}
        /// <summary>
        /// Главная страница Index, ввод данных
        /// </summary>
        /// <returns></returns>
		public IActionResult Input()
		{
			Input input = new Input(fileinfo);
			return View(input);
		}
        /// <summary>
        /// Вывод страницы с результатами расчёта
        /// </summary>
        /// <param name="input">Объект, заполненный в форме на странице Input</param>
        /// <returns></returns>
        [HttpPost]
		public IActionResult Output(Input input)
		{
            input.WriteToExcel(fileinfo);
			var output = new Output(fileinfo);
			return View(output);
		}
		public IActionResult DownloadXLSX()
		{
			var ms = new MemoryStream();
			using (var package = new ExcelPackage(fileinfo))
			{
				package.SaveAs(ms);
			}
			return File(ms.ToArray(), "application/ooxml", "Тепловой баланс.xlsx");
		}
        /// <summary>
        /// Конвертирует данные для графика прихода в JSON
        /// </summary>
        /// <returns></returns>
		public JsonResult JsonIncome()
		{
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
        /// <summary>
        /// Конвертирует данные для р=графика расхода в JSON
        /// </summary>
        /// <returns></returns>
		public JsonResult JsonWi()
		{
			var output = new Output(fileinfo).Withdrawal;
			var withdrawal = new object[]
			{
				new object[]{ "Статья расхода","Процент" },
				new object[]{ "Восстановление железа",output.FeReductionPercent},
				new object[]{ "Тепловые потери",output.LossesPercent},
				new object[]{ "Нагрев чугуна",output.MoltenIronHeatingPercent},
				new object[]{ "Нагрев шлака", output.SlagHeatingPercent},
				new object[]{ "Унос с колошниковым газом", output.TopGasPercent},
				new object[]{ "Прочие", output.SumPercent-output.FeReductionPercent
				-output.LossesPercent-output.MoltenIronHeatingPercent
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

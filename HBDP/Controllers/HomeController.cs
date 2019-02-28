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
			return View(input);
		}
		

		public IActionResult Output()
		{
			var root = hostingEnvironment.WebRootPath;
			var fileName = "Тепловой баланс доменной печи.xlsx";
			var fileinfo = new FileInfo(Path.Combine(root, fileName));
			var output = new Output(fileinfo);
			return View(output);
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

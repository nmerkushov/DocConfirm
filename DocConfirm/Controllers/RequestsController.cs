using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinqToDB;
using DocConfirm.Linq2DBContext;
using DocConfirm.Models;
using DocConfirm.Services;

namespace DocConfirm.Controllers
{
	[Route("requests")]
	public class RequestsController : Controller
	{
		private readonly IRequestService _requestService;

		public RequestsController(IRequestService requestService)
		{
			_requestService = requestService;
		}

		[Route(""), HttpGet]
		public async Task<IActionResult> GetRequests(string query = null, int? offset = null, int? limit = null, string filter = null)
		{
			return new JsonResult(await _requestService.GetRequests(query,offset,limit,filter));
		}

		[Route("{req_id}"), HttpGet]
		public async Task<IActionResult> GetRequest(string req_id)
		{
			return new JsonResult(await _requestService.GetRequest(req_id));
		}

		[Route(""), HttpPost]
		public async Task<IActionResult> AddRequest(DocConfirmRequest docConfirmRequest)
		{
			await _requestService.AddRequest(docConfirmRequest);
			return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}", "Запрос успешно создан");
		}

		[Route("{req_id}/resolution"), HttpPut]
		public async Task<IActionResult> SetResolution(string req_id, DocConfirmRequest docConfirmRequest)
		{
			if (await _requestService.SetResolution(req_id, docConfirmRequest))
			{
				return new OkResult();
			}
			else
			{
				return new NotFoundResult();
			}
		}
	}
}
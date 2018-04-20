using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LinqToDB;
using DocConfirm.Linq2DBContext;
using DocConfirm.Models;

namespace DocConfirm.Controllers
{
	[Route("requests")]
	public class RequestsController : Controller
	{
		[Route(""), HttpGet]
		public IActionResult GetRequests(string query = null, int? offset = null, int? limit = null, string filter = null)
		{
			using (var db = new DocConfirmDB())
			{
				var rqsts = from r in db.Requests
							select r;
				if (offset != null)
				{
					rqsts = rqsts.Skip(offset ?? 0);
				}
				if (limit != null)
				{
					rqsts = rqsts.Take(limit ?? 0);
				}

				return new JsonResult(rqsts.ToList());
			}
		}

		[Route("{req_id}"), HttpGet]
		public IActionResult GetRequest(string req_id)
		{
			using (var db = new DocConfirmDB())
			{
				Request rqst = (from r in db.Requests
							where r.Req_ID == req_id
							select r)
							.FirstOrDefault();


				return new JsonResult(rqst);
			}
		}

		[Route(""), HttpPost]
		public IActionResult AddRequest(DocConfirmRequest docConfirmRequest)
		{
			using (var db = new DocConfirmDB())
			{
				Request rq = new Request
				{
					Req_ID = docConfirmRequest.ID,
					ExternalID = docConfirmRequest.ExternalID,
					Source = docConfirmRequest.Source,
					NotaryID = docConfirmRequest.NotaryID,
					DocDate = docConfirmRequest.DocDate,
					DocNum = docConfirmRequest.DocNum,
					DocBody = docConfirmRequest.DocBody,
					ResolutionValue = docConfirmRequest.ResolutionValue
				};
				db.InsertAsync(rq);
				return Created($"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}", "Запрос успешно создан");
			}
		}

		[Route("{req_id}/resolution"), HttpPut]
		public IActionResult SetResolution(string req_id, DocConfirmRequest docConfirmRequest)
		{
			using (var db = new DocConfirmDB())
			{
				Request rqst = (from r in db.Requests
								where r.Req_ID == req_id
								select r)
							.FirstOrDefault();

				if (rqst!=null)
				{
					rqst.ExternalID = docConfirmRequest.ExternalID;
					rqst.Source = docConfirmRequest.Source;
					rqst.NotaryID = docConfirmRequest.NotaryID;
					rqst.DocDate = docConfirmRequest.DocDate;
					rqst.DocNum = docConfirmRequest.DocNum;
					rqst.DocBody = docConfirmRequest.DocBody;
					rqst.ResolutionValue = docConfirmRequest.ResolutionValue;
					db.Update(rqst);
					return new OkResult();
				}

				return new NotFoundResult();
			}

		}
	}
}
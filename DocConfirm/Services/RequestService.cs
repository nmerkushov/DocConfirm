using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinqToDB;
using DocConfirm.Linq2DBContext;
using DocConfirm.Models;

namespace DocConfirm.Services
{
	public interface IRequestService
	{
		Task<IEnumerable<Request>> GetRequests(string query = null, int? offset = null, int? limit = null, string filter = null);
		Task<Request> GetRequest(string req_id);
		Task AddRequest(DocConfirmRequest docConfirmRequest);
		Task<bool> SetResolution(string req_id, DocConfirmRequest docConfirmRequest);
	}

	public class RequestService : IRequestService
	{
		private readonly IDocConfirmDB _dbContext;

		public RequestService(IDocConfirmDB dbcontext)
		{
			_dbContext = dbcontext;
		}

		public async Task<IEnumerable<Request>> GetRequests(string query = null, int? offset = null, int? limit = null, string filter = null)
		{

			var rqsts = from r in _dbContext.Requests
						select r;
			if (offset != null)
			{
				rqsts = rqsts.Skip(offset ?? 0);
			}
			if (limit != null)
			{
				rqsts = rqsts.Take(limit ?? 0);
			}

			return await rqsts.ToListAsync();

		}

		public async Task<Request> GetRequest(string req_id)
		{

			return await (from r in _dbContext.Requests
						  where r.Req_ID == req_id
						  select r).FirstOrDefaultAsync();

		}

		public async Task AddRequest(DocConfirmRequest docConfirmRequest)
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
			await _dbContext.InsertAsync(rq);

		}

		public async Task<bool> SetResolution(string req_id, DocConfirmRequest docConfirmRequest)
		{

			Request rqst = await (from r in _dbContext.Requests
								  where r.Req_ID == req_id
								  select r).FirstOrDefaultAsync();
			if (rqst != null)
			{
				rqst.ExternalID = docConfirmRequest.ExternalID;
				rqst.Source = docConfirmRequest.Source;
				rqst.NotaryID = docConfirmRequest.NotaryID;
				rqst.DocDate = docConfirmRequest.DocDate;
				rqst.DocNum = docConfirmRequest.DocNum;
				rqst.DocBody = docConfirmRequest.DocBody;
				rqst.ResolutionValue = docConfirmRequest.ResolutionValue;
				await _dbContext.UpdateAsync(rqst);
				return true;
			}
			return false;
		}
	}
}

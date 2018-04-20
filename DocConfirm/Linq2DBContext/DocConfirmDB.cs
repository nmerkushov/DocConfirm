using LinqToDB;
using LinqToDB.Data;
using DocConfirm.Models;

namespace DocConfirm.Linq2DBContext
{
	public class DocConfirmDB : DataConnection
	{
		public DocConfirmDB() : base("DocConfirm") { }

		public ITable<Request> Requests => GetTable<Request>();
	}
}

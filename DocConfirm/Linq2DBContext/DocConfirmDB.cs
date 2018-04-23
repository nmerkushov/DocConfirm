using LinqToDB;
using LinqToDB.Data;
using DocConfirm.Models;

namespace DocConfirm.Linq2DBContext
{	
	public interface IDocConfirmDB : IDataContext
	{
		ITable<Request> Requests { get; }
	}

	public class DocConfirmDB : DataConnection, IDocConfirmDB
	{
		public DocConfirmDB() : base("DocConfirm") { }

		public ITable<Request> Requests => GetTable<Request>();
	}
}

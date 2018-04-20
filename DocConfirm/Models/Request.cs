using System;
using LinqToDB.Mapping;

namespace DocConfirm.Models
{
	[Table(Name = "Request")]
	public class Request
	{
		[Column(Name = "RequestID", SkipOnInsert = true), PrimaryKey, Identity]
		public int RequestID { get; set; }

		[Column(Name = "Req_ID")]
		public string Req_ID { get; set; }

		[Column(Name = "NotaryID")]
		public string NotaryID { get; set; }

		[Column(Name = "DocNum")]
		public string DocNum { get; set; }

		[Column(Name = "DocDate")]
		public DateTime DocDate { get; set; }

		[Column(Name = "DocBody")]
		public byte[] DocBody { get; set; }

		[Column(Name = "Source")]
		public string Source { get; set; }

		[Column(Name = "ExternalID")]
		public string ExternalID { get; set; }

		[Column(Name = "ResolutionValue")]
		public bool ResolutionValue { get; set; }

		[Column(Name = "ResolutionText")]
		public string ResolutionText { get; set; }

		[Column(Name = "ResolutionTextSign")]
		public string ResolutionTextSign { get; set; }

		[Column(Name = "ResolutionDateTime")]
		public DateTime ResolutionDateTime { get; set; }
	}
}

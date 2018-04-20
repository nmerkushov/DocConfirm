using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocConfirm.Models
{
    public class DocConfirmRequest
    {
		public string ID { get; set; }
		public string ExternalID { get; set; }
		public string Source { get; set; }
		public string NotaryID { get; set; }
		public DateTime DocDate { get; set; }
		public string DocNum { get; set; }
		public byte[] DocBody { get; set; }
		public bool ResolutionValue { get; set; }
	}
}

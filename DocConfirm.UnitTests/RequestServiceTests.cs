using System;
using System.Collections.Generic;
using Xunit;
using NSubstitute;
using LinqToDB;
using DocConfirm.Models;
using DocConfirm.Services;
using DocConfirm.Linq2DBContext;

namespace DocConfirm.UnitTests
{
	public class RequsetServiceTests
	{
		[Fact]
		public async void Test1()
		{
			RequestService requestService = new RequestService(FakeDbContext());

			var rlist = await requestService.GetRequests();
			var r3 = await requestService.GetRequest("RID3");

		}

		public IDocConfirmDB FakeDbContext()
		{
			var FakeDB = Substitute.For<IDocConfirmDB>();
			List<Request> fakeRequests = new List<Request>()
			{
				new Request{ RequestID=1,Req_ID="RID1",NotaryID="NT1",DocDate=new DateTime(2018,4,25),DocNum="DN1",Source="Src1",ExternalID="ExID1",ResolutionValue=true},
				new Request{ RequestID=2,Req_ID="RID2",NotaryID="NT2",DocDate=new DateTime(2018,4,26),DocNum="DN2",Source="Src2",ExternalID="ExID2",ResolutionValue=false},
				new Request{ RequestID=3,Req_ID="RID3",NotaryID="NT3",DocDate=new DateTime(2018,4,27),DocNum="DN3",Source="Src3",ExternalID="ExID3",ResolutionValue=true},
				new Request{ RequestID=4,Req_ID="RID4",NotaryID="NT4",DocDate=new DateTime(2018,4,28),DocNum="DN4",Source="Src4",ExternalID="ExID4",ResolutionValue=false},
			};

			FakeDB.Requests.Returns(new MockTable<Request>(fakeRequests));
			return FakeDB;
		}
	} }
}

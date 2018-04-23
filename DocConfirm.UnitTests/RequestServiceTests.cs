using System;
using System.Collections.Generic;
using Xunit;
using NSubstitute;
using DocConfirm.Models;
using DocConfirm.Services;
using DocConfirm.Linq2DBContext;

namespace DocConfirm.UnitTests
{
	public class RequsetServiceTests
	{
		private static List<Request> fakeRequests = new List<Request>();

		[Fact]
		public async void SelectRequestTest()
		{
			fakeRequests = TestRequestList();
			var fakeDb = FakeDbContext();
			RequestService requestService = new RequestService(fakeDb);

			RequestComparer requestComparer = new RequestComparer();

			var rlist = await requestService.GetRequests();
			Assert.Equal(TestRequestList(), rlist, requestComparer);

			var r3 = await requestService.GetRequest("RID3");
			Assert.Equal(r3, new Request
			{
				RequestID = 3,
				Req_ID = "RID3",
				NotaryID = "NT3",
				DocDate = new DateTime(2018, 4, 27),
				DocNum = "DN3",
				Source = "Src3",
				ExternalID = "ExID3",
				ResolutionValue = true
			},
						requestComparer);

		}

		private IDocConfirmDB FakeDbContext()
		{
			var FakeDB = Substitute.For<IDocConfirmDB>();

			FakeDB.Requests.Returns(
				new MockTable<Request>(fakeRequests)
			);

			return FakeDB;
		}

		private List<Request> TestRequestList()
		{
			var testRequests = new List<Request>()
				{
					new Request{ RequestID=1,Req_ID="RID1",NotaryID="NT1",DocDate=new DateTime(2018,4,25),DocNum="DN1",Source="Src1",ExternalID="ExID1",ResolutionValue=true},
					new Request{ RequestID=2,Req_ID="RID2",NotaryID="NT2",DocDate=new DateTime(2018,4,26),DocNum="DN2",Source="Src2",ExternalID="ExID2",ResolutionValue=false},
					new Request{ RequestID=3,Req_ID="RID3",NotaryID="NT3",DocDate=new DateTime(2018,4,27),DocNum="DN3",Source="Src3",ExternalID="ExID3",ResolutionValue=true},
					new Request{ RequestID=4,Req_ID="RID4",NotaryID="NT4",DocDate=new DateTime(2018,4,28),DocNum="DN4",Source="Src4",ExternalID="ExID4",ResolutionValue=false},
				};
			return testRequests;
		}
	}


	public class RequestComparer : IEqualityComparer<Request>
	{
		public bool Equals(Request x, Request y)
		{
			return (x.Req_ID == y.Req_ID &&
				x.NotaryID == y.NotaryID &&
				x.DocNum == y.DocNum &&
				x.DocDate == y.DocDate &&
				x.DocBody == y.DocBody &&
				x.Source == y.Source &&
				x.ResolutionValue == y.ResolutionValue &&
				x.ResolutionText == y.ResolutionText &&
				x.ResolutionTextSign == y.ResolutionTextSign &&
				x.ResolutionDateTime == y.ResolutionDateTime);
		}

		public int GetHashCode(Request rq)
		{
			return rq.GetHashCode();
		}
	}
}

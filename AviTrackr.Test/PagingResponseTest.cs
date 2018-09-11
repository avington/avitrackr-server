using AviTrackr.Domain.Base.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AviTrackr.Test
{
    [TestClass]
    public class PagingResponseTest
    {
        [TestMethod]
        public void PagingResponse_when_skip_10_take_10()
        {
            var skip = 10;
            var take = 10;

            var sot = new PagingResponseService();

            var result = sot.SetPaging(skip, take, null);

            Assert.AreEqual(result.PreviousSkip, 0);
            Assert.AreEqual(result.NextSkip, 20);
        }

        [TestMethod]
        public void PagingResponse_when_skip_0_take_10()
        {
            var skip = 0;
            var take = 10;

            var sot = new PagingResponseService();

            var result = sot.SetPaging(skip, take, null);

            Assert.AreEqual(result.PreviousSkip, null);
            Assert.AreEqual(result.NextSkip, 10);
        }

        [TestMethod]
        public void PagingResponse_when_skip_20_take_10_total_25()
        {
            var skip = 20;
            var take = 10;
            var total = 25;

            var sot = new PagingResponseService();

            var result = sot.SetPaging(skip, take, total);

            Assert.AreEqual(result.PreviousSkip, 10);
            Assert.AreEqual(result.NextSkip, null);
        }
    }
}
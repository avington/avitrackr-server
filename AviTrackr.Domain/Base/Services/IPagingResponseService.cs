using AviTrackr.Domain.Base.Models;

namespace AviTrackr.Domain.Base.Services
{
    public interface IPagingResponseService
    {
        PagingResponseModel SetPaging(int? skip, int? take, int? total = null);
    }

    public class PagingResponseService : IPagingResponseService
    {
        public PagingResponseModel SetPaging(int? skip, int? take, int? total = null)
        {
            var result = new PagingResponseModel()
            {
                Take = take,
                Skip = skip
            };

            // set previous skip
            if ((skip - take) < 0)
            {
                result.PreviousSkip = null;
            }
            else
            {
                result.PreviousSkip = skip - take;
            }

            // set next skip
            if (total.HasValue && (skip + take) > total)
            {
                result.NextSkip = null;
            }
            else
            {
                result.NextSkip = skip + take;
            }


            return result;
        }
    }
}
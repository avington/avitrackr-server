using System.Collections.Generic;

namespace AviTrackr.Domain.Base.Models
{
    public class SummaryResponseModel<T> where T: class
    {
        public T Summary { get; set; }
        public PagingResponseModel PagingInfo { get; set; }
    }
}
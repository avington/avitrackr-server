namespace AviTrackr.Domain.Base.Models
{
    public class PagingRequestBase
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
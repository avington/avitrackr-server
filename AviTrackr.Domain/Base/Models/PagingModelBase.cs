namespace AviTrackr.Domain.Base.Models
{
    public class PagingModelBase
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
    }
}
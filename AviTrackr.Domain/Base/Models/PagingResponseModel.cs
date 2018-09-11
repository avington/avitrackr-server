namespace AviTrackr.Domain.Base.Models
{
    public class PagingResponseModel
    {
        public int? Skip { get; set; }
        public int? PreviousSkip { get; set; }
        public int? NextSkip { get; set; }
        public int? Take { get; set; }
        public int? Total { get; set; }
    }
}
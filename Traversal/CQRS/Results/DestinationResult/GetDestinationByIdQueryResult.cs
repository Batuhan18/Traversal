namespace Traversal.CQRS.Results.DestinationResult
{
    public class GetDestinationByIdQueryResult
    {
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
    }
}

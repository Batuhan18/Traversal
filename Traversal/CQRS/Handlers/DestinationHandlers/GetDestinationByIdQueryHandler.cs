using DataAccessLayer.Concrete;
using Traversal.CQRS.Queries.DestinationQueries;
using Traversal.CQRS.Results.DestinationResult;

namespace Traversal.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery getDestinationByIdQuery)
        {
            var values = _context.Destinations.Find(getDestinationByIdQuery.id);
            return new GetDestinationByIdQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.City,
                DayNight = values.DayNight,
                Price=(double)values.Price
            };
        }
    }
}

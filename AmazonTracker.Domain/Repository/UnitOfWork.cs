namespace AmazonTracker.Domain.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IReviewResultRepository ReviewResults { get; }

        public UnitOfWork(IReviewResultRepository reviewResultRespository)
        {
            ReviewResults = reviewResultRespository;
        }
    }
}

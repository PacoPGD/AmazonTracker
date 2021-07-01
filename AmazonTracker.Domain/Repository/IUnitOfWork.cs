namespace AmazonTracker.Domain.Repository
{
    public interface IUnitOfWork
    {
         IReviewResultRepository ReviewResults { get; }
    }
}

namespace EAuction.Core
{
    public interface IEvaluationMode
    {
        Bid Rate(Auction auction);
    }
}

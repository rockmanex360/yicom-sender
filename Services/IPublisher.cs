namespace Sender.Services
{
    public interface IPublisher
    {
        Task Publish(CancellationToken cancellationToken);
    }
}
using System.Threading.Tasks;

namespace Warsztaty.Messages.Events
{
    public interface IEventHandler<in T> where T : IEvent
    {
        Task HandleAsync(T command);
    }
}
using MediatR;

namespace CleanArchitecture.Application.Events
{
    public class CreateUserEvent : INotification
    {
        public string Name { get; set; }
    }
}

using Domain.Models.Animal;
using MediatR;

namespace Application.Queries.Users.GetAll
{
    public class GetAllUsersQuery : IRequest<List<AnimalModel>>
    {
        public GetAllUsersQuery(string userName)
        {
            UserName = userName;
        }
        public string UserName { get; set; }
    }
}

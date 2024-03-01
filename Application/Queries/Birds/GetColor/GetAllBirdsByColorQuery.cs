using Domain.Models;
using MediatR;

namespace Application.Queries.Birds.GetColor
{
    public class GetAllBirdsByColorQuery : IRequest<List<Bird>>
    {
        public string Color { get; set; }
    }
}

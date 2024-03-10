//using Domain.Models;
//using Domain.Models.Animal;
//using Infrastructure.Repository.UserRepository;
//using MediatR;

//namespace Application.Queries.Users.GetAll
//{
//    public sealed class GetAllUserssQueryHandler : IRequestHandler<GetAllUsersQuery, List<AnimalModel>>
//    {
//        private readonly IUserRepository _userRepository;

//        public GetAllUserssQueryHandler(IUserRepository userRepository)
//        {
//            _userRepository = userRepository;
//        }

//        public Task<List<AnimalModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
//        {
//            List<AnimalModel> allAnimals = Task.Run(() => _userRepository.GetAllAnimals(request.UserName, cancellationToken)).Result;

//            return Task.FromResult(allAnimals);
//        }
//    }
//}

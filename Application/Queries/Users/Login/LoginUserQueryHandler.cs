using Application.Queries.Users.Login.Helpers;
using Infrastructure.Database;
using Infrastructure.Repository.UserRepository;
using MediatR;

namespace Application.Queries.Users.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly IUserRepository _userRepository;


        public LoginUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetAllUsers(request.LoginUser.UserName, request.LoginUser.Password, cancellationToken);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            string token = _userRepository.GenerateJwtToken(user);
            return Task.FromResult(token);
        }
    }



}

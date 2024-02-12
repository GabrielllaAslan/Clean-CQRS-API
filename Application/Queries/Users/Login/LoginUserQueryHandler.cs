using Application.Queries.Users.Login.Helpers;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Users.Login
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
    {
        private readonly MockDatabase _mockDatabase;
        private readonly TokenHelper _tokenHelper;


        public LoginUserQueryHandler(MockDatabase mockDatabase, TokenHelper tokenHelper)
        {
            _mockDatabase = mockDatabase;
            _tokenHelper = tokenHelper;
        }

        public Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var user = _mockDatabase.Users.FirstOrDefault(user => user.UserName == request.LoginUser.UserName && user.Password == request.LoginUser.Password);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or password");
            }

            string token = _tokenHelper.GenerateJwtToken(user);
            return Task.FromResult(token);
        }
    }



}

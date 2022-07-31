using Fiap.Project.Recipes.Application.Interfaces;
using Moq;
using Xunit;

namespace Fiap.Project.Recipes.Api.Test
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _userServiceMock;

        public UserControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
        }
        [Fact]
        public void Test1()
        {

        }
    }
}
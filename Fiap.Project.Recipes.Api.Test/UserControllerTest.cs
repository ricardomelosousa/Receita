using Moq;
using Project.Recipes.Application.Interfaces;
using Xunit;

namespace Project.Recipes.Api.Test
{
    public class UserControllerTest
    {
        private readonly Mock<IUserAppService> _userServiceMock;

        public UserControllerTest()
        {
            _userServiceMock = new Mock<IUserAppService>();
        }
        [Fact]
        public void Test1()
        {

        }
    }
}
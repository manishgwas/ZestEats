using Xunit;
using Shared.DTOs;

namespace ContractTests {
    public class UserDtoContractTest {
        [Fact]
        public void UserDto_HasRequiredProperties() {
            var user = new UserDto();
            Assert.NotNull(user.Username);
            Assert.NotNull(user.Email);
        }
    }
}

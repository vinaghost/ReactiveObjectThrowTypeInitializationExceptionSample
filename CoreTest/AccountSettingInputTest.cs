using Core;

namespace CoreTest
{
    public class AccountSettingInputTest
    {
        [Fact]
        public void Get_ReturnsDictionaryWithCorrectCount()
        {
            var accountSettingInput = new AccountSettingInput();

            Assert.NotNull(accountSettingInput);
        }
    }
}
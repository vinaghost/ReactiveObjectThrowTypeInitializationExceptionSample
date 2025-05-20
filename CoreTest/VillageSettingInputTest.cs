using Core;

namespace CoreTest
{
    public class VillageSettingInputTest
    {
        [Fact]
        public void Get_ReturnsDictionaryWithCorrectCount()
        {
            var villageSettingInput = new VillageSettingInput();

            Assert.NotNull(villageSettingInput);
        }
    }
}
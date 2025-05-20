using static Core.ConfigureServices;

namespace CoreTest
{
    public class ServiceProviderTest
    {
        [Fact]
        public void ServiceProviderShouldNotBeNull()
        {
            var serviceProvider = DependencyInjection.Setup();
            Assert.NotNull(serviceProvider);
        }
    }
}
using HomeFindManagement.Contracts.DomainEntities;
using HomeFindManagement.Contracts.RepositoryContracts;
using HomeFindManagement.Implementations;
using Moq;

namespace HomeFindManagement.DomainTest
{
    public class DomainUnitTest
    {
        private readonly Mock<IRepositoryAddons> _repositoryAddonsMock = new Mock<IRepositoryAddons>();
        private readonly Mock<IRepositoryCache> _repositoryCacheMock = new Mock<IRepositoryCache>();
        private readonly Mock<IRepositoryHomes> _repositoryHomesMock = new Mock<IRepositoryHomes>();
        private readonly Mock<IRepositoryHoods> _repositoryHoodsMock = new Mock<IRepositoryHoods>();

        private readonly HomeFinderService _homeFinderService;
        public DomainUnitTest()
        {
            _homeFinderService = new HomeFinderService(_repositoryAddonsMock.Object, _repositoryCacheMock.Object, _repositoryHomesMock.Object, _repositoryHoodsMock.Object);
        }
        [Fact]
        public async void Assert_PriceIsExpectedOnes_When_FoundInCache()
        {
            //Arrange
            HousePrice housePrice = GetHousePrice();

            _repositoryCacheMock.Setup(e => e.GetCache<HousePrice>(It.IsAny<int>())).Returns(housePrice);
            //Act

            var result = await _homeFinderService.GetHomeFinderTotalPrice(housePrice.Id);


            //Asert
            Assert.NotNull(result);
            Assert.Equal(housePrice.TotalCost, result);

        }

        [Fact]
        public async void Assert_ReturnsZero_When_NotFoundId()
        {
            //Arrange
            List<Homes> home = GetHomes();

            _repositoryCacheMock.Setup(e => e.GetCache<HousePrice>(It.IsAny<int>())).Returns(new HousePrice());
            _repositoryHomesMock.Setup(e => e.GetHomes()).ReturnsAsync(home);
            //Act

            var result = await _homeFinderService.GetHomeFinderTotalPrice(5);


            //Asert
            Assert.Equal(0, result);
 

        }
        private HousePrice GetHousePrice()
        {
            return new HousePrice
            {

                Id = 1,
                TotalCost = 173221.01m
            };
        }
        private List<Homes> GetHomes()
        {

            return new List<Homes>
            {
                new Homes
                {
                    Id = 1,
                    HoodId = 1,
                    Meters = 175,
                    Addons = new Dictionary<string, decimal>
                    {
                        { "Piscina", 35m }
                    }
                }


            };
        }
    }
}
using LeagueInformer.Api.Interfaces;
using LeagueInformer.Models;
using LeagueInformer.Services;
using Moq;
using Xunit;

namespace LeagueInformer_UnitTests.Services
{
    public class GetLeagueInfoServiceTest
    {
        private readonly Mock<IApiClient> _GetJson;
        private readonly GetLeagueInfoService _GetLeagueInfo;
        public GetLeagueInfoServiceTest()
        {
            _GetJson = new Mock<IApiClient>();
            _GetLeagueInfo = new GetLeagueInfoService(_GetJson.Object);
        }

        [Fact]
        public async void JsonResponseIsNull()
        {
            //Arrange
            _GetJson.Setup(x => x.GetJsonFromUrl("abc")).ReturnsAsync(string.Empty);

            //Act
            var result = await _GetLeagueInfo.GetListOfSummonerLeague("", new LeagueOfSummoner(), "");

            //Assert
            Assert.False(result.IsSuccess);
        }
    }
}

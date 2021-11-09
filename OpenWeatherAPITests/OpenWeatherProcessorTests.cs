using OpenWeatherAPI;
using System;
using Xunit;

namespace OpenWeatherAPITests
{
    public class OpenWeatherProcessorTests
    {
        //Tous les test sont complétés
        [Theory]
        [InlineData (null)]
        [InlineData("")]
        public async void GetOneCallAsync_IfApiKeyEmptyOrNull_ThrowArgumentException(string temp)
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;

            openWeatherProcessor.ApiKey = temp;

           await Assert.ThrowsAsync<ArgumentException>(openWeatherProcessor.GetOneCallAsync);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async void GetCurrentWeatherAsync_IfApiKeyEmptyOrNull_ThrowArgumentException(string temp)
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;

            openWeatherProcessor.ApiKey = temp;

            await Assert.ThrowsAsync<ArgumentException>(openWeatherProcessor.GetCurrentWeatherAsync);
        }

        [Fact]
        public async void GetOneCallAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;

            await Assert.ThrowsAsync<ArgumentException>(openWeatherProcessor.GetOneCallAsync);
        }

        [Fact]
        public async void GetCurrentWeatherAsync_IfApiHelperNotInitialized_ThrowArgumentException()
        {
            OpenWeatherProcessor openWeatherProcessor = OpenWeatherProcessor.Instance;

            await Assert.ThrowsAsync<ArgumentException>(openWeatherProcessor.GetCurrentWeatherAsync);
        }
    }
}

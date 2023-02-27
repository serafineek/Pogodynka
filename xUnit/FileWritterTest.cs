using Pogodynka;

namespace xUnit
{
    public class FileWritterTests
    {
        [Fact]
        public void SaveForeCastSavesFileSuccessfully()
        {
            // Arrange
            string path = "@\"../../../ForeCasts/";
            string forecastText = "Test forecast text";
            string fileName = "test_file";
            FileWritter fileWritter = new FileWritter(path, forecastText, fileName);
            fileWritter.saveForeCast();
            Assert.True(File.Exists(path + fileName + ".csv"));
            string fileContent = File.ReadAllText(path + fileName + ".csv");
            Assert.Equal(forecastText, fileContent);
        }
    }
}
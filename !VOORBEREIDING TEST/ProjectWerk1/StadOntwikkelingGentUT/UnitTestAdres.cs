using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Exceptions;

namespace StadOntwikkelingGentUT
{
    public class UnitTestAdres
    {
        [Fact]
        public void Straat_Geldig()
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");
            var expectedStraat = "Berchemstraat 46";

            //Act
            adres.Straat = expectedStraat;

            //Assert
            Assert.Equal(expectedStraat, adres.Straat);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Straat_Ongeldig(string waarde)
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");

            //Act & Assert
            Assert.Throws<AdresException>(() => adres.Straat = waarde);
        }

        [Fact]
        public void Huisnummer_Geldig()
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");
            var expectedHuisnummer = "46";

            //Act
            adres.Huisnummer = expectedHuisnummer;

            //Assert
            Assert.Equal(expectedHuisnummer, adres.Huisnummer);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Huisnummer_Ongeldig(string waarde)
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");

            //Act & Assert
            Assert.Throws<AdresException>(() => adres.Huisnummer = waarde);
        }

        [Fact]
        public void Gemeente_Geldig()
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");
            var expectedGemeente = "Kluisbergen";

            //Act
            adres.Gemeente = expectedGemeente;

            //Assert
            Assert.Equal(expectedGemeente, adres.Gemeente);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Gemeente_Ongeldig(string waarde)
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");

            //Act & Assert
            Assert.Throws<AdresException>(() => adres.Gemeente = waarde);
        }
        [Fact]
        public void Provincie_Geldig()
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");
            var expectedProvincie = "Oost-Vlaanderen";

            //Act
            adres.Provincie = expectedProvincie;

            //Assert
            Assert.Equal(expectedProvincie, adres.Provincie);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Provincie_Ongeldig(string waarde)
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");

            //Act & Assert
            Assert.Throws<AdresException>(() => adres.Provincie = waarde);
        }
        [Fact]
        public void Wijk_Geldig()
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");
            var expectedWijk = "Hoogmeersen";

            //Act
            adres.Wijk = expectedWijk;

            //Assert
            Assert.Equal(expectedWijk, adres.Wijk);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Wijk_Ongeldig(string waarde)
        {
            //Arrange
            var adres = new Adres("TestStraat", "TestHuisnummer", "TestGemeente", "TestProvincie", "TestWijk");

            //Act & Assert
            Assert.Throws<AdresException>(() => adres.Wijk = waarde);
        }
    }
}

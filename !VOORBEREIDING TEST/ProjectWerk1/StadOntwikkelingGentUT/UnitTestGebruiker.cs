using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Exceptions;

namespace StadOntwikkelingGentUT
{
    public class UnitTestGebruiker
    {
        [Fact]
        public void Naam_Geldig()
        {
            //Arrange
            Gebruiker TestGebruiker = new Gebruiker("TestNaam", "TestEmail@test.com", "+32468024725", true);
            string expectedNaam = "Bradley D'Haene";

            //Act
            TestGebruiker.Naam = expectedNaam;

            //Assert
            Assert.Equal(expectedNaam, TestGebruiker.Naam);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Naam_Ongeldig(string naam)
        {
            //Arrange
            Gebruiker TestGebruiker = new Gebruiker("TestNaam", "TestEmail@test.com", "+32468024725", true);

            //Act & Assert
            Assert.Throws<GebruikerException>(() => TestGebruiker.Naam = naam);
        }

        [Fact]
        public void Email_Geldig()
        {
            //Arrange
            Gebruiker TestGebruiker = new Gebruiker("TestNaam", "TestEmail@test.com", "+32468024725", true);
            string ExpectedEmail = "dhaenebradley@outlook.com";

            //Act
            TestGebruiker.Email = ExpectedEmail;

            //Assert
            Assert.Equal(ExpectedEmail, TestGebruiker.Email);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("Test")]
        [InlineData(["Test@Outlook"])]
        public void Email_Ongeldig(string email)
        {
            //Arrange
            Gebruiker TestGebruiker = new Gebruiker("TestNaam", "TestEmail@test.com", "+32468024725", true);

            //Act & Assert
            Assert.Throws<GebruikerException>(() => TestGebruiker.Email = email);
        }

        [Theory]
        [InlineData("+32468024725")]
        [InlineData("09468024725")]
        public void TelefoonNummer_Geldig(string expectedTelnummer)
        {
            //Arrange
            Gebruiker TestGebruiker = new Gebruiker("TestNaam", "TestEmail@test.com", "+32468024725", true);

            //Act
            TestGebruiker.TelNummer = expectedTelnummer;

            //Arrange
            Assert.Equal(expectedTelnummer, TestGebruiker.TelNummer);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("+3212")]
        [InlineData("09123")]
        [InlineData("+3212345678912")]
        [InlineData("09123456789123")]
        [InlineData("123456")]
        [InlineData("a12345")]
        public void Telefoonnummer_Ongeldig(string telNummer)
        {
            //Arrange
            Gebruiker TestGebruiker = new Gebruiker("TestNaam", "TestEmail@test.com", "+32468024725", true);

            //Act & Assert
            Assert.Throws<GebruikerException>(() => TestGebruiker.TelNummer = telNummer);
        }
    }
}

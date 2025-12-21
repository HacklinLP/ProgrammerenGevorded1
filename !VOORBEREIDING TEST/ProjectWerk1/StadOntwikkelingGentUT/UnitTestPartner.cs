using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Exceptions;

namespace StadOntwikkelingGentUT
{
    public class UnitTestPartner
    {
        //[Fact]
        //public void Naam_Geldig()
        //{
        //    //Arrange
        //    Bedrijf Bedrijf = new Bedrijf("Test", "+32012345678", "Test@outlook.com");
        //    string ExpectedNaam = "Bradley D'Haene";

        //    //Act
        //    Bedrijf.Naam = ExpectedNaam;

        //    //Assert
        //    Assert.Equal(ExpectedNaam, Bedrijf.Naam);
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void Naam_Ongeldig(string naam)
        //{
        //    //Arrange
        //    Bedrijf Bedrijf = new Bedrijf("Test", "+32012345678", "Test@outlook.com");

        //    //Act & Assert
        //    Assert.Throws<PartnerException>(() => Bedrijf.Naam = naam);
        //}

        //[Theory]
        //[InlineData("+32468024725")]
        //[InlineData("09468024725")]
        //public void TelefoonNummer_Geldig(string expectedTelnummer)
        //{
        //    //Arrange
        //    Bedrijf Bedrijf = new Bedrijf("Test", "+32012345678", "Test@outlook.com");

        //    //Act
        //    Bedrijf.TelNummer = expectedTelnummer;

        //    //Arrange
        //    Assert.Equal(expectedTelnummer, Bedrijf.TelNummer);
        //}
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //[InlineData("+3212")]
        //[InlineData("09123")]
        //[InlineData("+3212345678912")]
        //[InlineData("09123456789123")]
        //[InlineData("123456")]
        //[InlineData("a12345")]
        //public void Telefoonnummer_Ongeldig(string telNummer)
        //{
        //    //Arrange
        //    Bedrijf Bedrijf = new Bedrijf("Test", "+32012345678", "Test@outlook.com");

        //    //Act & Assert
        //    Assert.Throws<PartnerException>(() => Bedrijf.TelNummer = telNummer);
        //}

        //[Fact]
        //public void Email_Geldig()
        //{
        //    //Arrange
        //    Bedrijf Bedrijf = new Bedrijf("Test", "+32012345678", "Test@outlook.com");
        //    string expectedEmail = "dhaenebradley@outlook.com";

        //    //Act
        //    Bedrijf.Email = expectedEmail;

        //    //Assert
        //    Assert.Equal(expectedEmail, Bedrijf.Email);
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //[InlineData("Test")]
        //[InlineData("Test@outlook")]
        //public void Email_Ongeldig(string email)
        //{
        //    //Arrange
        //    Bedrijf Bedrijf = new Bedrijf("Test", "+32012345678", "Test@outlook.com");

        //    //Act & Assert
        //    Assert.Throws<PartnerException>(() => Bedrijf.Email = email);
        //}
    }
}

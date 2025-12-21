using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Exceptions;

namespace StadOntwikkelingGentUT
{
    public class UnitTestProject
    {
        //[Fact]
        //public void Titel_Geldig()
        //{
        //    //Arrange
        //    Adres TestAdres = new Adres("Test", "12", "Test", "Test", "Test");
        //    Bedrijf TestPartner = new Bedrijf("Test", "+32456", "Test@outlook.com");
        //    List<Partner> Partners = new List<Partner>();
        //    List<TypeProject> TypeProjects = new List<TypeProject>();
        //    Project TestProject = new Project("Test", DateTime.Now, StatusProject.Planning, "Test", TestAdres, Partners, TypeProjects);
        //    string ExpectedTitel = "Nieuw";

        //    //Act
        //    TestProject.Titel = ExpectedTitel;

        //    //Assert
        //    Assert.Equal(ExpectedTitel, TestProject.Titel);
        //}

        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void Titel_Ongeldig(string expectedTitel)
        //{
        //    //Arrange
        //    Adres TestAdres = new Adres("Test", "12", "Test", "Test", "Test");
        //    Bedrijf TestPartner = new Bedrijf("Test", "+32456", "Test@outlook.com");
        //    List<Partner> Partners = new List<Partner>();
        //    List<TypeProject> TypeProjects = new List<TypeProject>();
        //    Project TestProject = new Project("Test", DateTime.Now, StatusProject.Planning, "Test", TestAdres, Partners, TypeProjects);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.Titel = expectedTitel); 
        //}
        //[Fact]
        //public void Beschrijving_Geldig()
        //{
        //    //Arrange
        //    Adres TestAdres = new Adres("Test", "12", "Test", "Test", "Test");
        //    Bedrijf TestPartner = new Bedrijf("Test", "+32456", "Test@outlook.com");
        //    List<Partner> Partners = new List<Partner>();
        //    List<TypeProject> TypeProjects = new List<TypeProject>();
        //    Project TestProject = new Project("Test", DateTime.Now, StatusProject.Planning, "Test", TestAdres, Partners, TypeProjects);
        //    string ExpectedBeschrijving = "Beschrijving";

        //    //Act
        //    TestProject.Beschrijving = ExpectedBeschrijving;

        //    //Assert
        //    Assert.Equal(ExpectedBeschrijving, TestProject.Beschrijving);
        //}
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void Beschrijving_Ongeldig(string expectedBeschrijving)
        //{
        //    //Arrange
        //    Adres TestAdres = new Adres("Test", "12", "Test", "Test", "Test");
        //    Bedrijf TestPartner = new Bedrijf("Test", "+32456", "Test@outlook.com");
        //    List<Partner> Partners = new List<Partner>();
        //    List<TypeProject> TypeProjects = new List<TypeProject>();
        //    Project TestProject = new Project("Test", DateTime.Now, StatusProject.Planning, "Test", TestAdres, Partners, TypeProjects);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.Beschrijving = expectedBeschrijving);
        //}
        //[Fact]
        //public void VoegPartnerToe_VoegtPartnerAanLijstToe()
        //{
        //    //Arrange
        //    Adres TestAdres = new Adres("Test", "12", "Test", "Test", "Test");
        //    Bedrijf TestPartner = new Bedrijf("Test", "+32456", "Test@outlook.com");
        //    List<Partner> Partners = new List<Partner>();
        //    List<TypeProject> TypeProjects = new List<TypeProject>();
        //    Project TestProject = new Project("Test", DateTime.Now, StatusProject.Planning, "Test", TestAdres, Partners, TypeProjects);

        //    //Act
        //    TestProject.VoegPartnerToe(TestPartner);

        //    //Assert
        //    Assert.Single(TestProject.Partners);
        //    Assert.Contains(TestPartner, Partners);
        //}
    }
}

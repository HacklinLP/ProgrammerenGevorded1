using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Exceptions;

namespace StadOntwikkelingGentUT
{
    public class UnitTestInnovatiefWonenProject
    {
        //[Fact]
        //public void AantalWooneenheden_Geldig()
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);
        //    int ExpectedWooneenheden = 1;

        //    //Act
        //    TestProject.AantalWooneenheden = ExpectedWooneenheden;

        //    //Assert
        //    Assert.Equal(ExpectedWooneenheden, TestProject.AantalWooneenheden);
        //}
        //[Fact]
        //public void AantalWooneenheden_Ongeldig()
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);
        //    int ExpectedWooneenheden = 0;

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.AantalWooneenheden = ExpectedWooneenheden);
        //}
        //[Fact]
        //public void TypeWoonvormen_Geldig()
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);
        //    string ExpectedTypeWoonvormen = "Huis";

        //    //Act
        //    TestProject.TypeWoonvormen = ExpectedTypeWoonvormen;

        //    //Assert
        //    Assert.Equal(ExpectedTypeWoonvormen, TestProject.TypeWoonvormen);
        //}
        //[Theory]
        //[InlineData(null)]
        //[InlineData("")]
        //[InlineData(" ")]
        //public void TypeWoonvormen_Ongeldig(string expectedTypeWoonvormen)
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.TypeWoonvormen = expectedTypeWoonvormen);
        //}
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //public void IsRondleidingMogelijk_Geldig(bool isRondleidingMogelijk)
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);

        //    //Act
        //    TestProject.IsRondleidingMogelijk = isRondleidingMogelijk;

        //    //Assert
        //    Assert.Equal(isRondleidingMogelijk, TestProject.IsRondleidingMogelijk);
        //}
        //[Fact]
        //public void IsRondleidingMogelijk_Ongeldig()
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.IsRondleidingMogelijk = null);
        //}
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //public void IsShowwoningBeschikbaar_Geldig(bool isShowroomBeschikbaar)
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);

        //    //Act
        //    TestProject.IsShowwoningBeschikbaar = isShowroomBeschikbaar;

        //    //Assert
        //    Assert.Equal(isShowroomBeschikbaar, TestProject.IsShowwoningBeschikbaar);
        //}
        //[Fact]
        //public void IsShowwoningBeschikbaar_Ongeldig()
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.IsShowwoningBeschikbaar = null);
        //}
        //[Theory]
        //[InlineData(0)]
        //[InlineData(10)]
        //[InlineData(null)]
        //public void ArchitecturaleScore_Geldig(int architecturaleScore)
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);

        //    //Act
        //    TestProject.ArchitecturaleScore = architecturaleScore;

        //    //Assert
        //    Assert.Equal(architecturaleScore, TestProject.ArchitecturaleScore);
        //}
        //[Theory]
        //[InlineData(-1)]
        //[InlineData(11)]
        //public void ArchitecturaleScore_Ongeldig(int architecturaleScore)
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.ArchitecturaleScore = architecturaleScore);
        //}
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //public void HeeftSamenwerkingStadGent_Geldig(bool heeftSamenwerkingStadGent)
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);

        //    //Act
        //    TestProject.HeeftSamenwerkingErfgoedOfToerismeGent = heeftSamenwerkingStadGent;

        //    //Assert
        //    Assert.Equal(heeftSamenwerkingStadGent, TestProject.HeeftSamenwerkingErfgoedOfToerismeGent);
        //}
        //[Fact]
        //public void HeeftSamenwerkingStadGent_Ongeldig()
        //{
        //    //Arrange
        //    InnovatiefWonenProject TestProject = new InnovatiefWonenProject(1, 1, "Test", true, true, 1, true);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.HeeftSamenwerkingErfgoedOfToerismeGent = null);
        //}
    }
}

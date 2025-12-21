using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StadontwikkelingGentBL.Domein;
using StadontwikkelingGentBL.Exceptions;

namespace StadOntwikkelingGentUT
{
    public class UnitTestGroeneRuimteProject
    {
        //[Fact]
        //public void Oppervlakte_Geldig()
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);
        //    double ExpectedOppervlakte = 0.1;

        //    //Act
        //    TestProject.OppervlakteVierkanteM = ExpectedOppervlakte;

        //    //Assert
        //    Assert.Equal(ExpectedOppervlakte, TestProject.OppervlakteVierkanteM);
        //}
        //[Theory]
        //[InlineData(0.0)]
        //[InlineData(-0.1)]
        //public void Oppervlakte_Ongeldig(double expectedOppervlakte)
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.OppervlakteVierkanteM = expectedOppervlakte);
        //}
        //[Theory]
        //[InlineData(0)]
        //[InlineData(10)]
        //public void BiodiversiteitsScore_Geldig(int expectedBioDivScore)
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);

        //    //Act
        //    TestProject.BiodiversiteitsScore = expectedBioDivScore;

        //    //Assert
        //    Assert.Equal(expectedBioDivScore, TestProject.BiodiversiteitsScore);
        //}
        //[Theory]
        //[InlineData(-1)]
        //[InlineData(11)]
        //public void BiodiversiteitsScore_Ongeldig(int expectedBioDivScore)
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.BiodiversiteitsScore = expectedBioDivScore);
        //}
        //[Fact]
        //public void AantalWandelPaden_Geldig()
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);
        //    int ExpectedAantalWandelpaden = 0;

        //    //Act
        //    TestProject.AantalWandelpaden = ExpectedAantalWandelpaden;

        //    //Assert
        //    Assert.Equal(ExpectedAantalWandelpaden, TestProject.AantalWandelpaden);
        //}
        //[Fact]
        //public void AantalWandelpaden_Ongeldig()
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);
        //    int ExpectedAantalWandelpaden = -1;

        //    //Act & Assert 
        //    Assert.Throws<ProjectException>(() => TestProject.AantalWandelpaden = ExpectedAantalWandelpaden);
        //}
        //[Theory]
        //[InlineData(null)]
        //[InlineData(0)]
        //[InlineData(5)]
        //public void BeoordelingBezoekers_Geldig(int bezoekerBeoordeling)
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);

        //    //Act
        //    TestProject.BeoordelingBezoekers = bezoekerBeoordeling;

        //    //Assert
        //    Assert.Equal(bezoekerBeoordeling, TestProject.BeoordelingBezoekers);
        //}
        //[Theory]
        //[InlineData(-1)]
        //[InlineData(6)]
        //public void BeoordelingBezoekers_Ongeldig(int bezoekerBeoordeling)
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.BeoordelingBezoekers = bezoekerBeoordeling);
        //}
        //[Theory]
        //[InlineData(true)]
        //[InlineData(false)]
        //public void IsOpgenomenWandelpaden_Geldig(bool isOpgenomenWandelroute)
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);

        //    //Act
        //    TestProject.IsOpgenomenInWandelroute = isOpgenomenWandelroute;

        //    //Assert
        //    Assert.Equal(isOpgenomenWandelroute, TestProject.IsOpgenomenInWandelroute);
        //}
        //[Fact]
        //public void IsOpgenomenWandelroute_Ongeldig()
        //{
        //    //Arrange
        //    GroeneRuimteProject TestProject = new GroeneRuimteProject(1, 14.5, 1, 1, "Test", true, 3);

        //    //Act & Assert
        //    Assert.Throws<ProjectException>(() => TestProject.IsOpgenomenInWandelroute = null);
        //}
    }
}

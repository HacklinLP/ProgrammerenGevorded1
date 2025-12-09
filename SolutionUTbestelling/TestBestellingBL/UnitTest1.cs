using System.Net.Http.Headers;
using BestellingBL;

namespace TestBestellingBL
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1)]
        [InlineData(200)]
        public void Test_id_valid(int id)
        {
            Product p = new Product(10, "zetel", 125.5); // Dit is een arrange. In dit geval waarden toedienen aan een Product
            p.Id = id;
            Assert.Equal(id, p.Id);
        }
        [Theory] // Theory nemen want we testen weer 2 waarden
        [InlineData(0)]
        [InlineData(-1)]
        public void Test_id_invalid(int id)
        {
            Product p = new Product(10, "zetel", 125.5);
            Assert.Throws<BestellingException>(() => p.Id = id); // De act is het laatste stuk tussen de haakjes en het stuk ervoor is de assert

        }

        [Theory]
        [InlineData(1)]
        [InlineData(200)]
        public void Test_prijs_valid(int prijs)
        {
            Product p = new Product(10, "zetel", 125.5);
            p.Prijs = prijs;
            Assert.Equal(prijs, p.Prijs);
        }

        [Theory]
        [InlineData(-0.001)]
        [InlineData(-200)]
        public void Test_prijs_invalid(int prijs)
        {
            Product p = new Product(10, "zetel", 125.5);
            Assert.Throws<BestellingException>(() => p.Prijs = prijs);

        }

        [Theory]
        [InlineData("zetel")]
        [InlineData("stoel en tafel")]
        public void Test_naam_valid(string naam)
        {
            Product p = new Product(10, "zetel", 125.5);
            p.Naam = naam;
            Assert.Equal(naam, p.Naam);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" stoel en tafel")]
        [InlineData("stoel en tafel ")]
        [InlineData("   ")]
        [InlineData(" stoel en tafel ")]
        [InlineData(null)]
        public void Test_naam_invalid(string naam)
        {
            Product p = new Product(10, "zetel", 125.5);
            Assert.Throws<BestellingException>(() => p.Naam = naam);

        }

        [Fact]
        public void Test_ctor_valid()
        {
            Product p = new Product(10, "zetel", 125.5);
            Assert.Equal(10,p.Id);
            Assert.Equal("zetel", p.Naam);
            Assert.Equal(125.5,p.Prijs);
        }

        [Theory]
        [InlineData("",1,10)]
        [InlineData(" stoel en tafel",1,10)]
        [InlineData("stoel en tafel ",1,10)]
        [InlineData("   ",1,10)]
        [InlineData(" stoel en tafel ",1,10)]
        [InlineData(null,1,10)]
        [InlineData("stoel en tafel ", -1, 10)]
        [InlineData("stoel en tafel ", 1, -0.1)]
        public void Test_ctor_invalid(string naam, int id, double prijs)
        {
            Assert.Throws<BestellingException>(() => new Product(id, naam, prijs));
        }
    }
}

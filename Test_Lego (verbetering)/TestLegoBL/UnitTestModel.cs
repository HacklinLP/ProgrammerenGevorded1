using LegoBL.Exceptions;

namespace TestLegoBL
{
    public class UnitTestModel
    {
        [Theory]
        [InlineData(0.1)]
        [InlineData(100)]
        [InlineData(null)]
        public void Test_Price_Valid(double? price)
        {
            LegoSet legoSet = new LegoSet("10", "naam", 1985, 10, 10, 2, "url", 25);
            legoSet.RetailPrice = price;
            Assert.Equal(price, legoSet.RetailPrice);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void Test_Price_Invalid(double? price)
        {
            LegoSet legoSet = new LegoSet("10", "naam", 1985, 10, 10, 2, "url", 25);
            Assert.Throws<LegoException>(()=>legoSet.RetailPrice = price);
        }

        [Fact]
        public void Test_AddLegoSet_Valid()
        {
            LegoTheme legoTheme = new LegoTheme("theme1");
            LegoSet legoSet1 = new LegoSet("10", "naam", 1985, 10, 10, 2, "url", 25);
            LegoSet legoSet2 = new LegoSet("100", "naam", 1985, 10, 10, 2, "url", 25);

            legoTheme.AddLegoSet(legoSet1);
            legoTheme.AddLegoSet(legoSet2);
            Assert.Contains(legoSet1, legoTheme.LegoSets);
            Assert.Contains(legoSet2, legoTheme.LegoSets);
            Assert.Equal(2, legoTheme.LegoSets.Count);
        }

        [Fact]
        public void Test_AddLegoSet_Invalid()
        {
            LegoTheme legoTheme = new LegoTheme("theme1");
            LegoSet legoSet1 = new LegoSet("10", "naam", 1985, 10, 10, 2, "url", 25);
            LegoSet legoSet2 = new LegoSet("100", "naam", 1985, 10, 10, 2, "url", 25);
            LegoSet legoSet3 = new LegoSet("100", "naam", 1985, 10, 10, 2, "url", 25);

            legoTheme.AddLegoSet(legoSet1);
            legoTheme.AddLegoSet(legoSet2);
            
            Assert.Throws<LegoException>(() => legoTheme.AddLegoSet(legoSet3));
            Assert.Contains(legoSet1, legoTheme.LegoSets);
            Assert.Contains(legoSet2, legoTheme.LegoSets);
            Assert.Equal(2, legoTheme.LegoSets.Count);
        }
    }
}

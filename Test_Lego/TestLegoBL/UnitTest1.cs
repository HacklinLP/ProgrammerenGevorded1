namespace TestLegoBL
{
    public class UnitTest1
    {
        private List<LegoSet> legoSet = new();

        public UnitTestLegoTheme()
        {
            legoSet.Add(new LegoSet("20", "Small house set", 67, 1, 5, 18, ".", 9.99));
            legoSet.Add(new LegoSet("15", "Big house set", 75, 4, 7, 15, ".", 29.99));
            legoSet.Add(new LegoSet("18", "Big house set", 80, 6, 7, 10, ".", 59.99));
        }
    }
}

using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using GildedRoseCalculator;
using NUnit.Framework;

namespace ConsoleApp1
{
    [UseReporter(typeof(DiffReporter))]
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();

            Approvals.Verify(output);
        }

        [Test]
        //on the end of 50days quality should be 50
        public void BRI_When_50_Days_Then_Quality_50()
        {
            var list = new List<Item>
            {
                new Item()
                {
                    Name = "Aged Brie",
                    Quality = 0,
                    SellIn = 50
                }
            };
            
        }
    }
}

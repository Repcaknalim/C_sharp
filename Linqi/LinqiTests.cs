using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinqTest
{
    using Linqs;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class LinqiTests
    {
        readonly IEnumerable<Obj> testObjs = new[]
        {
            new Obj() {Name = "Number 1", Number = 1},
            new Obj() {Name = "Number 2", Number = 2},
            new Obj() {Name = "Number 3", Number = 3},
        };

        [TestMethod]
        public void TestGroup()
        {
            var prices = new Dictionary<int, decimal>()
            {
                {1, 20M },
                {2, 10M },
                {3, 1000M },
            };

            var groups = Analyser.GroupByPrice(testObjs, prices);

            Assert.AreEqual(2, groups.Count());
            Assert.AreEqual(PriceRange.Low, groups.First().Key);
            Assert.AreEqual(2, groups.First().First().Number);
            Assert.AreEqual("Number 2", groups.First().First().Name);
        }

        [TestMethod]
        public void TestReviews()
        {
            var testReviews = new[]
            {
                new Review() { Number = 1, Critic = Critics.Critic1, Score = -14.51 },
                new Review() { Number = 2, Critic = Critics.Critic2, Score = 391691234.48931 },
                new Review() { Number = 3, Critic = Critics.Critic1, Score = 0 },
                new Review() { Number = 3, Critic = Critics.Critic2, Score = 43.5 },
            };

            var expectedResults = new[]
            {
                "Critic1 score for nr 1 'Number 1': -14,51",
                "Critic2 score for nr 2 'Number 2': 391691234,49",
                "Critic1 score for nr 3 'Number 3': 0,00",
                "Critic2 score for nr 3 'Number 3': 43,50",
            };

            var actualResults = Analyser.GetReviews(testObjs, testReviews).ToList();
            CollectionAssert.AreEqual(expectedResults, actualResults);
        }
    }
}
using System;
using System.Collections.Generic;
//using System.Linq;

namespace Linqs
{
    public class Obj
    {
        public string? Name { get; set; }
        public int Number { get; set; }

        public static readonly IEnumerable<Obj> Catalog = new List<Obj>
        {
            new Obj { Name = "Number 1", Number = 6 },
            new Obj { Name = "Number 2", Number = 20 },
            new Obj { Name = "Number 3", Number = 13 },
            new Obj { Name = "Number 4", Number = 41 },
            new Obj { Name = "Number 5", Number = 25 },
            new Obj { Name = "Number 6", Number = 36 },
            new Obj { Name = "Number 7", Number = 74 },
            new Obj { Name = "Number 8", Number = 89 },
        };

        public static readonly IReadOnlyDictionary<int, decimal> Prices = new Dictionary<int, decimal>
        {
            { 6, 3600M },
            { 20, 500M },
            { 13, 650M },
            { 41, 13525M },
            { 25, 250M },
            { 36, 75M },
            { 74, 25.75M },
            { 89, 35.25M },
        };

        public static readonly IEnumerable<Review> Rewiews = new[]
        {
            new Review { Number = 36, Critic = Critics.Critic1, Score = 37.6 },
            new Review { Number = 74, Critic = Critics.Critic1, Score = 22.8 },
            new Review { Number = 74, Critic = Critics.Critic2, Score = 58.5 },
            new Review { Number = 41, Critic = Critics.Critic1, Score = 89.8 },
            new Review { Number = 97, Critic = Critics.Critic2, Score = 98.8 },
        };

        public override string ToString() => $"{Name} (Number {Number})";
    }

    public enum Critics
    {
        Critic1,
        Critic2,
    };

    public enum PriceRange
    {
        Low,
        High,
    };

    public class Review
    {
        public int Number { get; set; }
        public Critics Critic { get; set; }
        public double Score { get; set; }
    }

    public class Analyser
    {

        private static PriceRange CalcualtePriceRange(Obj obj, IReadOnlyDictionary<int, decimal> prices) 
            => prices[obj.Number] < 100 ? PriceRange.Low : PriceRange.High;

        public static IEnumerable<IGrouping<PriceRange, Obj>> GroupByPrice(IEnumerable<Obj> objs, IReadOnlyDictionary<int, decimal> prices)
        {
            var grouped =
                objs
                .OrderBy(objs => prices[objs.Number])
                .GroupBy(obj => CalcualtePriceRange(obj, prices));
                /*
                from obj in objs
                orderby prices[obj.Number]
                group obj by CalcualtePriceRange(obj, prices) into priceGroup
                select priceGroup;
                */
            return grouped;
        }

        public static IEnumerable<string> GetReviews(IEnumerable<Obj> objs, IEnumerable<Review> reviews)
        {
            var joined =
                objs
                .OrderBy(objs => objs.Number)
                .Join
                (
                    reviews,
                    obj => obj.Number,
                    review => review.Number,
                    (obj, review) => $"{review.Critic} score for nr {obj.Number} '{obj.Name}': {review.Score:0.00}"
                );
                /*
                from obj in objs
                orderby obj.Number
                join review in reviews on obj.Number equals review.Number
                select $"{review.Critic} score for nr {obj.Number} '{obj.Name}': {review.Score:0.00}";
                */
            return joined;
        }
    }

    class Program
    {
        static void Main()
        {
            var done = false;
            while (!done)
            {
                Console.WriteLine("\nPress G, to group by price, R to display the reviews, or another key to exit");
                done = Console.ReadKey(true).KeyChar.ToString().ToUpper() switch
                {
                    "G" => GroupByPrice(),
                    "R" => GetRevievs(),
                    _ => true,
                };
            }
        }

        private static bool GetRevievs()
        {
            var reviews = Analyser.GetReviews(Obj.Catalog, Obj.Rewiews);

            foreach (var review in reviews)
            {
                Console.WriteLine(review);
            }

            return false;
        }

        private static bool GroupByPrice()
        {
            IEnumerable<IGrouping<PriceRange, Obj>>? groups = Analyser.GroupByPrice(Obj.Catalog, Obj.Prices);

            foreach (var group in groups)
            {
                Console.WriteLine($"Objects {group.Key}:");
                foreach (var entry in group)
                {
                    Console.WriteLine($"Nr {entry.Number} {entry.Name}: {Obj.Prices[entry.Number]:c}");
                }
            }

            return false;
        }
    }
}
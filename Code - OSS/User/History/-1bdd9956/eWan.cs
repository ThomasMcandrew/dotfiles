using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Security.Cryptography;
using AutoFixture;

namespace LinqTesting
{
    public class Benchmarks
    {
        public List<SampleData>? Samples { get; set; }
		public List<string> Q1 => new List<string>();
		public List<string> Q2 = new List<string>(){"Field","Field"};
		public List<string> Q3 = new List<string>();
		public List<string> Q4 = new List<string>(){"Field","Field"};
		public List<string> Q5 = new List<string>();
		public List<string> Q6 = new List<string>(){"Field","Field"};
        [GlobalSetup]
        public void Setup()
        {
            Fixture fixture = new Fixture();
            Samples = fixture.CreateMany<SampleData>(1_000_00).ToList();
			Console.WriteLine(Samples.Skip(0).Take(10).Select(x => x.Field1));
        }
/*
|          Method |     Mean |   Error |  StdDev |
|---------------- |---------:|--------:|--------:|
|      OrderByNew | 167.5 us | 3.34 us | 4.34 us |
| OrderByOriginal | 236.1 us | 4.05 us | 3.59 us |
*/
        [Benchmark]
        public void OrderByNew()
        {
            var result = Samples.If(true,
                    then => then.OrderBy(x => x.StartDate),
                    el => el.OrderByDescending(x => x.StartDate))
                .Skip(50)
                .Take(1_00)
                .ToList();
        }

        [Benchmark]
        public void OrderByOriginal()
        {
            IEnumerable<SampleData>? temp;
            if(true)
                temp = Samples.OrderBy(x => x.StartDate);
            else
                temp = Samples.OrderByDescending(x => x.StartDate);
            var result = temp.Skip(50).Take(1_00).ToList();
        }
		[Benchmark]
		public void ConditionalQueryChainedWhereNew()
		{
			var result = Samples
				.If(Q1.Any(), then => then
						.Where(x => Q1.Any(y => y.Contains(x.Field1))))
				.If(Q2.Any(), then => then
						.Where(x => Q2.Any(y => y.Contains(x.Field2))))
				.If(Q3.Any(), then => then
						.Where(x => Q3.Any(y => y.Contains(x.Field3))))
				.If(Q4.Any(), then => then
						.Where(x => Q4.Any(y => y.Contains(x.Field4))))
				.If(Q5.Any(), then => then
						.Where(x => Q5.Any(y => y.Contains(x.Field5))))
				.If(Q6.Any(), then => then
						.Where(x => Q6.Any(y => y.Contains(x.Field6))))
				.ToList();

		}
		[Benchmark]
		public void ConditionalQueryChainedWhereOriginal()
		{

		}

    }
}

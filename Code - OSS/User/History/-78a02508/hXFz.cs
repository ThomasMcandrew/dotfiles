using LinqTesting;
using BenchmarkDotNet.Running;



var list = new List<SampleData>();
for(int i = 0; i < 100; i++){
    list.Add(new SampleData { Id = i, Name = $"{i}", StartDate = DateTime.Now});
}

//Simpler For cases when you want to do certain functions like OrderBy vs OrderByDescending
//Also could be seen as a move visibly understandable function over tertiary
//and the tertiary operator does not need to be evaluated for every item in the enumeration
var updated = list.If(x => x.Count() < 50,
        then => then.Where(x => x.Id < 50).OrderByDescending(x => x.StartDate),
        elsePredicate => elsePredicate.Where(x => x.Id > 50).OrderBy(x => x.StartDate))
    .ToList();

var result = list.Where(x => (list.Count() > 50) ? (x.Id < 50) : (true));

if(list.Count() < 50)
{
    result = result.OrderByDescending(x => x.StartDate);
}
else
{
    result = result.OrderBy(x => x.StartDate);
}
var endResult = result.ToList();

//Case 1
var AcceptableNames = new List<string>(){ "Name1", "Name2", "Name3"};
var names = list.If(AcceptableNames.Any(),
        then => then.Where(x => AcceptableNames.Contains(x.Name)))
    .Select(x => x.Name);
//Case 2
AcceptableNames = new List<string>(){ };
names = list.If(AcceptableNames.Any(),
        then => then.Where(x => AcceptableNames.Contains(x.Name)))
    .Select(x => x.Name);
//In Case1 We Know that There are values to filter for so we evaluate as so
//In Case2 We know that We dont have anything to filter for so we want all results
//Rather than checking for every item we just return.




//OUT

//This one life simplicity
//The main example I use this for is when paginating data where you return a 
//subset of the data but want to also give the amount of total data
var orderBy = "ASC";
names = list.If(AcceptableNames.Any(),
                then => then.Where(x => AcceptableNames.Contains(x.Name)))
            .If(orderBy == "ASC",
                then => then.OrderBy(x => x.StartDate),
                el => el.OrderByDescending(x => x.StartDate))
            .Out(x => x.Count(), out var count)
    .Select(x => x.Name);

var foo = " asdf";

BenchmarkRunner.Run<Benchmarks>();


using ConsoleApp1;

List<string> list = new List<string>();
List<string> masklist = new List<string>();
Random random = new Random();
for (int g = 0; g <= 100000; g++)
{
    string randomNumber = string.Join(string.Empty, Enumerable.Range(0, 10).Select(number => random.Next(0, 9).ToString()));
    list.Add(randomNumber);
}

await Task.WhenAll(list.Select(async x => masklist.Add(x.Substring(0, 5) + "****")));


//Parallel.ForEach(list, str =>
//{
//    masklist.Add(str.Substring(0,5)+"****");
//});
Thread.Sleep(10000);

/////////////////////////////////////////////
Task t = Task.Run(() => {
    
    Console.WriteLine("This is First Task");
});
t.Wait();


//Checked the Task status 
if(t.Status==TaskStatus.RanToCompletion)
Console.WriteLine("Finished");

////////////////////////////////////////////////
//Continuations allow tasks to chain together, meaning one task can start once another completes.

Task firstTask = Task.Run(() => {

    Task.Delay(2000);
    Console.WriteLine("This is first Task ");
});

Task SecondTaslk = firstTask.ContinueWith(t => Console.WriteLine("This is second Task "));

SecondTaslk.Wait();


////////////////////////////////////////////////////
//The Parallel class simplifies running loops in parallel. 
//it runs multiple iterations at the same time.

Parallel.For(0, 10, i => { 
Console.WriteLine($"{i}");
});
Console.WriteLine("-------------------");


///////////////////////////////////////////////////
//Processing Collections with Parallel.ForEach

List<int> ListOfInt = new List<int> { 1, 2, 3, 4, 5, 6 };

Parallel.ForEach(ListOfInt, number =>
{
    Console.WriteLine($"{number}");
});


//////////////////////////////////////////////////
//Exception Handling in Parallel Loops
try

{
    Parallel.ForEach(ListOfInt, number =>

    {

        //if (number == 3)
        //{
        //    throw new InvalidOperationException("Number 3 is not allowed!");
        //}
        Console.WriteLine($"Processing number: {number}");

    });
}

catch (AggregateException ae)

{
    foreach (var ex in ae.InnerExceptions)

    {
        Console.WriteLine(ex.Message);
    }
}

//////////////////////////////////////////////////////////////////
//Async / Await in Parallel Programming
TaskClass taskClass = new TaskClass();
await taskClass.GetResult();
Console.WriteLine("GetResult runned..");

/////////////////////////////////////////////////////////////////
/////PLINQ stands for Parallel LINQ, which allows for parallel querying of data.
///
var data = Enumerable.Range(1, 100).ToList();

var parallelQuery = data.AsParallel().Where(x => x % 2 == 0).ToList();



parallelQuery.ForEach(Console.WriteLine);

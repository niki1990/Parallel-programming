

Console.WriteLine("Hello from Main!");
Task t = Task.Run(() => {
    
    Console.WriteLine("This is First Task");
});
t.Wait();
if(t.Status==TaskStatus.RanToCompletion)
Console.WriteLine("Finished");
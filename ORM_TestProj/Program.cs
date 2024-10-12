using ORM_TestProj.Context;
using ORM_TestProj.Entities;

namespace ORM_TestProj{
    
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // using (var db = new MyDbContext())
            // {
            //     Logist logist1 = new() { FirstName = "Tom", LastName = "Yam", Surname = "P-Diddy", 
            //         Email = "tom@gmail.com", PhoneNumber = "+389876543212" };
            //     var logist2 = new Logist { FirstName = "Alice", LastName = "In", Surname = "Chains", 
            //         Email = "alice@gmail.com", PhoneNumber = "+387654927895" };
            //     
            //     db.Logists.AddRange(logist1, logist2);
            //     db.SaveChanges();
            // }
            //
            // using (var db = new MyDbContext())
            // {
            //     var logists = db.Logists.ToList();
            //     Console.WriteLine("Logists list:");
            //     foreach (var logist in logists)
            //     {
            //         Console.WriteLine($"{logist.Id}.{logist.FirstName} - {logist.LastName} - {logist.Surname} - " +
            //                           $"{logist.Email} - {logist.PhoneNumber}");
            //     }
            // }
        }
    }

    
}
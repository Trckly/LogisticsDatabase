using ORM_TestProj.Context;
using ORM_TestProj.Entities;

namespace ORM_TestProj{
    
    internal static class Program
    {
        private static void PopulateTestingTables()
        {
            using (var db = new MyDbContext())
            {
                var logist1 = new Logist
                {
                    FirstName = "Tom", 
                    LastName = "Yam", 
                    Surname = "Gam",
                    Email = "tom@gmail.com", 
                    PhoneNumber = "+389876543212"
                };
                
                var logist2 = new Logist
                {
                    FirstName = "Alice", 
                    LastName = "Malice", 
                    Surname = "Chains",
                    Email = "alice@gmail.com", 
                    PhoneNumber = "+387654927895"
                };

                var logist3 = new Logist
                {
                    FirstName = "Danylo", 
                    LastName = "Vasyliovych", 
                    Surname = "Shlomaik",
                    Email = "some_email@mail.com", 
                    PhoneNumber = "+380676776688"
                };
                
                db.Logists.AddRange(logist1, logist2, logist3);

                var drivingLicence1 = new DrivingLicense()
                {
                    DrivingLicenceId = "ВХІ657332",
                    LicenseIssuer = "SomeIssuer",
                    LicenseIssuingDate = new DateOnly(2001, 11, 4)
                };
                
                var drivingLicence2 = new DrivingLicense()
                {
                    DrivingLicenceId = "ВХА321554",
                    LicenseIssuer = "OtherIssuer",
                    LicenseIssuingDate = new DateOnly(2005, 5, 6)
                };
                
                var drivingLicence3 = new DrivingLicense()
                {
                    DrivingLicenceId = "АВІ899545",
                    LicenseIssuer = "AnotherIssuer",
                    LicenseIssuingDate = new DateOnly(2010, 3, 22)
                };
                
                var driver1 = new Driver()
                {
                    FirstName = "Fred",
                    LastName = "Gabriel",
                    Surname = "Ptaha",
                    PhoneNumber = "+389876543212",
                    DrivingLicenseNavigation = drivingLicence1
                };
                
                var driver2 = new Driver()
                {
                    FirstName = "Benedict",
                    LastName = "Eziovych",
                    Surname = "Cumber",
                    PhoneNumber = "+380876534212",
                    DrivingLicenseNavigation = drivingLicence2
                };
                
                var driver3 = new Driver()
                {
                    FirstName = "Vincent",
                    LastName = "Orionovych",
                    Surname = "Grazi",
                    PhoneNumber = "+380696543213",
                    DrivingLicenseNavigation = drivingLicence3
                };
                db.Drivers.AddRange(driver1, driver2, driver3);

                var vehicle1 = new Vehicle()
                {
                    CarryingCapacity = 22.8d,
                    Model = "Iveco",
                    ProductionYear = 2015,
                    LicensePlate = "BC2340IB"
                };
                
                var vehicle2 = new Vehicle()
                {
                    CarryingCapacity = 24.6d,
                    Model = "MAN",
                    ProductionYear = 2009,
                    LicensePlate = "BK5722XA"
                };
                
                var vehicle3 = new Vehicle()
                {
                    CarryingCapacity = 22.4d,
                    Model = "Mercedes-Benz",
                    ProductionYear = 2021,
                    LicensePlate = "KI4977IB"
                };
                db.Vehicles.AddRange(vehicle1, vehicle2, vehicle3);

                var order = new Order()
                {
                    LogistId = logist1.Id,
                    ClientCompanyName = "Some Big Client",
                    CarrierCompanyName = "Even Bigger Carrier",
                    VehicleId = vehicle2.Id,
                    DriverId = driver3.Id,
                    ClientPrice = 35467.5d,
                    CarrierPrice = 30555.21d
                };
                db.Orders.Add(order);
                
                db.SaveChanges();
            }
            
            using (var db = new MyDbContext())
            {
                var logists = db.Logists.ToList();
                Console.WriteLine("Logists list:");
                foreach (var logist in logists)
                {
                    Console.WriteLine($"{logist.Id}.{logist.FirstName} - {logist.LastName} - {logist.Surname} - " +
                                      $"{logist.Email} - {logist.PhoneNumber}");
                }
            }
        }

        private static void Main(string[] args)
        {
            PopulateTestingTables();
        }
    }
}
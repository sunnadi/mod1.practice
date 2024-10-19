using System;
using System.Collections.Generic;

public abstract class Vehicle
{
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }

    public Vehicle(string make, string model, int year)
    {
        Make = make;
        Model = model;
        Year = year;
    }

    public abstract void StartEngine();
    public abstract void StopEngine();
}
public class Car : Vehicle
{
    public int Doors { get; set; }
    public string TransmissionType { get; set; }

    public Car(string make, string model, int year, int doors, string transmissionType)
        : base(make, model, year)
    {
        Doors = doors;
        TransmissionType = transmissionType;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"Двигатель автомобиля {Make} {Model} запущен.");
    }

    public override void StopEngine()
    {
        Console.WriteLine($"Двигатель автомобиля {Make} {Model} остановлен.");
    }
}

public class Motorcycle : Vehicle
{
    public string BodyType { get; set; }
    public bool HasSidecar { get; set; }

    public Motorcycle(string make, string model, int year, string bodyType, bool hasSidecar)
        : base(make, model, year)
    {
        BodyType = bodyType;
        HasSidecar = hasSidecar;
    }

    public override void StartEngine()
    {
        Console.WriteLine($"Двигатель мотоцикла {Make} {Model} запущен.");
    }

    public override void StopEngine()
    {
        Console.WriteLine($"Двигатель мотоцикла {Make} {Model} остановлен.");
    }
}
public class Garage
{
    private List<Vehicle> vehicles = new List<Vehicle>();

    public List<Vehicle> Vehicles => vehicles;

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
        Console.WriteLine($"Транспортное средство {vehicle.Make} {vehicle.Model} добавлено в гараж.");
    }

    public void RemoveVehicle(string model)
    {
        var vehicle = vehicles.Find(v => v.Model == model);
        if (vehicle != null)
        {
            vehicles.Remove(vehicle);
            Console.WriteLine($"Транспортное средство {vehicle.Make} {vehicle.Model} удалено из гаража.");
        }
        else
        {
            Console.WriteLine("Транспортное средство не найдено.");
        }
    }
}

public class Autopark
{
    private List<Garage> garages = new List<Garage>();

    public void AddGarage(Garage garage)
    {
        garages.Add(garage);
        Console.WriteLine("Гараж добавлен в автопарк.");
    }

    public void RemoveGarage(Garage garage)
    {
        garages.Remove(garage);
        Console.WriteLine("Гараж удален из автопарка.");
    }

    public Vehicle FindVehicle(string model)
    {
        foreach (var garage in garages)
        {
            foreach (var vehicle in garage.Vehicles)
            {
                if (vehicle.Model == model)
                {
                    return vehicle;
                }
            }
        }
        return null; 
    }
}

class Program
{
    static void Main()
    {
        var car1 = new Car("Mercedes", "Benz", 2021, 4, "Автомат");
        var motorcycle1 = new Motorcycle("", "MT-09", 2021, "Спорт", false);

        var garage1 = new Garage();
        garage1.AddVehicle(car1);
        garage1.AddVehicle(motorcycle1);

        var autopark = new Autopark();
        autopark.AddGarage(garage1);

        car1.StartEngine();
        motorcycle1.StartEngine();
        car1.StopEngine();
        motorcycle1.StopEngine();

        garage1.RemoveVehicle("MT-09");
    }
}

// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;

Console.WriteLine("Hello, World!");

// objet non initialisé

Plane plane = new Plane();
plane.Capacity = 100;
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Airbus;

//Plane plane2 = new Plane(200,new DateTime(2024,12,11,12,12,00),PlaneType.Boeing);

//Initialiseur d'objets
Plane plane2 = new Plane
{
    Capacity = 200,
    PlaneType = PlaneType.Boeing,
    ManufactureDate = new DateTime(2024, 12, 11, 12, 12, 00)
};
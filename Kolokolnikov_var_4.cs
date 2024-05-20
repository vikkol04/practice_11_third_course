using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class KolokolnikovVar4
    {
        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public bool IsElectric { get; set; }
            public List<string> Features { get; set; }
            public string Write()
            {
                return $"\n Make: {Make}\n Model: {Model}\n Year: {Year}\n IsElectric: {IsElectric}\n Features: [{string.Join(", ", Features)}]";
            }
        }
        static void Main (string[] args)
        {
            Console.WriteLine($"\n\nJSON. --------------------------------------------------------\n");
            Console.ReadLine();
            // Create the Car object
            Car car1 = new Car
            {
                Make = "Tesla",
                Model = "Model S",
                Year = 2020,
                IsElectric = true,
                Features = new List<string> { "Autopilot", "Electric motor", "Glass roof" }
            };
            // Serialization of the object in JSON
            string json = JsonConvert.SerializeObject(car1, Formatting.Indented);
            File.WriteAllText("car1.json", json);
            Console.WriteLine($"The Car object is serialized to the car1.json file");

            // Deserialize JSON back into an object
            string jsonFromFile = File.ReadAllText("car1.json");
            Car deserializedCar1 = JsonConvert.DeserializeObject<Car>(jsonFromFile);
            Console.WriteLine($"Deserialized car1 from json: {deserializedCar1.Write()}");

            Console.WriteLine($"\n\nXML. --------------------------------------------------------\n");
            Console.ReadLine();
            // Create the Car object
            Car car2 = new Car
            {
                Make = "Porshe",
                Model = "Turbo S",
                Year = 2016,
                IsElectric = false,
                Features = new List<string> { "Active Aerodynamics", "Launch Control", "Turbocharged Engine" }
            };
            // Serialization of the object in XML
            XmlSerializer serializer = new XmlSerializer(typeof(Car));
            string xmlFileName = "car2.xml";
            using (FileStream stream = new FileStream(xmlFileName, FileMode.Create))
            {
                serializer.Serialize(stream, car2);
                Console.WriteLine($"Data saved to {xmlFileName}");
            }

            // Deserialize XML back into an object
            using (FileStream stream = new FileStream(xmlFileName, FileMode.Open))
            {
                Car deserializedCar2 = (Car)serializer.Deserialize(stream);
                Console.WriteLine($"Deserialized сar2 from xml: {deserializedCar2.Write()}");
            }
        }
    }
}

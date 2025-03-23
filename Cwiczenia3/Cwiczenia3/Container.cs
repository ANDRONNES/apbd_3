using System.Text;

namespace Cwiczenia3;

public abstract class Container
{
    public static int ContainerNumber = 0;
    protected double Weight;
    protected double Height;
    protected double ContainerWeight;
    protected double ContainerDepth;
    protected double MaxCapacity;
    private string SerialNumber { get; set; }
    public string GetSerialNumber() => SerialNumber;
    public string SetSerialNumber(string serialNumber) => SerialNumber = serialNumber;
    public double GetWeight() => Weight;
    public double GetContainerWeight() => ContainerWeight;

    public Container(double height, double containerWeight, double containerDepth, double maxCapacity)
    {
        Weight = 0;
        Height = height;
        ContainerWeight = containerWeight;
        ContainerDepth = containerDepth;
        MaxCapacity = maxCapacity;
        ContainerNumber++;
    }

    public /*virtual*/ string getInfo()
    {
        StringBuilder sb = new StringBuilder();
        string isEmpty = Weight == 0 ? "Container is empty" : "Container is not empty";
        sb.Append("Weight: " + Weight + ", Height: " + Height + ", Container Weight: " + ContainerWeight +
                  ", Container Depth: " + ContainerDepth + ", Max Capacity: " + MaxCapacity +
                  "\nSerial Number: " + SerialNumber + ", " + isEmpty);
        return sb.ToString();
    }

    public virtual void OffLoadContainer()
    {
        Console.WriteLine("Off Loading the Container");
        Weight = 0;
    }
}
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

    public virtual void getInfo()
    {
        string isEmpty = Weight == 0 ? "Container is empty" : "Container is not empty";
        Console.WriteLine("Weight: " + Weight + "\nHeight: " + Height + "\nContainer Weight: " + ContainerWeight +
                          "\nContainer Depth: " + ContainerDepth + "\nMax Capacity: " + MaxCapacity +
                          "\nSerial Number: " + SerialNumber + "\n" + isEmpty);
    }

    public virtual void OffLoadContainer()
    {
        Console.WriteLine("Off Loading the Container");
        Weight = 0;
    }
}
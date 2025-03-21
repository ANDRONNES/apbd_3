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

    public Container(double weight, double height, double containerWeight, double containerDepth, double maxCapacity)
    {
        Weight = weight;
        Height = height;
        ContainerWeight = containerWeight;
        ContainerDepth = containerDepth;
        // _SerialNumber = "KON-"+serialNumber+"-"+ContenerNumber;
        MaxCapacity = maxCapacity;
        ContainerNumber++; 
    }

    public void getInfo()
    {
        Console.WriteLine("Weight: " + Weight + "\nHeight: " + Height + "\nContainer Weight: " + ContainerWeight +
                          "\nContainer Depth: " + ContainerDepth + "\nMax Capacity: " + MaxCapacity + "\nSerial Number: " + SerialNumber);
    }
}
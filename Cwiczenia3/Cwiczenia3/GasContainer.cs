namespace Cwiczenia3;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double weight, double height, double containerWeight, double containerDepth, double maxCapacity)
        : base(weight, height, containerWeight, containerDepth, maxCapacity)
    {
        SetSerialNumber("KON-" + "G" + "-" + ContainerNumber);
    }


    public void Notify()
    {
        Console.WriteLine("Danger in " + GetSerialNumber() + " : You can offload only 95% of gas in the container");
    }

    public void LoadContainer(double loadingGasCapacity)
    {
        if (loadingGasCapacity > MaxCapacity)
        {
            throw new Exception("Gas capacity exceeds " + MaxCapacity);
        }
        else
        {
            Weight = loadingGasCapacity;
        }
    }

    public void OffLoadContainer()
    {
        if (Weight < 0.05 * Weight)
        {
            Notify();
            Weight = 0.05 * Weight;
        }
    }
}
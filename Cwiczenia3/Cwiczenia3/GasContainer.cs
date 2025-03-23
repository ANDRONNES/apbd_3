using System.Text;

namespace Cwiczenia3;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(double height, double containerWeight, double containerDepth, double maxCapacity)
        : base(height, containerWeight, containerDepth, maxCapacity)
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
            throw new OverfillException("container capacity overfilled");
        }
        else
        {
            Weight = loadingGasCapacity;
        }
    }

    public override void OffLoadContainer()
    {
        var temp = Weight;
        base.OffLoadContainer();
        if (Weight < 0.05 * temp)
        {
            Notify();
            Weight = 0.05 * temp;
        }
    }

    /*public override string getInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Gas Container" + base.ToString());
        return sb.ToString();
    }*/
}
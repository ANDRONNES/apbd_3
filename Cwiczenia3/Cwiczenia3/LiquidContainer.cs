using System.Text;

namespace Cwiczenia3;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool _dangerousIndicator = false;

    public LiquidContainer(double height, double containerWeight, double containerDepth,
        double maxCapacity)
        : base(height, containerWeight, containerDepth, maxCapacity)
    {
        SetSerialNumber("KON-" + "L" + "-" + ContainerNumber);
    }


    public void Notify()
    {
        string textMessage = _dangerousIndicator
            ? "You can load only 50% of container capacity"
            : "You can load only 90% of container capacity";
        Console.WriteLine("Danger in " + GetSerialNumber() + ": " + textMessage);
    }

    public void LoadContainer(bool inputDangerousIndicator, double loadingLiquidCapacity)
    {
        if (inputDangerousIndicator)
        {
            _dangerousIndicator = true;
            if (loadingLiquidCapacity > MaxCapacity * 0.5)
            {
                Notify();
                Weight += MaxCapacity * 0.5;
            }
            else
            {
                Weight += loadingLiquidCapacity;
            }
        }
        else
        {
            _dangerousIndicator = false;
            if (loadingLiquidCapacity > MaxCapacity * 0.9)
            {
                Notify();
                Weight += MaxCapacity * 0.9;
            }
            else
            {
                Weight += loadingLiquidCapacity;
            }
        }
    }

    /*public override string getInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Liquid Container" + base.getInfo().ToString());
        string textMessage = _dangerousIndicator ? "Yes" : "No";
        sb.AppendLine("Is liquid dangerous? : " + textMessage);
        return sb.ToString();
    }*/
}
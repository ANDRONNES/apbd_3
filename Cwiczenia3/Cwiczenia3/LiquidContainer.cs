namespace Cwiczenia3;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool _dangerousIndicator = false;

    public LiquidContainer(double weight, double height, double containerWeight, double containerDepth,
        double maxCapacity)
        : base(weight, height, containerWeight, containerDepth, maxCapacity)
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
                Weight = MaxCapacity * 0.5;
            }
            else
            {
                Weight = loadingLiquidCapacity;
            }
        }
        else
        {
            _dangerousIndicator = false;
            if (loadingLiquidCapacity > MaxCapacity * 0.9)
            {
                Notify();
                Weight = MaxCapacity * 0.9;
            }
            else
            {
                Weight = loadingLiquidCapacity;
            }
        }
    }

    public void getInfo()
    {
        base.getInfo();
        string textMessage = _dangerousIndicator? "Yes" : "No";
        Console.WriteLine("Is liquid dangerous? : " + textMessage);
    }
}
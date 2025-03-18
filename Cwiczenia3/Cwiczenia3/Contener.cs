namespace Cwiczenia3;

public class Contener
{
    public static int ContenerNumber = 0;
    private int _Weight { get; set; }
    private int _Height { get; set; }
    private int _ContenerWeight { get; set; }
    private int _ContenerDepth { get; set; }
    private string _SerialNumber { get; set; }
    private int _MaxCapacity { get; set; }
    
    public Contener(int weight, int height, int contenerWeight, int contenerDepth, char serialNumber, int maxCapacity)
    {
        _Weight = weight;
        _Height = height;
        _ContenerWeight = contenerWeight;
        _ContenerDepth = contenerDepth;
        _SerialNumber = "KON-"+serialNumber+"-"+ContenerNumber;
        _MaxCapacity = maxCapacity;
        ContenerNumber++;
    }
}
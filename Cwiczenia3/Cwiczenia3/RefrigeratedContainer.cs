using System.Text;

namespace Cwiczenia3;

public class RefrigeratedContainer : Container
{
    private double refrigeratingTemperature;

    private string? ProductName = null;


    public RefrigeratedContainer(double height, double containerWeight, double containerDepth,
        double maxCapacity, /*string productName,*/ double refrigeratingTemperature)
        : base(height, containerWeight, containerDepth, maxCapacity)
    {
        this.refrigeratingTemperature = refrigeratingTemperature;
        SetSerialNumber("KON-" + "C" + "-" + ContainerNumber);
        // ProductName = possibleProductCheck(productName);
    }


    private Dictionary<string, double> typeAndStoreTemperarureOfPossibleProducts = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 },
    };

    public string possibleProductCheck(string productName)
    {
        foreach (var pair in typeAndStoreTemperarureOfPossibleProducts)
        {
            if (pair.Key == productName)
            {
                if (pair.Value > refrigeratingTemperature)
                {
                    Console.WriteLine("The temperature for this product must be " + pair.Value +
                                      "\nChanging temperature to " + pair.Value);
                    refrigeratingTemperature = pair.Value;
                }

                return pair.Key;
            }
            else
            {
                throw new Exception("Product not allowed");
            }
        }

        return productName;
    }

    public void LoadContainer(string productName)
    {
        if (ProductName == null)
        {
            ProductName = possibleProductCheck(productName);
            Weight += 10;
        }
        else
        {
            if (!productName.Equals(ProductName))
            {
                Console.WriteLine("You cannot ship your product with " + ProductName);
            }

            if (Weight < MaxCapacity)
            {
                Weight += 10;
            }
            else
            {
                Console.WriteLine("The container is full");
            }
        }
    }

    /*public override string getInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Refrigerated Container" + base.ToString());
        sb.AppendLine("Container product type " + ProductName + ", containter temperature " +
                      refrigeratingTemperature + "F. \n");
        return sb.ToString();
    }*/

    public void printPossibleProducts()
    {
        Console.WriteLine("----------------------------");
        Console.WriteLine("Product          Temperature");
        Console.WriteLine("----------------------------");
        foreach (var p in typeAndStoreTemperarureOfPossibleProducts)
        {
            Console.WriteLine($"{p.Key,-15} {p.Value,10:0.00}");
        }
    }

    public override void OffLoadContainer()
    {
        base.OffLoadContainer();
        ProductName = null;
    }
}
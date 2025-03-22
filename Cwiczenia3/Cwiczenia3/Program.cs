using Cwiczenia3;

internal class Program
{
    static void Main(string[] args)
    {
        LiquidContainer l1 = new LiquidContainer(200, 150, 250, 400);
        LiquidContainer l2 = new LiquidContainer(200, 150, 250, 300);
        LiquidContainer l3 = new LiquidContainer(200, 150, 250, 300);
        l1.getInfo();
        l1.LoadContainer(true, 200);
        l1.getInfo();

        RefrigeratedContainer r1 = new RefrigeratedContainer(200, 150, 250, 400, -15);
        r1.getInfo();
        r1.LoadContainer("Bananas");
        r1.getInfo();
        r1.LoadContainer("Eggs");
        r1.getInfo();

        GasContainer g1 = new GasContainer(200, 150, 250, 400);
        // g1.LoadContainer(450);
        g1.LoadContainer(400);
        g1.getInfo();
        g1.OffLoadContainer();
        g1.getInfo();
        ContainerShip cs1 = new ContainerShip(100, 3, 1);
        cs1.getInfo();
        cs1.AddContainer(l1);
        cs1.getInfo();
        Console.WriteLine(cs1.GetContainerWeightLeft());
        cs1.AddContainers(new List<Container>() { l2, l3 });
        cs1.getInfo();
        cs1.RemoveContainer(l1);
        cs1.getInfo();
        // cs1.swapContainers(l1.GetSerialNumber(),g1);
        cs1.AddContainer(l1);
        cs1.swapContainers(l1.GetSerialNumber(), g1);
        cs1.getInfo();
        ContainerShip cs2 = new ContainerShip(100, 3, 1);
        cs1.MoveContainers(g1.GetSerialNumber(), cs2);
        cs2.getInfo();
        cs1.getInfo();
    }
}
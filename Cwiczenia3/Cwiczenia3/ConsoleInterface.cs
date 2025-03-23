namespace Cwiczenia3;

public class ConsoleInterface
{
    List<ContainerShip> containerShips = new List<ContainerShip>();

    List<Container> containers = new List<Container>();

    public ConsoleInterface()
    {
        start();
    }

    public void start()
    {
        string lineForShip = containerShips.Count == 0 ? "Brak" : getInfoForShips();
        Console.WriteLine("Lista kontenerowców: \n" + lineForShip + "\n");
        string lineForContainer = containers.Count == 0 ? "Brak" : getInfoForContainers();
        Console.WriteLine("Lista kontenerów: \n" + lineForContainer + "\n");
        Console.WriteLine("Możliwe akcje:");
        Console.WriteLine("1. Dodaj kontenerowiec:");
        Console.WriteLine("2. Usun kontenerowiec:");
        Console.WriteLine("3. Dodaj kontener");
        Console.WriteLine("4. Exit");

        string option = Console.ReadLine();
        if (option.Equals("1")) addShip();
        else if (option.Equals("2")) removeShip();
        else if (option.Equals("3")) addContainer();
        else if (option.Equals("4")) Environment.Exit(0);
        else Console.WriteLine("Niepoprawna opcja");
    }

    public void addContainer()
    {
        Console.WriteLine("Podaj typ kontenera: ");
        Console.WriteLine("1.Gas");
        Console.WriteLine("2.Liquid");
        Console.WriteLine("3.Chlodzacy");
        Console.WriteLine("4. Exit");
        string option = Console.ReadLine();
        if (option.Equals("1"))
        {
            Console.WriteLine("Podaj parametry kontenera (wysokosc, waga kontenera, glebokosc, max pojemnosc):");
            string parameters = Console.ReadLine();
            if (parameters != null)
            {
                string[] parametersArray = parameters.Split(',');
                containers.Add(new GasContainer(int.Parse(parametersArray[0]), int.Parse(parametersArray[1]),
                    int.Parse(parametersArray[2]), int.Parse(parametersArray[3])));
                start();
            }
        }
        else if (option.Equals("2"))
        {
            Console.WriteLine("Podaj parametry kontenera (wysokosc, waga kontenera, glebokosc, max pojemnosc):");
            string parameters = Console.ReadLine();
            if (parameters != null)
            {
                string[] parametersArray = parameters.Split(',');
                containers.Add(new LiquidContainer(int.Parse(parametersArray[0]), int.Parse(parametersArray[1]),
                    int.Parse(parametersArray[2]), int.Parse(parametersArray[3])));
                start();
            }
        }
        else if (option.Equals("3"))
        {
            Console.WriteLine(
                "Podaj parametry kontenera (wysokosc, waga kontenera, glebokosc, max pojemnosc, temperature):");
            string parameters = Console.ReadLine();
            if (parameters != null)
            {
                string[] parametersArray = parameters.Split(',');
                containers.Add(new RefrigeratedContainer(int.Parse(parametersArray[0]), int.Parse(parametersArray[1]),
                    int.Parse(parametersArray[2]), int.Parse(parametersArray[3]), int.Parse(parametersArray[4])));
                start();
            }
        }
        else if (option.Equals("4")) Environment.Exit(0);
    }

    public void removeShip()
    {
        Console.WriteLine("Podaj numer kontenerowca do usunięcia:");
        string number = Console.ReadLine();
        if (number != null)
        {
            containerShips.RemoveAt(int.Parse(number) - 1);
            start();
        }
        else
        {
            Console.WriteLine("Niepoprawny numer");
            start();
        }
    }

    public void addShip()
    {
        Console.WriteLine("Podaj parametry kontenerowca (prędkość, ilość kontenerów, waga kontenerów):");
        string parameters = Console.ReadLine();
        if (parameters != null)
        {
            string[] parametersArray = parameters.Split(',');
            containerShips.Add(new ContainerShip(int.Parse(parametersArray[0]), int.Parse(parametersArray[1]),
                int.Parse(parametersArray[2])));
            start();
        }
        else
        {
            Console.WriteLine("Niepoprawne parametry");
            start();
        }
    }

    public string getInfoForShips()
    {
        string? resultString = null;
        for (int i = 0; i < containerShips.Count; i++)
        {
            resultString += ("Statek " + (i + 1) + " (" + containerShips[i].getInfo() + ")");
        }

        return resultString;
    }

    public string getInfoForContainers()
    {
        string? resultString = null;
        for (int i = 0; i < containers.Count; i++)
        {
            resultString += ("Container " + (i + 1) + " (" + containers[i].getInfo() + ")");
        }

        return resultString;
    }
}
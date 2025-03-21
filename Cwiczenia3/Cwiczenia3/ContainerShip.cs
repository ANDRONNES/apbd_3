namespace Cwiczenia3;

public class ContainerShip
{
    List<Container> containers = new List<Container>();
    private int maxSpeed;
    private int maxContainersCount;
    private double maxContainersWeight;
    private double containerWeightLeftKG;
    private int containersCount = 0;

    public double GetContainerWeightLeft() => containerWeightLeftKG;
    public int GetContainerCount() => containersCount;
    public int GetMaxContainerCount() => maxContainersCount;

    public ContainerShip(int maxSpeed, int maxContainersCount, double maxContainersWeight)
    {
        this.maxSpeed = maxSpeed;
        this.maxContainersCount = maxContainersCount;
        this.maxContainersWeight = maxContainersWeight;
        this.containerWeightLeftKG = maxContainersWeight * 1000;
    }

    public void AddContainer(Container container)
    {
        if (((container.GetWeight() + container.GetContainerWeight()) > containerWeightLeftKG) ||
            containersCount > maxContainersCount)
        {
            throw new Exception("Container cannot be added. The ship is full");
        }
        else
        {
            containers.Add(container);
            containersCount++;
            containerWeightLeftKG -= container.GetWeight() + container.GetContainerWeight();
            ;
        }
    }

    public void AddContainers(List<Container> containers)
    {
        foreach (Container container in containers)
        {
            if (((container.GetWeight() + container.GetContainerWeight()) > containerWeightLeftKG) ||
                containersCount > maxContainersCount)
            {
                throw new Exception("Container cannot be added. The ship is full");
            }
            else
            {
                containers.Add(container);
                containersCount++;
                containerWeightLeftKG -= container.GetWeight() + container.GetContainerWeight();
                ;
            }
        }
    }

    public void RemoveContainer(Container container)
    {
        if (containers.Contains(container))
        {
            containers.Remove(container);
            containersCount--;
            containerWeightLeftKG += container.GetWeight() + container.GetContainerWeight();
            ;
        }
        else
        {
            throw new Exception("Container cannot be removed. There is no this container");
        }
    }

    public void swapContainers(string ContainerSerialNumber, Container secondContainer)
    {
        foreach (Container container in containers)
        {
            if (container.GetSerialNumber().Equals(ContainerSerialNumber))
            {
                containerWeightLeftKG += container.GetWeight() + container.GetContainerWeight();
                if (secondContainer.GetWeight() + secondContainer.GetContainerWeight() > containerWeightLeftKG)
                {
                    containerWeightLeftKG -= container.GetWeight() + container.GetContainerWeight();
                    throw new Exception("Containers cannot be swapped. The container is too heavy");
                }
                else
                {
                    containers.Remove(container);
                    containersCount--;
                    containerWeightLeftKG += container.GetWeight() + container.GetContainerWeight();
                    ;
                    containers.Add(secondContainer);
                    containersCount++;
                    containerWeightLeftKG -= container.GetWeight() + container.GetContainerWeight();
                    ;
                }
            }
            else
            {
                throw new Exception("Container cannot be swapped. There is no container which you want to swap");
            }
        }
    }

    public void MoveContainers(string containerSerialNumber, ContainerShip anotherShip)
    {
        foreach (var container in containers)
        {
            if (container.GetSerialNumber().Equals(containerSerialNumber))
            {
                /*if (container.GetContainerWeight() + container.GetWeight() > anotherShip.GetContainerWeightLeft()
                    || anotherShip.GetContainerCount() >= anotherShip.GetMaxContainerCount())
                {
                    throw new Exception("Container cannot be moved. The ship is full");
                }
                else
                {
                    anotherShip.AddContainer(container);
                }*/
                anotherShip.AddContainer(container);
            }
            else
            {
                throw new Exception("Container cannot be moved. There is no container which you want to move");
            }
        }
    }

    public void getInfo()
    {
        Console.WriteLine("Max speed of ship: " + maxSpeed + " knots, Max containers count: "
                          + maxContainersCount + " containers, Current containers on ship " + containersCount + 
                          " Max containers weight: " + maxContainersWeight + "ton");
    }
}
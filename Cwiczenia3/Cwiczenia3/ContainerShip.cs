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

    public void AddContainers(List<Container> containerss)
    {
        for (int i = 0; i < containerss.Count; i++)
        {
            if (((containerss[i].GetWeight() + containerss[i].GetContainerWeight()) > containerWeightLeftKG) ||
                containersCount >= maxContainersCount)
            {
                throw new Exception("Container cannot be added. The ship is full");
            }
            else
            {
                containers.Add(containerss[i]);
                containersCount += 1;
                containerWeightLeftKG -= containerss[i].GetWeight() + containerss[i].GetContainerWeight();
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
        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].GetSerialNumber().Equals(ContainerSerialNumber))
            {
                containerWeightLeftKG += containers[i].GetWeight() + containers[i].GetContainerWeight();
                if (secondContainer.GetWeight() + secondContainer.GetContainerWeight() > containerWeightLeftKG)
                {
                    containerWeightLeftKG -= containers[i].GetWeight() + containers[i].GetContainerWeight();
                    throw new Exception("Containers cannot be swapped. The container is too heavy");
                }
                else
                {
                    containerWeightLeftKG += containers[i].GetWeight() + containers[i].GetContainerWeight();
                    containers.Remove(containers[i]);
                    containersCount--;

                    containers.Add(secondContainer);
                    containersCount++;
                    containerWeightLeftKG -= secondContainer.GetWeight() + secondContainer.GetContainerWeight();
                }
            }
        }

        if (!containers.Contains(secondContainer))
        {
            throw new Exception("Container cannot be swapped. There is no container which you want to swap");
        }
    }

    public void MoveContainers(string containerSerialNumber, ContainerShip anotherShip)
    {
        for (int i = 0; i < containers.Count; i++)
        {
            if (containers[i].GetSerialNumber().Equals(containerSerialNumber))
            {
                anotherShip.AddContainer(containers[i]);
                containers.RemoveAt(i);
            }
        }

        if (containers.Count == containersCount)
        {
            throw new Exception("Containers cannot be moved. There is no container which you want to move");
        }
        else
        {
            containersCount--;
        }
    }

    public string getInfo()
    {
        return "speed: " + maxSpeed + " knots, maxContainerNum: "
                + maxContainersCount + " containers, Current num of containers on ship: " + containersCount +
                ",  maxWeight: " + maxContainersWeight + "ton";
    }
}
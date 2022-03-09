namespace laby1
{
  public class Tank
  {
    private int _level;
    public int Capacity { get; private set; }
    public Tank(int capacity)
    {
      Capacity = capacity;
    }
    public int Level
    {
      get
      {
        return _level;
      }
      private set
      {
        if (value < 0 || value > Capacity)
        {
          throw new System.ArgumentOutOfRangeException("Tank value out of capacity range");
        }

        _level = value;
      }
    }
    public bool refuel(int amount)
    {
      if (amount < 0)
      {
        return false;
      }
      if (_level + amount > Capacity)
      {
        return false;
      }
      _level += amount;
      return true;
    }

    public bool consume(int amount)
    {
      if (amount < 0)
      {
        return false;
      }
      if (_level - amount > 0)
      {
        return false;
      }
      _level -= amount;
      return true;
    }

    public bool refuel(Tank sourceTank, int amount)
    {
      if (amount < 0)
      {
        return false;
      }
      if (_level + amount < Capacity && sourceTank._level - amount < 0)
      {
        return false;
      }
      _level += amount;
      sourceTank.consume(amount);
      return true;
    }

  }
}
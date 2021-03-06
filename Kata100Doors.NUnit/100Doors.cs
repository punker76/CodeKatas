namespace HundredDoorsKata {
  using System;
  using System.Linq;

  public class Floor {
    private Door[] _doors;

    public Floor() : this(100) {}

    public Floor(int doorCount) {
      _doors = Enumerable.Range(1, doorCount)
        .Select(i => new Door())
        .ToArray();
    }

    public Door[] GetDoors() {
      return _doors; 
    }

    public Door GetDoor(int doorNumber) {
      return _doors[doorNumber - 1];
    }
  }

  public class Door {
    public Door() {
      IsClosed = true;
    }

    public bool IsClosed { get; set; }
    public bool IsOpen { get { return !IsClosed; } set { IsClosed = !value; } }
  }

  public class Monkey {
    private int _number = 1;
    public Monkey(int number) {
      _number = number;
    }

    public void RunThrough(Floor floor) {
      int doorNumber = 0;
      foreach (Door door in floor.GetDoors()) {
        if (++doorNumber % _number == 0)  
          door.IsOpen = door.IsClosed;
      }
    }
  }
}

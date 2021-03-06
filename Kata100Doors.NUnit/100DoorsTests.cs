namespace HundredDoorsKata {
  using System;
  using System.Linq;
  using NUnit.Framework;

  [TestFixture]
  public class Monkey_RunThrough_Tests {
    [Test]
    public void Given_doors_are_closed_when_first_monkey_runs_through_floor_then_all_doors_are_open() {
      Floor floor = new Floor();
      Monkey monkey = new Monkey(1);
      monkey.RunThrough(floor);
      Door[] doors = floor.GetDoors();
      Assert.That(doors.All(door => door.IsOpen));
    }

    [Test]
    public void Given_4_closed_doors_when_second_monkey_runs_through_floor_then_monkey_opens_only_every_second_door() {
      Floor floor = new Floor(4);
      Monkey monkey = new Monkey(2);
      monkey.RunThrough(floor);
      Door[] doors = floor.GetDoors();
      Assert.That(doors.Where((door, index) => (index + 1) % 2 == 0).All(door => door.IsOpen));
      Assert.That(doors.Where((door, index) => (index + 1) % 2 != 0).All(door => door.IsClosed));
    }

    [Test]
    public void Given_an_open_and_a_closed_door_when_a_monkey_runs_through_floor_then_monkey_opens_closed_and_closes_opened_door() {
      Floor floor = new Floor(2);
      floor.GetDoor(2).IsOpen = true;

      Monkey monkey = new Monkey(1);
      monkey.RunThrough(floor);
      Assert.That(floor.GetDoor(1).IsOpen);
      Assert.That(floor.GetDoor(2).IsClosed);
    }

    [Test]
    public void Given_6_closed_doors_when_third_monkey_runs_through_floor_then_monkey_opens_only_every_third_door() {
      Floor floor = new Floor(6);

      Monkey monkey = new Monkey(3);
      monkey.RunThrough(floor);
      Assert.That(floor.GetDoor(3).IsOpen);
      Assert.That(floor.GetDoor(6).IsOpen);
      Assert.That(floor.GetDoors().Where((door, index) => (index + 1) % 3 != 0).All(door => door.IsClosed));
    }
  }

  [TestFixture]
  public class DoorTests {
    [Test]
    public void When_Door_Is_Closed_Then_Door_Is_Not_Open() {
      Assert.That(!new Door{IsClosed = true}.IsOpen);
    }

    [Test]
    public void When_Door_Is_Not_Closed_Then_Door_Is_Open() {
      Assert.That(new Door{IsClosed = false}.IsOpen);
    }
  }

  [TestFixture]
  public class Floor_GetDoor_Tests {
    [Test]
    public void When_Floor_Has_1_Door_Then_Returns_Door_For_Number_1() {
      var floor = new Floor(1);
      Assert.That(floor.GetDoor(1) != null);
    }
  }

  [TestFixture]
  public class Floor_Tests {
    [Test]
    public void Given_a_new_floor_all_doors_are_closed() {
      Floor floor = new Floor();
      Door[] doors = floor.GetDoors();
      Assert.That(doors.All(door => door.IsClosed));
    }
  }
}

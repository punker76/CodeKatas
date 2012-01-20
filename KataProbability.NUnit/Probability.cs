namespace Kata {
  using System;

  public class Probability
    : IEquatable<Probability> {
    decimal value;
    
    public Probability(decimal value) {
      this.value = value;
    }

    public Probability InverseOf() {
      return new Probability(1 - value);
    }

    public Probability CombineWith(Probability other) {
      return null;
    }

    public bool Equals(Probability other) {
      return other != null && other.value.Equals(value);
    }

    public override bool Equals(object other) {
      return Equals(other as Probability);
    }

    public override int GetHashCode() {
      return value.GetHashCode();
    }
  }
}

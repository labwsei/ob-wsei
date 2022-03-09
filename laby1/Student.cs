namespace laby1
{
  public class Student : System.IEquatable<Student>, System.IComparable<Student>
  {
    public Student(string nazwisko, string imie, decimal avg)
    {
      this.Nazwisko = nazwisko;
      this.Imie = imie;
      this.Średnia = avg;

    }
    public override string ToString()
    {
      return $"N: {Nazwisko} I: {Imie} ";
    }
    public string Nazwisko { get; set; }
    public string Imie { get; set; }
    public decimal Średnia { get; set; }

    public bool Equals(Student other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return Imie.Equals(other.Imie) && Nazwisko.Equals(other.Nazwisko) && Średnia.Equals(other.Średnia);
    }
    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Student)obj);
    }

    public override int GetHashCode()
    {
      return System.HashCode.Combine(Nazwisko, Imie, Średnia);
    }

    public int CompareTo(Student other)
    {
      if (ReferenceEquals(this, other)) return 0;
      if (ReferenceEquals(null, other)) return 1;
      var imieC = Imie.CompareTo(other.Imie);
      var avgC = Średnia.CompareTo(other.Średnia);
      if (imieC != 0) return imieC;
      if (avgC != 0) return avgC;
      return Nazwisko.CompareTo(other.Nazwisko);
    }
  }
}
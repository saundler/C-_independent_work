using System.Runtime.Serialization;

[DataContract]
internal class Meat : Ingredient
{
    [DataMember]
    public bool IsTasty { get; set; }
    public Meat(string name, int timeToCook, bool isTasty) : base(name, timeToCook) => IsTasty = isTasty;
}
using System;
using System.Runtime.Serialization;

[DataContract]
internal class Penalty
{
    [DataMember(Name = "car_number")]
    public int CarNumber { get; set; }
    [DataMember(Name = "cost")]
    public int Cost { get; set; }
    public Penalty(int carNumber, int cost)
    {
        CarNumber = carNumber;
        Cost = cost;
    }
}
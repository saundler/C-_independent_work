using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[DataContract]
internal class Camera
{
    [DataMember(Name = "id")]
    public int Id { get; set; }
    public int MaxSpeed { get; set; }
    [DataMember(Name = "penalties")]
    public List<Penalty> Penalties { get; set; } = new List<Penalty>();
    public Camera(int id, int maxSpeed)
    {
        Id = id;
        MaxSpeed = maxSpeed;
    }
}
using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

[DataContract]
internal class RoadCenter : ITrackingCenter
{
    [DataMember(Name = "cameras")]
    List<Camera> cameras = new List<Camera>();
    public void AddCamera(int id, int maxSpeed)
    {
        cameras.Add(new Camera(id, maxSpeed));
    }
    public void CheckCarSpeed(int forCameraId, int carNumber, int carSpeed)
    {
        int index = cameras.FindIndex(camera => camera.Id == forCameraId);
        if(index > -1 && cameras[index].MaxSpeed < carSpeed)
        {
            cameras[index].Penalties.Add(new Penalty(carNumber, (carSpeed - cameras[index].MaxSpeed) * 100));
        }
    }
    public void GetData(string inFilePath)
    {
        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(RoadCenter));
        using (FileStream fs = new FileStream(inFilePath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            serializer.WriteObject(fs, this);
        }
    }
}
using System;
using System.Collections.Generic;

internal class MessageQueue
{
    public List<Message> Queue = new List<Message>();
    public int QueueSize { get; set; }
    public int Size { get; set; }
    public MessageQueue(int queueSize)
    {
        QueueSize = queueSize;
        Kafka.pusher = Push;
        Kafka.GetMessages = (int x, int y) => { return this[x, y]; };
        Size = 0;
    }
    public void Push(Message message)
    {
        if(Queue.Count + 1 > QueueSize)
        {
            throw new KafkaException("Queue is out of storage");
        }
        Queue.Add(message);
        Size++;
    }
    public Message this[int index]
    {
        get { return Queue[index]; }
        set { Queue[index] = value; }
    }
    public List<Message> this[int from ,int to]
    {
        get 
        { 
            List<Message> list = new List<Message>();
            int t = to - from;
            while (t > 0)
            {
                list.Add(Queue[from]);
                Queue.Remove(Queue[from]);
                t--;
                --Size;
            }
            return list;
        }
    }
}

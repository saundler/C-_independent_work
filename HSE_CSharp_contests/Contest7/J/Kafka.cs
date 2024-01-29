using System;
using System.Collections.Generic;

internal class Kafka
{
    public static Action<Message> pusher;
    public static Func<int,int,List<Message>> GetMessages;
    List<User> users = new List<User>();
    public bool active { get; set; }
    MessageQueue queue;
    public Kafka(int queueSize)
    {
        queue = new MessageQueue(queueSize);
    }
    public void Subscribe(User user)
    {
        if (!active)
            throw new KafkaException("Kafka is not active");
        if (users.Contains(user))
            throw new KafkaException("User is already subscribed");
        
        users.Add(user);
    }
    public void Unsubscribe(User user)
    {
        if (!active)
            throw new KafkaException("Kafka is not active");
        if (!users.Contains(user))
            throw new KafkaException("User is already unsubscribed");
        users.Remove(user);
    }

    public void Push(Message message)
    {
        if (!active)
            throw new KafkaException("Kafka is not active");
        pusher?.Invoke(message);
    }
    public List<Message> PopMessages(User user, int count)
    {
        if (!users.Contains(user))
            throw new KafkaException("User is not subscribed");
        if (count + user.Index > queue.Size)
            throw new KafkaException("Not enough messages");
        if (!active)
            throw new KafkaException("Kafka is not active");
        List<Message> messages = queue[user.Index, user.Index + count];
        user.IncreaseIndex(count);
        return messages;
    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        if (!active)
            throw new KafkaException("Kafka is not active");
        active = false;
    }
}
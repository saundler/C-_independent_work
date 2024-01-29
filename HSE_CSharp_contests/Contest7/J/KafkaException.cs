using System;
internal class KafkaException : Exception
{
    public KafkaException(string message) : base(message) { }
}
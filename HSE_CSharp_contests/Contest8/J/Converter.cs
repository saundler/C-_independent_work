using System;

internal class Converter : IConverter<MessageNetwork, MessageDb>
{
    public MessageDb Convert(MessageNetwork obj)
    {
        return new MessageDb(obj.Id, String.Join("", obj.Content.Split(" ")), String.Join("" ,obj.ImageNetwork.Url.Split(" ")));
    }
}
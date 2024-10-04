namespace Test.Cross.Messages;

public abstract class Message
{
    public string MessageType { get; protected set; }

    protected Message()
    {
        MessageType = GetType().Name;
    }
}

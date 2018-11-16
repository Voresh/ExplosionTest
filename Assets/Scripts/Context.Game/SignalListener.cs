namespace Context.Game
{
    public interface ISignalListener<T> where T : struct
    {
        void SignalFired(T signal);
    }
}
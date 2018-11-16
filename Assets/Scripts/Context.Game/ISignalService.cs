namespace Context.Game
{
    public interface ISignalService
    {
        void FireSignal<T>(T signal) where T : struct;
    }
}
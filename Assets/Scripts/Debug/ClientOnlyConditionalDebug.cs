using System.Diagnostics;

namespace Debug
{
    //todo: можно еще сделать дебаггер сервис у которого реализации могут писать логи как на клиент, так в любое другое место
    public static class ClientOnlyConditionalDebug
    {
        [Conditional("ENABLE_LOGS")]
        public static void Log(object obj)
        {
            UnityEngine.Debug.Log(obj);
        }

        [Conditional("ENABLE_LOGS")]
        public static void LogWarning(object obj)
        {
            UnityEngine.Debug.LogWarning(obj);
        }

        [Conditional("ENABLE_LOGS")]
        public static void LogError(object obj)
        {
            UnityEngine.Debug.LogError(obj);
        }
    }
}
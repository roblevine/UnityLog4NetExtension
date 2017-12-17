using Unity.Policy;

namespace UnityLog4NetExtension.Utils
{
    public static class PolicyListExtensions
    {
        public static T Get<T>(this IPolicyList policyList, object buildKey, bool localOnly)
        {
            return (T) policyList.Get(typeof(T), buildKey, localOnly);
        }
    }
}
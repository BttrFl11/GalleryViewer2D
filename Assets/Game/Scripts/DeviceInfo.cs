public class DeviceInfo
{
    public static bool IsMobile
    {
        get
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            return false;
#else
            return true;
#endif
        }
    }
}

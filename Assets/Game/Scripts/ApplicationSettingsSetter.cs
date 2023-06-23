using UnityEngine;

public class ApplicationSettingsSetter : MonoBehaviour
{
    [SerializeField] private bool _allowAutorotate;

    private void Awake()
    {
        ScreenOrientation orientation = _allowAutorotate ? ScreenOrientation.AutoRotation : ScreenOrientation.Portrait;
        Screen.orientation = orientation;
    }
}
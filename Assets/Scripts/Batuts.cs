using UnityEngine;

public class Batuts : MonoBehaviour
{
    public bool isPassed { get => Platform; }
    private bool Platform = false;
    public void IsPlatformTrigger()
    {
        Platform = true;
    }
}

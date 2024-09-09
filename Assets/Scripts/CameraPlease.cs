using UnityEngine;

public class CameraPlease : MonoBehaviour
{
    private const float _movementSpeed = 2.0f;
    private Transform TargetTr;
    private Vector3 _originOffset;

    void Start()
    {
        _originOffset = transform.position;    
    }

    void Update()
    {
        if (TargetTr == null) 
            return;
        transform.position = Vector2.Lerp(transform.position, TargetTr.position, Time.deltaTime * _movementSpeed);
        transform.position = new Vector3(transform.position.x, TargetTr.position.y, _originOffset.z);
    }
    public void SetTarget(Transform tr) 
        { TargetTr = tr; }
}

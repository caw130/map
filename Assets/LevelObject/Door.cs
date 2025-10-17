using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    // it will be Deleted
    [SerializeField] bool button;
   
    [SerializeField] float _doorTime;
    [SerializeField] Ease _doorEase;

    bool _isopening = false;
    bool _doorOpen = false;

    void Update()
    {
        if(_doorOpen != button && !_isopening)
        {
            DoorOpen();
        }
    }

    void DoorOpen()
    {
        if (_isopening) return;
        _isopening = true;
        Vector3 rotate = transform.rotation.eulerAngles;
        _doorOpen = !_doorOpen;
        if (_doorOpen)
        {
            rotate.y += 90;
        }
        else
        {
            rotate.y -= 90;
        }
        transform.DORotate(rotate, _doorTime).SetEase(_doorEase)
            .OnComplete(() => _isopening = false
            );
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}

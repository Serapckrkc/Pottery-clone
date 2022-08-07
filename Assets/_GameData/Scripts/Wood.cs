using DG.Tweening;
using UnityEngine;

public class Wood : MonoBehaviour
{
    [SerializeField] private Transform woodTransform;
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private float rotationDuration;

    private void Start()
    {
        woodTransform.DOLocalRotate(rotationVector, rotationDuration, RotateMode.FastBeyond360)
       .SetLoops(-1, LoopType.Restart)
       .SetEase(Ease.Linear);
    }
}

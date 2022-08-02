using UnityEngine;

namespace Points
{
    [RequireComponent(typeof(PointControl))]
    public class CheckingObjectsTypeOnPoint : MonoBehaviour
    {
        [SerializeField] private PointControl _leftPoint;
        [SerializeField] private PointControl _rightPoint;

        private void OnEnable()
        {
            _leftPoint.OnCheck += Checker;
            _rightPoint.OnCheck += Checker;
        }

        private void OnDisable()
        {
            _leftPoint.OnCheck -= Checker;
            _rightPoint.OnCheck -= Checker;
        }

        private void Checker()
        {
            if (_leftPoint.ObjectType != null && _rightPoint.ObjectType != null)
            {
                if (_leftPoint.ObjectType == _rightPoint.ObjectType)
                {
                    Destroy(_leftPoint.Object);
                    Destroy(_rightPoint.Object);
                }
            }
        }
    }
}
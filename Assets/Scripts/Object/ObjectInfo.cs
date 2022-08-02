using UnityEngine;

namespace Object
{
    [CreateAssetMenu(fileName = "New Object", menuName = "ScriptableObject/ObjectComponent")]
    public class ObjectInfo : ScriptableObject
    {
        [SerializeField] private string _index;
        [SerializeField] private Color _color;
        
        public string Index => _index;
        public Color Color => _color;
    }
}
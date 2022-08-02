using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Object
{
    [RequireComponent(typeof(Rigidbody), typeof(MeshFilter), typeof(MeshRenderer))]
    public class ObjectExample : MonoBehaviour
    {
        public string ObjectIndex { get; private set; }

        [SerializeField] private List<ObjectInfo> _objectInfo;
        [SerializeField] private Mesh[] _myMesh = new Mesh[2];
        private int _randomIndex;
        private MeshFilter _meshFilter;
        private Renderer _renderer;


        private void Initialize()
        {
            _meshFilter = gameObject.GetComponent<MeshFilter>();
            _renderer = gameObject.GetComponent<Renderer>();
            _randomIndex = Random.Range(0, _objectInfo.Count);
            ObjectIndex = _objectInfo[_randomIndex].Index;
            var rotate = Random.Range(-180, 180);
            gameObject.transform.rotation = new Quaternion(rotate, rotate, rotate, rotate);
        }

        private void Start()
        {
            Initialize();
            gameObject.AddComponent<BoxCollider>();
            _meshFilter.mesh = _myMesh[_randomIndex];
            _renderer.material.color = _objectInfo[_randomIndex].Color;
        }
    }
}
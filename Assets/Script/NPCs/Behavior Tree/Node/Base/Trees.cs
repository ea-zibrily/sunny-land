using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunny.NPCs
{
    public abstract class Trees : MonoBehaviour
    {
        private Node _root = null;

        private void Awake()
        {
            InitOnAwake();
        }

        protected void Start()
        {
            _root = SetupTree();
            InitOnStart();
        }

        private void Update()
        {
            if (_root != null)
                _root.Evaluate();
        }

        protected virtual void InitOnAwake() { }
        protected virtual void InitOnStart() { }
        protected abstract Node SetupTree();

    }

}

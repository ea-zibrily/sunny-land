using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sunny.NPCs
{
    public class DinoBT : Trees
    {
        [Serializable]
        public struct SpaceData
        {
            public SpaceType Type;
            public float Radius;
        }

        [Header("Movement")]
        [SerializeField] private Transform targetPoint;
        public bool CanMove;
        private Transform _originPoint;

        [Header("Area")]
        [SerializeField] private SpaceData[] spaceDatas;
        [SerializeField] private LayerMask targetMask;
        public SpaceData[] SpaceDatas => spaceDatas;

        // Neccesary
        public bool AnyTaskIsRunning { get; set; }

        // Reference
        private DinoController _dinoController;

        protected override void InitOnAwake()
        {
            base.InitOnAwake();
            _dinoController = GetComponent<DinoController>();
        }
        
        protected override void InitOnStart()
        {
            base.InitOnStart();
            _originPoint = transform;
        }
        
        protected override Node SetupTree()
        {     
            Node root = new Selector(new List<Node>
            {
                new Sequence(new List<Node>
                {
                    new CheckTargetInRange(spaceDatas[1].Radius, transform, targetMask),
                    new TaskGoToTarget(transform),
                    new Sequence(new List<Node>
                    {
                        new CheckReachTarget(_dinoController, isOrigin: false),
                        new TaskGetFruit(_dinoController)
                    }),
                }),
                new TaskIdle(_dinoController)
            });
            
            return root;
        }
        // protected override Node SetupTree()
        // {     
        //     Node root = new Selector(new List<Node>
        //     {
        //         new Sequence(new List<Node>
        //         {
        //             new CheckTargetInRange(spaceDatas[1].Radius, transform, targetMask),
        //             new TaskMove(_dinoController),
        //             new Sequence(new List<Node>
        //             {
        //                 new CheckReachTarget(_dinoController, isOrigin: false),
        //                 new TaskGetFruit(_dinoController)
        //             }),
        //         }),
        //         new TaskIdle(_dinoController)
        //     });
            
        //     return root;
        // }
    }
}
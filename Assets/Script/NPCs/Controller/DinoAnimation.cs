using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sunny.NPCs
{
    public class DinoAnimation : MonoBehaviour
    {
        #region Fields & Properties

        private int _currentState;

        // Cached properties
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Walk = Animator.StringToHash("Walk");

        // Reference
        private DinoController _dinoController;
        private Animator _dinoAnim;

        #endregion
         
        #region Unity Methods
            
        private void Awake()
        {
            _dinoController = GetComponentInParent<DinoController>();
            _dinoAnim = GetComponent<Animator>();
        }

        private void Update()
        {
            AnimationStateHandler();
        }

        #endregion

        #region  Methods
        
        private void AnimationStateHandler()
        {
            var state = GetState();

            if (state == _currentState) return;
            _dinoAnim.CrossFade(state, 0, 0);
            _currentState = state;
        }
        
        private int GetState()
        {
            var dinoState = _dinoController.DinoState;
            return dinoState switch
            {
                DinoState.Idle => Idle,
                DinoState.Walk => Walk,
                _ => throw new InvalidOperationException("Invalid NPCs State!")
            };
        }

        #endregion
    }
}

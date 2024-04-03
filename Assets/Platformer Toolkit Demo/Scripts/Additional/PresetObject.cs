using MyBox;
using System;
using UnityEngine;

namespace GMTK.PlatformerToolkit
{
    [CreateAssetMenu(menuName = "GMTK/Character Movement Preset", fileName = " - Character Movement Preset")]
    public class PresetObject : ScriptableObject
    {
        public Action OnValidated;

        #region Base
        [SerializeField]
        [ReadOnly]
        [Foldout("Base", true)]
        private string _presetName;

        [SerializeField]
        private bool _liveUpdate = true;
        #endregion
        
        #region Ground
        [Foldout("Ground", true)]
        [SerializeField][Range(0f, 20f)][Tooltip("Maximum movement speed")]
        private float _topSpeed = 9f;

        [SerializeField, Range(0f, 100f)][Tooltip("How fast to stop when changing direction")] 
        private float _turnSpeed = 75f;

        [SerializeField][Tooltip("When false, the charcter will skip acceleration and deceleration and instantly move and stop")]
        private bool _useAcceleration = true;

        [ReadOnly(nameof(_useAcceleration),true)]
        [SerializeField][Range(0f, 100f)][Tooltip("How fast to reach max speed")]
        private float _acceleration = 10f;

        [ReadOnly(nameof(_useAcceleration), true)]
        [SerializeField][Range(0f, 100f)][Tooltip("How fast to stop after letting go")]
        private float _deceleration = 5f;

        #endregion

        #region Jump

        [SerializeField]
        [Foldout("Jump", true)]
        private float _jumpHeight = 2.25f;

        [SerializeField]
        private float _timeToApex = 0.38f;

        [SerializeField]
        private float _downwardMovementMultiplier = 5f;

        [SerializeField]
        [Foldout("Jump", true)]
        private bool _variableJumpHeight = false;

        [SerializeField]
        private float _jumpCutoff = 5.23f;

        [SerializeField]
        [OverrideLabel("Max air Jumps")]
        private int _doubleJump = 0;

        #endregion

        #region Air

        [SerializeField, Range(0f, 100f)]
        [Tooltip("How fast to reach max speed when in mid-air")]
        [Foldout("Air Control", true)]
        private float _airAcceleration = 80f;

        [SerializeField, Range(0f, 100f)]
        [Tooltip("How fast to stop when changing direction when in mid-air")]
        private float _airTurnSpeed = 80f;

        [SerializeField, Range(0f, 100f)]
        [Tooltip("How fast to stop in mid-air when no direction is used")]
        private float _airDecceleration = 80f;

        #endregion

        #region Juice

        [Foldout("Squash and Stretch", true)]
        [SerializeField, Tooltip("Width Squeeze, Height Squeeze, Duration")]
        private Vector3 _jumpSquashSettings = new Vector3(0.8f, 1.2f, 0.2f);

        [SerializeField, Tooltip("Width Squeeze, Height Squeeze, Duration")]
        private Vector3 _landSquashSettings = new Vector3(1.25f, 0.8f, 0.2f);

        [SerializeField, Tooltip("How powerful should the effect be?")]
        private float _landSqueezeMultiplier = 1f;

        [SerializeField, Tooltip("How powerful should the effect be?")]
        private float _jumpSqueezeMultiplier = 1f;

        [SerializeField]
        private float _landDrop = 0.2f;

        [Foldout("Tilting", true)]
        [SerializeField, Tooltip("How far should the character tilt?")]
        private float _maxTilt = 0f;

        [SerializeField, Tooltip("How fast should the character tilt?")]
        private float _tiltSpeed = 60f;

        #endregion
        #region Properties
        public string PresetName => _presetName;
        public float Acceleration => _acceleration;
        public float TopSpeed => _topSpeed;

        public float Deceleration => _deceleration;

        public float TurnSpeed => _turnSpeed;

        public float JumpHeight => _jumpHeight;

        public float TimeToApex => _timeToApex;

        public float DownwardMovementMultiplier => _downwardMovementMultiplier;

        public float AirControl => _airAcceleration;

        public float AirControlActual => _airTurnSpeed;

        public float AirBrake => _airDecceleration;

        public bool VariableJumpHeight => _variableJumpHeight;

        public float JumpCutoff => _jumpCutoff;

        public int DoubleJump => _doubleJump;

        public Vector3 JumpSquashSettings => _jumpSquashSettings;
        public Vector3 LandSquashSettings => _landSquashSettings;
        public float LandSqueezeMultiplier => _landSqueezeMultiplier;
        public float JumpSqueezeMultiplier => _jumpSqueezeMultiplier;
        public float LandDrop => _landDrop;
        public float MaxTilt => _maxTilt;
        public float TiltSpeed => _tiltSpeed;
        public bool UseAcceleration => _useAcceleration;

        #endregion

        #region Methods

        private void OnValidate()
        {
            _presetName = name;
            if(_liveUpdate)
            {
                OnValidated?.Invoke();
            }
        }

        #endregion
    }
}
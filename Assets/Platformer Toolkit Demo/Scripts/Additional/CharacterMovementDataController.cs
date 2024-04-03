using UnityEngine;

namespace GMTK.PlatformerToolkit
{
    [RequireComponent(typeof(characterMovement), typeof(characterJump))]
    public class CharacterMovementDataController : MonoBehaviour
    {
        [SerializeField] private PresetObject _preset;

        private characterMovement _moveScript;
        private characterJump _jumpScript;

        private characterJuice _juiceScript;

        private PresetObject _installedPreset;

        private void Awake()
        {
            _moveScript = GetComponent<characterMovement>();
            _jumpScript = GetComponent<characterJump>();
            _juiceScript = GetComponent<characterJuice>();

            InstallPresetData();
            _installedPreset.OnValidated += InstallPresetData;
        }

        private void FixedUpdate()
        {
            if (_installedPreset != _preset)
            {
                _preset.OnValidated -= InstallPresetData;
                InstallPresetData();
            }
        }

        private void InstallPresetData()
        {
            //MOVE
            _moveScript.maxAcceleration = _preset.Acceleration;
            _moveScript.maxSpeed = _preset.TopSpeed;
            _moveScript.maxDecceleration = _preset.Deceleration;
            _moveScript.maxTurnSpeed = _preset.TurnSpeed;

            //JUMP
            _moveScript.maxAirAcceleration = _preset.AirControl;
            _moveScript.maxAirDeceleration = _preset.AirBrake;
            _jumpScript.jumpHeight = _preset.JumpHeight;
            _jumpScript.timeToJumpApex = _preset.TimeToApex;
            _jumpScript.downwardMovementMultiplier = _preset.DownwardMovementMultiplier;
            _jumpScript.jumpCutOff = _preset.JumpCutoff;
            _jumpScript.maxAirJumps = _preset.DoubleJump;
            _jumpScript.variablejumpHeight = _preset.VariableJumpHeight;
            _moveScript.maxAirTurnSpeed = _preset.AirControlActual;

            _installedPreset = _preset;

            //JUICE

            _juiceScript.jumpSquashSettings = _preset.JumpSquashSettings;
            _juiceScript.landSquashSettings = _preset.LandSquashSettings;
            _juiceScript.landSqueezeMultiplier = _preset.LandSqueezeMultiplier;
            _juiceScript.jumpSqueezeMultiplier = _preset.JumpSqueezeMultiplier;
            _juiceScript.landDrop = _preset.LandDrop;
            _juiceScript.maxTilt = _preset.MaxTilt;
            _juiceScript.tiltSpeed = _preset.TiltSpeed;
        }
    }
}
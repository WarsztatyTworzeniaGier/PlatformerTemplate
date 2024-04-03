using UnityEngine;

namespace GMTK.PlatformerToolkit
{
    public class movementLimiter : MonoBehaviour
    {
        public static movementLimiter instance;

        [SerializeField] private bool _initialCharacterCanMove = true;
        public bool CharacterCanMove;

        private void OnEnable()
        {
            instance = this;
        }

        private void Start()
        {
            CharacterCanMove = _initialCharacterCanMove;
        }
    }
}
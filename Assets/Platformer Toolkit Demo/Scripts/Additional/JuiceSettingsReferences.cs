using UnityEngine;
using UnityEngine.UI;
using MyBox;
namespace GMTK.PlatformerToolkit
{
    public class JuiceSettingsReferences : MonoBehaviour
    {
        [Foldout("UI Components", true)]
        [SerializeField] public Slider runParticlesSlider;

        [SerializeField] public Slider jumpParticlesSlider;
        [SerializeField] public Slider landParticlesSlider;

        [SerializeField] public Slider jumpSquashSlider;
        [SerializeField] public Slider landSquashSlider;

        [SerializeField] public Slider trailSlider;

        [SerializeField] public Slider tiltAngleSlider;
        [SerializeField] public Slider tiltSpeedSlider;

        [SerializeField] public Toggle jumpSFXtoggle;
        [SerializeField] public Toggle landSFXtoggle;

        [Foldout("Readouts", true)]
        [SerializeField] public Text runParticleText;

        [SerializeField] public Text jumpParticleText;
        [SerializeField] public Text landParticleText;
        [SerializeField] public Text jumpSquashText;
        [SerializeField] public Text landSquashText;
        [SerializeField] public Text trailText;
        [SerializeField] public Text tiltAngleText;
        [SerializeField] public Text tiltSpeedText;
    }
}
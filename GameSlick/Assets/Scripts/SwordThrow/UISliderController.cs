using UnityEngine;
using UnityEngine.UI;

public class UISliderController : MonoBehaviour
{
    public RotateObject rotateObject; // Reference to the RotateObject script
    public Slider speedSlider; // Reference to the UI slider

    // Called when the slider value changes
    public void OnSliderValueChanged(float newValue)
    {
        rotateObject.UpdateRotationSpeed(newValue);
    }
}


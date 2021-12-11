using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace physics.Project
{
    public class SliderChangeScript : MonoBehaviour
    {
        #region variables & references:

        [SerializeField] private Slider _slider;
        [SerializeField] private Text _sliderText;

        [SerializeField] private AdjustThrowingDegree _throwingScript;

        #endregion

        #region main functions:

        private void Start()
        {
            _slider = this.transform.GetComponent<Slider>();
            _slider.onValueChanged.AddListener(
                (value => { 
                    _sliderText.text = value.ToString("0.00");
                    if (_slider.name == "Degree Slider")
                        _throwingScript.ProvokeDegreeChange(value);
                    else if (_slider.name == "Force Slider")
                        _throwingScript.LaunchForce = value;
                })
                );
        }

        #endregion
    }
}
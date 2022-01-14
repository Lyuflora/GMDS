using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gmds
{


public class RatingSlidingNumber : MonoBehaviour
{
        public TMP_Text numberText;
        public float animationTime = 1.0f;
        public Slider slider;

        private float desiredNumber, initialNumber;
        private float currentNumber;

        public void SetNumber(float value)
        {
            initialNumber = currentNumber;
            desiredNumber = value;
        }

        public void AddUpToNumber(float value)
        {
            initialNumber = currentNumber;
            desiredNumber += value;
        }

        public void Update()
        {
            if(currentNumber != desiredNumber)
            {
                if (initialNumber < desiredNumber)
                {
                    // Add
                    currentNumber += (animationTime * Time.deltaTime)*(desiredNumber-currentNumber);
                    if (initialNumber > desiredNumber)
                    {
                        initialNumber = desiredNumber;
                    }
                }
                else
                {
                    currentNumber -= (animationTime * Time.deltaTime) * (desiredNumber - currentNumber);
                    if (initialNumber > desiredNumber)
                    {
                        // Minus
                        currentNumber -= (animationTime * Time.deltaTime) * (desiredNumber - currentNumber);
                        if (initialNumber < desiredNumber)
                        {
                            initialNumber = desiredNumber;
                        }
                    }
                }

                numberText.text = currentNumber.ToString("0");
                slider.value = currentNumber;
            }
            
        }
    }
}
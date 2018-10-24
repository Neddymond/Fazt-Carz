using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class CarLights : MonoBehaviour
    {
        public GameObject FrontLight;
        public GameObject BackLight;
        public Material BackLightEmitter;
       

        public GameObject FrontLightEmitter;
        public Color FrontLightEmissionColor;

        //public GameObject BackLightEmitter;
        public Color BackLightEmissionColor;

        public List<GameObject> LeftTrafficators;
        public List<GameObject> RightTrafficators;
    
        public Color LeftTrafficator;
        private bool shouldToggleLeftTrafficator = false;
        private bool shouldToggleRightTrafficator = false;
        private bool isLeftTrafficatingLightOn = false;
        private bool isRightTrafficatingLightOn = false;

        private bool headlightShouldAlwaysBeOn = false;

      
       

      
        public void Start()
        {
            InvokeRepeating("ToggleLeftTrafficator", 0.5f, 0.5f);
            InvokeRepeating("ToggleRightTrafficator", 0.5f, 0.5f);
            
        }


        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.O)) ToggleFrontLights();
            if (Input.GetKeyDown(KeyCode.P)) ToggleBackLights();


            if (Input.GetKey(KeyCode.UpArrow))
            {
                TurnOnFrontLights();
            }
            else
            {
                TurnOffFrontLights();
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                TurnOnBackLights();
            }
            else
            {
                TurnOffBackLights();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                shouldToggleLeftTrafficator = true;
            }
            else
            {
                shouldToggleLeftTrafficator = false;
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                shouldToggleRightTrafficator = true;
            }
            else
            {
                shouldToggleRightTrafficator = false;
            }
        }
        private void ToggleFrontLights()
        {
            headlightShouldAlwaysBeOn = !headlightShouldAlwaysBeOn;
            FrontLight.SetActive(headlightShouldAlwaysBeOn);
            FrontLightEmitter.GetComponent<Renderer>().material.SetColor("_EmissionColor", FrontLightEmissionColor);
       
        }
        private void TurnOnFrontLights()
        {
            
            FrontLightEmitter.GetComponent<Renderer>().material.SetColor("_EmissionColor", FrontLightEmissionColor);
            FrontLight.SetActive(true);
        }

        private void TurnOffFrontLights()
        {
            if (headlightShouldAlwaysBeOn) return;
            FrontLight.SetActive(false);


            FrontLightEmitter.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
        }

        private void ToggleBackLights()
        {
            headlightShouldAlwaysBeOn = !headlightShouldAlwaysBeOn;
            BackLight.SetActive(headlightShouldAlwaysBeOn);
            BackLightEmitter.SetColor("_EmissionColor", BackLightEmissionColor);
        }

        private void TurnOnBackLights()
        {
            
            BackLightEmitter.SetColor("_EmissionColor", BackLightEmissionColor);
            BackLight.SetActive(true);
        }

        private void TurnOffBackLights()
        {
            if (headlightShouldAlwaysBeOn) return;
            BackLight.SetActive(false);
            BackLightEmitter.SetColor("_EmissionColor", Color.black);
        }

        private void ToggleLeftTrafficator()
        {
           
         
            if (!isLeftTrafficatingLightOn)
            {
                if (!shouldToggleLeftTrafficator) return;
                isLeftTrafficatingLightOn = true;
                foreach (GameObject trafficatingLight in LeftTrafficators)
                {
                    trafficatingLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", FrontLightEmissionColor);
                }

            }
            else
            {
                isLeftTrafficatingLightOn = false;
                foreach (GameObject trafficatingLight in LeftTrafficators)
                {
                    trafficatingLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                }
            }
        }

        private void ToggleRightTrafficator()
        {
            if (!isRightTrafficatingLightOn)
            {
                if (!shouldToggleRightTrafficator) return;
                isRightTrafficatingLightOn = true;
                foreach (GameObject trafficatingLight in RightTrafficators)
                {
                    trafficatingLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", FrontLightEmissionColor);
                }
            }
            else
            {
                isRightTrafficatingLightOn = false;
                foreach (GameObject trafficatingLight in RightTrafficators)
                {
                    trafficatingLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.black);
                }
            }
           
            
           

        }
    }
    
}

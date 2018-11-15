
namespace PedometerU.Tests
{


    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class ChangeBackground : MonoBehaviour
    {

        public SpriteRenderer part;
        public Sprite[] options;
        public int index;
        // Use this for initialization


        public Text stepText, distanceText;
        private Pedometer pedometer;
        private int stepP;


        private void Start()
        {

            // Create a new pedometer
            pedometer = new Pedometer(OnStep);
            // Reset UI
            OnStep(0, 0);


        }

        private void OnStep(int steps, double distance)
        {
            // Display the values // Distance in feet
            stepText.text = steps.ToString();

            //distanceText.text = (distance * 3.28084).ToString("F2") + " ft";
        }

        private void Update()
        {
            // Release the pedometer
            pedometer.Dispose();
            pedometer = null;

            for (int i = 0; i < options.Length; i++)
            {
                if (i == index)
                {
                    part.sprite = options[i];
                }
            }





        }



        public void SwapBackground()
        {
            /*if (num == 100)
            {
                // then the second avatar is on now
                whichAvatarIsOn = 2;

                // disable the first one and anable the second one
                BG1.gameObject.SetActive(false);
                BG2.gameObject.SetActive(true);
            }
            else if (num == 500)
            {
                whichAvatarIsOn = 1;

                // disable the second one and anable the first one
                BG1.gameObject.SetActive(true);
                BG2.gameObject.SetActive(false);
            }*/
            if (index < options.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }

        public void Addnum()
        {
            stepP++;
        }



    }

}
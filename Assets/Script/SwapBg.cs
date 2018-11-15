namespace PedometerU.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;
    using Firebase;
    using Firebase.Database;
    using Firebase.Unity.Editor;
    using System;

    public class SwapBg : RootControl
    {

        public SpriteRenderer part;
        public Sprite[] options;
        public int index;
        public Text stepText, distanceText, testText,moneyText;
        private Pedometer pedometer;
        private int num,num2, numBg, numMoney,numC=0;
        public int state ;
        int Round = 0;
        Scene sceneM;

        //
        private DatabaseReference reference;
        public int temp;
        string i,j,c;


        private void Start()
        {
            pedometer = new Pedometer(OnStep);
            // Reset UI
            OnStep(0, 0);
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://traveler-4e98c.firebaseio.com/");
            // สำหรับใช้ในการอ้างอิง Firebase
            reference = FirebaseDatabase.DefaultInstance.RootReference;
            // Create a new pedometer
            setName();
            getStepCount();
            getMoney();
            



        }

        public void getStepCount()
        {
            //setName();
            FirebaseDatabase.DefaultInstance
        .GetReference("User/" + RootName + "/StepCount")
        .GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("error");
        }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                i = snapshot.GetRawJsonValue();
                num = int.Parse(i) + num;
                stepText.text = num.ToString();
               
            }
        });

        }

        public void getCountry()
        {
            FirebaseDatabase.DefaultInstance
        .GetReference("User/" + RootName + "/Country")
        .GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                c = snapshot.GetRawJsonValue();
                state = int.Parse(c) ;
            }
        });

        }

        public void getRound()
        {
            FirebaseDatabase.DefaultInstance
        .GetReference("User/" + RootName + "/Round")
        .GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                c = snapshot.GetRawJsonValue();
                //Round = int.Parse(c);
            }
        });

        }


        public void getMoney()
        {
            //setName();
            FirebaseDatabase.DefaultInstance
        .GetReference("User/" + RootName + "/Money")
        .GetValueAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.Log("error");
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                j = snapshot.GetRawJsonValue();
                num2 = int.Parse(j) + num2;
                moneyText.text = num2.ToString();
                // SSTools.ShowMessage("StepCount" + num, SSTools.Position.bottom, SSTools.Time.twoSecond);
            }
        });

        }

        private void OnStep(int steps, double distance)
        {
            // Display the values // Distance in feet


            //num = steps;
            numBg = steps+num;
            numMoney = steps + num2;
            Round = steps + num;
            //testText.text = numBg.ToString();
            stepText.text = numBg.ToString();
            moneyText.text = numMoney.ToString();
            //stepText.text = steps.ToString();
            //distanceText.text = (distance * 3.28084).ToString("F2") + " ft";
        }

        private void OnDisable()
        {
            // Release the pedometer
            //pedometer.Dispose();
            pedometer = null;
        }



        void Update()
        {
            /*  for (int i = 0; i < options.Length; i++)
             {
                 if (i == index)
                 {
                     part.sprite = options[i];
                 }
             }*/
            getCountry();
            getRound();
            Cbg();
            

            //setState();
        }

        

        public void Cbg()
        {


            /*


            if (numC == 0)
            {

                if (Round >= 20)
                {
                    Round = Round - 20;

                    //Round = 20;
                    reference.Child("User/" + RootName).Child("Round").SetValueAsync(20);
                    reference.Child("User/" + RootName).Child("Country").SetValueAsync(1);
                }
                //Round = 20;
            }
            else if (numC == 1)
            {

                index = 1;
                part.sprite = options[index];
                if (Round >= 40)
                {
                    Round = Round - 40;
                    //Round = 40;
                    reference.Child("User/" + RootName).Child("Round").SetValueAsync(40);
                    reference.Child("User/" + RootName).Child("Country").SetValueAsync(2);
                }
                // Round = 40;
            }
            else if (numC == 2)
            {

                if (Round >= 60)
                {
                    Round = Round - 60;
                    index=0;
                    //numC = 3;
                    part.sprite = options[index];
                    //Round = 60;
                    reference.Child("User/" + RootName).Child("Round").SetValueAsync(0);
                    reference.Child("User/" + RootName).Child("Country").SetValueAsync(0);
                }

            }*/
            if (state == 0)
            {

                if (numBg >= 0 && numBg <= 20)
                {
                    reference.Child("User/" + RootName).Child("Country").SetValueAsync(1);
                }
            }
            else if (state == 1)
            {
                if (numBg >= 21 && numBg <= 40)
                {
                    reference.Child("User/" + RootName).Child("Country").SetValueAsync(2);
                    index++;
                    part.sprite = options[index];
                }
            }
            else if (state == 2)
            {
                if (numBg >= 41)
                {
                    reference.Child("User/" + RootName).Child("Country").SetValueAsync(3);
                    index++;
                    part.sprite = options[index];
                }
            }



            

            /* if (state == 0)
             {

                 if (Round >= 20)
                 {
                     Round = Round - 20;
                     index++;
                     state = 1;
                     part.sprite = options[index];
                     Round = 20;
                     reference.Child("User/" + RootName).Child("Country").SetValueAsync(1);
                 }
                 //Round = 20;
             }
             else if (state == 1)
             {
                 if (Round >= 40)
                 {
                     Round = Round - 40;
                     index++;
                     state = 2;
                     part.sprite = options[index];
                     Round = 40;
                     reference.Child("User/" + RootName).Child("Country").SetValueAsync(2);
                 }
                // Round = 40;
             }
             else if (state == 2)
             {
                 if (Round >= 60)
                 {
                     Round = Round - 60;
                     index++;
                     state = 3;
                     part.sprite = options[index];
                     Round = 60;
                     reference.Child("User/" + RootName).Child("Country").SetValueAsync(2);
                 }
                // Round = 60;
             }
             else if (state == 3)
             {
                 if (Round >= 80)
                 {
                     Round = Round - 80;
                     index++;
                     state = 4;
                     part.sprite = options[index];
                     Round = 80;
                     reference.Child("User/" + RootName).Child("Country").SetValueAsync(3);
                 }
                 //Round = 80;
             }
             else if (state == 4)
             {
                 if (Round >= 100)
                 {
                     Round = Round - 100;
                     index = 0;
                     state = 0;
                     part.sprite = options[index];
                     Round = 0;
                     reference.Child("User/" + RootName).Child("Country").SetValueAsync(4);
                 }
                 //Round = 0;
             }*/

        }


        public void btnCity()
        {
            Debug.Log("State : "+ state);
           // setName();
            SaveState();
            reference.Child("User/" + RootName).Child("StepCount").SetValueAsync(numBg);
            reference.Child("User/" + RootName).Child("Money").SetValueAsync(numMoney);
            SceneManager.LoadScene("MapCountry");
        }
        public void btnShop()
        {
            SceneManager.LoadScene("ShopItem");
        }

        public void btnmain()
        {
            SceneManager.LoadScene("Main_1");
        }

        public void btnDressUp()
        {
            if (gender == 0)
            {
                SceneManager.LoadScene("DressupGirl");
            }
            else if (gender == 1)
            {
                SceneManager.LoadScene("DressupBoy");
            }

        }

        public void setState()
        {
            
            //healthValue = PlayerPrefs.GetInt("HealthKey", 0);
            //PlayerPrefs.SetInt("HealthKey", 0);
            if (PlayerPrefs.HasKey("StateKEy"))
            {
                //do something
            }
            temp = PlayerPrefs.GetInt("StateKey", 0);
        }


        public void SaveState()
        {
            
            PlayerPrefs.SetInt("StateKey", state);


        }






    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AnyUI.Demo
{
    public class CurvedUIDemo : MonoBehaviour
    {
        public Image LevelImage;
        public enum Environment {EARTH,ICEPLANET,JUNGLEPLANET}
        [HideInInspector]
        public Environment SelectedEnvironment;
        public Animator EnvironmentImageAnimator;
        public Text[] SelectedEnvironmentText;
        private int m_environmentCount;

        public Button[] DifficultyButtons;
        public ToggleGroup ToggleGroupDifficulty;
        public GameObject[] ItemGrids;
       

        public Dropdown Dropdown;
        public Text SelectedGearText;
        public Text SelectedDifficultyText;
        public Button StartButton;
        public Toggle ServerToggle;


        // Use this for initialization
        void Start()
        {
            SelectedEnvironment = Environment.EARTH;
            m_environmentCount = System.Enum.GetValues(typeof(Environment)).Length;

            //Set the default difficulty to easy
            //DifficultyButtons[0].Select();
            //DifficultyButtons[0].OnSelect(null);

            //Set the default gear to 1
            //Dropdown.value = 0;
            //Dropdown.onValueChanged.Invoke(0);

            ////Set the default server to false
            //ServerToggle.isOn = false;
            //ServerToggle.onValueChanged.Invoke(false);

            //set ItemGrids
            for (int i = 0; i < ItemGrids.Length; i++)
            {
                ItemGrids[i].SetActive(false);
            }

            //Set the default item grid to 1
            //ItemGrids[0].SetActive(true);
            //Debug.Log(ToggleGroupDifficulty.ActiveToggles());
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
        public void ChangeItem(Toggle  _toggle)
        {         
            ChangeToggle(SelectedGearText, _toggle);
        }
        public void ChangeDifficulty(Toggle _toggle)
        {
            ChangeToggle(SelectedDifficultyText, _toggle);
        }
        private void ChangeToggle(Text _text,Toggle _toggle)
        {
            StopAllCoroutines();
            if (_toggle.isOn)
            StartCoroutine(ChangeText(_text, "/" + _toggle.gameObject.name));
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
        public void ChangeEnvironment(int _direction)
        {         
            SelectedEnvironment += _direction;
            int _environmentIndex = (int)SelectedEnvironment;
            if (_environmentIndex < 0) SelectedEnvironment = (Environment)m_environmentCount - 1;
            else if (_environmentIndex == m_environmentCount) SelectedEnvironment = 0;
            EnvironmentImageAnimator.SetTrigger("" + SelectedEnvironment);

            for(int i = 0; i < SelectedEnvironmentText.Length; i++)
            {
                switch (SelectedEnvironment)
                {
                    case (Environment.EARTH):
                        StartCoroutine(ChangeText(SelectedEnvironmentText[i], "Planet Surface"));
                        break;
                    case (Environment.ICEPLANET):
                        StartCoroutine(ChangeText(SelectedEnvironmentText[i], "Ice Planet"));
                        break;
                    case (Environment.JUNGLEPLANET):
                        StartCoroutine(ChangeText(SelectedEnvironmentText[i], "Jungle Planet"));
                        break;
                }
            }                       
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
        public void ChangeGearCategory()
        {      
            for (int i = 0; i <= ItemGrids.Length-1; i++) ItemGrids[i].SetActive(false);
            ItemGrids[Dropdown.value].SetActive(true);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
        private IEnumerator ChangeText(Text _text, string _string,float _timeBetweenLetters=0.05f)
        {           
            _text.text = "";
            for(int i = 0; i < _string.Length; i++)
            {
                _text.text += "" + _string[i];
                yield return new WaitForSeconds(_timeBetweenLetters);
            }

            yield return null;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////
    }

}

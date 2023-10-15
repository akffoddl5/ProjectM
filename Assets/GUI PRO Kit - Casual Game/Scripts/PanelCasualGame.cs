using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LayerLab.CasualGame
{
    public class PanelCasualGame : MonoBehaviour
    {
        private GameObject[] otherPanels;

        public void OnEnable()
        {
            if (otherPanels != null)
                for (int i = 0; i < otherPanels.Length; i++) otherPanels[i].SetActive(true);
        }

        public void OnDisable()
        {
            if(otherPanels != null)
                for (int i = 0; i < otherPanels.Length; i++) otherPanels[i].SetActive(false);
        }
    }
}

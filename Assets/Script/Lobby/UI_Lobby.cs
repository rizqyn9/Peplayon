using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace NetworkPeplayon
{
    public class UI_Lobby : MonoBehaviour
    {
        public static UI_Lobby instance;

        [SerializeField] public GameObject  PrefabPlayerUI;
        [SerializeField] public Transform   PlayerUIParent;
        [SerializeField] public Canvas      Billboard;


        private void Start()
        {
            instance = this;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                showBillboard();
            }
        }

        public void showBillboard()
        {
            if (Billboard.isActiveAndEnabled)
            {
                Billboard.enabled = false;
            } else
            {
                Billboard.enabled = true;
            }
        }

        public GameObject SpawnPlayerUIBillboard (Player player)
        {
            GameObject newPlayerUI = Instantiate(PrefabPlayerUI, PlayerUIParent);
            newPlayerUI.GetComponent<Player>();
            return newPlayerUI;
        }
    }
}

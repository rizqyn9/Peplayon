using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Peplayon
{
    public class UI_Player : MonoBehaviour
    {
        [SerializeField] Text text;

        public string PlayerName { get; set; }
        public int PlayerIndex { get; set; }
        UI_Player uiPlayer;

        private void Start()
        {
            SetPlayer(uiPlayer);
        }

        public void SetPlayer (UI_Player _uiPlayer)
        {
            this.uiPlayer = _uiPlayer;
            //text.text = _uiPlayer.PlayerName;
            text.text = "Player 1 ";
        }
    }
}

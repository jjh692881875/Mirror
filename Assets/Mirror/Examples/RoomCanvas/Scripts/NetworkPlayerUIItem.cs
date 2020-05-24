using UnityEngine;
using UnityEngine.UI;
namespace Mirror.Examples.NetworkRoomCanvas
{
    public class NetworkPlayerUIItem : MonoBehaviour
    {
        public Text nameText;
        public Text readyText;

        [Header("State Colors")]
        public Color readyColor = Color.green;
        public Color notReadyColor = Color.red;
        public Color hostColor = Color.blue;

        NetworkRoomPlayerExample player;

        public void Setup(NetworkRoomPlayerExample player)
        {
            this.player = player;

            player.onReadyChanged += SetReady;

            SetPlayerName("player " + player.index);
            SetReady(player.readyToBegin);
        }

        void OnDestroy()
        {
            player.onReadyChanged -= SetReady;
        }

        public void SetPlayerName(string playerName)
        {
            nameText.text = playerName;
        }

        public void SetReady(bool ready)
        {
            readyText.text = ready ? "Ready" : "";
            Color color = GetColor(ready);
            nameText.color = color;
            readyText.color = color;
        }

        Color GetColor(bool ready)
        {
            if (player.IsHost)
            { return hostColor; }


            if (ready)
            {
                return readyColor;
            }
            else
            {
                return notReadyColor;
            }
        }
    }
}
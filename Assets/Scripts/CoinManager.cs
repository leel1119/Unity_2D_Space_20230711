using Fungus;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Leo.TwoD
{
    public class CoinManager : MonoBehaviour
    {
        /// <summary>
        /// 金幣管理器
        /// </summary>
        // Start is called before the first frame update
        [SerializeField, Header("遊戲管理器")]
        private Flowchart flowchatGM;

        private TextMeshProUGUI textCoin;
        private int coinCurrent;
        private int coinTotal = 10;
        
        private void Awake()
        {
            textCoin = GameObject.Find("金幣數量").GetComponent<TextMeshProUGUI>();
            textCoin.text = $"金幣數量 {coinCurrent} / {coinTotal} ";
        }

        private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
        {
            if (collision.gameObject.name.Contains("金幣")) EatCoin(collision.gameObject);
        }
        private void EatCoin(GameObject coin)
        {
            Destroy(coin);
            textCoin.text = $"金幣數量：{++coinCurrent} / {coinTotal}";

            AudioClip sound = SoundManager.instance.soundCoin;
            SoundManager.instance.PlayerSound(sound, 0.3f, 0.7f);

            if (coinCurrent >= coinTotal)
            {
                AudioClip soundWin = SoundManager.instance.soundWin;
                SoundManager.instance.PlayerSound(soundWin, 0.3f, 0.7f);
                flowchatGM.SendFungusMessage("遊戲勝利");
            }
        }
    }
}
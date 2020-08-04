using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace _Complete
{
    public class Pickup : MonoBehaviour
    {
        private int coinCount;
        public TextMeshProUGUI coinText;
        public AudioClip coinSound;
        public AudioClip burgerSound;
        public AudioClip drinkSound;

        private void OnTriggerEnter2D(Collider2D other)
        {
            bool foundCollectable = false;
            AudioClip clip = null;
            int collectableValue = 0;

            if (other.CompareTag("coin"))
            {
                clip = coinSound;
                collectableValue = 1;
                foundCollectable = true;
            }
            else if (other.CompareTag("burger"))
            {
                clip = burgerSound;
                collectableValue = 10;
                foundCollectable = true;
            }
            else if (other.CompareTag("drink"))
            {
                clip = drinkSound;
                collectableValue = 15;
                foundCollectable = true;
            }

            if (foundCollectable)
            {
                AudioSource.PlayClipAtPoint(clip, other.transform.position);
                coinCount += collectableValue;
                coinText.text = coinCount.ToString();
                Destroy(other.gameObject);
            }
        }

    }
}

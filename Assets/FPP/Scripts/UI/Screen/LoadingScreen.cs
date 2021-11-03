using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace FPP.Scripts.UI.Screen
{
    public class LoadingScreen : MonoBehaviour
    {
        public Text textField;
        public string loadingText;

        void Start()
        {
            StartCoroutine(AnimateText());
        }

        private IEnumerator AnimateText()
        {
            // TODO: Implement this as a recursive function
            while (true)
            {
                textField.text = loadingText;
                textField.text += ".";
                yield return new WaitForSeconds(1);
                textField.text += ".";
                yield return new WaitForSeconds(1);
                textField.text += ".";
                yield return new WaitForSeconds(1);
                textField.text += ".";
            }
        }
    }
}
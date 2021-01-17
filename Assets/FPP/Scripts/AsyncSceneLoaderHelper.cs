using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncSceneLoaderHelper : MonoBehaviour
{
    public IEnumerator SomeCoroutine(System.Action<int> callBack) {

        // Waits 3 seconds
        yield return new WaitForSeconds(3);

        // Set callBack to 1 after 3 seconds
        callBack(1);
    }
}

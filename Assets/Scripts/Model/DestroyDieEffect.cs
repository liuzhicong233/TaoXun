using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDieEffect : MonoBehaviour
{
    private void OnEnable() {
        Destroy(gameObject,2f);
    }
}

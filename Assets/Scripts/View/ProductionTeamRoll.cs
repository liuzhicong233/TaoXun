using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProductionTeamRoll : MonoBehaviour
{

    public GameObject text;

    private Ctrl ctrl;

    private void Start() {
        ctrl = GameObject.Find("Ctrl").GetComponent<Ctrl>();
    }

    private void OnEnable() {
        StartCoroutine(RollTime());
    }
    private void OnDisable() {
        text.transform.DOPause();
        text.transform.localPosition = new Vector3(0,-2700f,0);

    }

    IEnumerator RollTime(){
        Tweener tweener = text.transform.DOLocalMoveY(1900f,25f);
        tweener.SetEase(Ease.Linear);

        yield return new WaitForSeconds(26f);

        ctrl.view.HideProducitonTeam();
        ctrl.menuState.canEsc = false;

        yield return null;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBreak : MonoBehaviour
{
    [SerializeField] private GameObject spriteMask;
    private TowerBasic towerBasicScript;
    // Start is called before the first frame update
    void Start()
    {
        towerBasicScript = GetComponent<TowerBasic>();
    }

    // Update is called once per frame
    void Update()
    {
        towerBasicScript.GetHP();
    }
    private void FixedUpdate()
    {
    }

    public void BreakTower()
    {
        spriteMask.transform.localPosition = new Vector3(towerBasicScript.GetHP() * .3f + 1, spriteMask.transform.localPosition.y, spriteMask.transform.localPosition.z);
    }
}

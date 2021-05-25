using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject generator;
    [SerializeField] private GameObject tempGenerator;
    [SerializeField] private GameObject attack;
    [SerializeField] private GameObject tempAttack;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject tempBlock;
    [SerializeField] private GameObject shoot;
    [SerializeField] private GameObject tempShoot;

    private GameObject tempHeldObject;
    private GameObject heldObject;
    private GameObject temp;

    [SerializeField] private Vector2 topLeftPoint;
    [SerializeField] private Vector2 botRightPoint;
    private Vector2[,] gridPoints = new Vector2[10, 5];

    private bool holdingTower = false;

    private int basicResource = 0;
    [SerializeField] private TextMeshProUGUI textBasicResourceCount;
    // Start is called before the first frame update
    void Start()
    {
        //float x = topLeftPoint.x;
        //float y = topLeftPoint.y;
        //for (int j = 0; j < 5; j++)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        gridPoints[i, j] = new Vector2(x, y);
        //        //Debug.Log(gridPoints[i, j]);
        //        //Instantiate(tempGenerator, gridPoints[i, j], Quaternion.identity);
        //        x += 2;
        //    }
        //    x = topLeftPoint.x;
        //    y -= 1.5f;
        //}


    }

    // Update is called once per frame
    void Update()
    {
        if(temp != null)
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if(Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                temp.transform.position = new Vector3(hit.point.x, hit.point.y, -1);
            }
            
            //temp.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        }
    }

    public void OnClick(GameObject tower, GameObject tempTower)
    {
        if(temp == null)
        {
            holdingTower = true;
            heldObject = tower;
            tempHeldObject = tempTower;
            temp = Instantiate(tower, new Vector3(transform.position.x, transform.position.y, 5), tower.transform.rotation);
        }
        else
        {
            Destroy(temp);
            holdingTower = false;
        }
    }

    public void GeneratorOnClick()
    {
        OnClick(generator, tempGenerator);
        
    }
    public void AttackOnClick()
    {
        OnClick(attack, tempAttack);
    }

    public void BlockOnClick()
    {
        OnClick(block, tempBlock);
    }

    public void ShootOnClick()
    {
        OnClick(shoot, tempShoot);
    }

    public bool GetHoldingTower()
    {
        return holdingTower;
    }

    public GameObject GetTempHeldTower()
    {
        if (holdingTower)
        {
            return tempHeldObject;
        }
        return null;
    }

    public GameObject GetHeldTower()
    {
        if (holdingTower)
        {
            return heldObject;
        }
        return null;
    }

    public void TowerPlaced()
    {
        holdingTower = false;
        Destroy(temp);
    }

    public void AddBasicResource(int add)
    {
        basicResource += add;
        textBasicResourceCount.text = basicResource.ToString();
    }
}

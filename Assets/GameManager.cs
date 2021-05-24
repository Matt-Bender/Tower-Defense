using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject generator;
    [SerializeField] private GameObject tempGenerator;
    [SerializeField] private GameObject attack;
    [SerializeField] private GameObject tempAttack;
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject tempBlock;

    private GameObject tempHeldObject;
    private GameObject heldObject;
    private GameObject temp;

    [SerializeField] private Vector2 topLeftPoint;
    [SerializeField] private Vector2 botRightPoint;
    private Vector2[,] gridPoints = new Vector2[10, 4];

    private bool holdingTower = false;
    // Start is called before the first frame update
    void Start()
    {
        float x = topLeftPoint.x;
        float y = topLeftPoint.y;
        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                gridPoints[i, j] = new Vector2(x, y);
                //Debug.Log(gridPoints[i, j]);
                //Instantiate(tempGenerator, gridPoints[i, j], Quaternion.identity);
                x += 2;
            }
            x = topLeftPoint.x;
            y -= 2;
        }


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

    public void OnClick()
    {
        Debug.Log("CLICK");
    }

    public void GeneratorOnClick()
    {
        if(temp == null)
        {
            holdingTower = true;
            heldObject = generator;
            tempHeldObject = tempGenerator;
            temp = Instantiate(generator, transform.position, transform.rotation);
        }
        else
        {
            holdingTower = false;
            Destroy(temp);
        }
        
    }
    public void AttackOnClick()
    {
        if (temp == null)
        {
            holdingTower = true;
            heldObject = attack;
            tempHeldObject = tempAttack;
            temp = Instantiate(attack, transform.position, transform.rotation);
        }
        else
        {
            holdingTower = false;
            Destroy(temp);
        }
    }

    public void BlockOnClick()
    {
        if (temp == null)
        {
            holdingTower = true;
            heldObject = block;
            tempHeldObject = tempBlock;
            temp = Instantiate(block, transform.position, transform.rotation);
        }
        else
        {
            holdingTower = false;
            Destroy(temp);
        }
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
}

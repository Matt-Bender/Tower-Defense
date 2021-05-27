using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("TOWERS", order = 0)]

    [Header("Generator", order = 1)]
    [SerializeField] private GameObject generator;
    [SerializeField] private GameObject tempGenerator;
    [SerializeField] private Button buttonGenerator;

    [Header("Attack")]
    [SerializeField] private GameObject attack;
    [SerializeField] private GameObject tempAttack;
    [SerializeField] private Button buttonAttack;
    private float attackCooldown;

    [Header("Block")]
    [SerializeField] private GameObject block;
    [SerializeField] private GameObject tempBlock;
    [SerializeField] private Button buttonBlock;
    private float blockCooldown;

    [Header("Shoot")]
    [SerializeField] private GameObject shoot;
    [SerializeField] private GameObject tempShoot;
    [SerializeField] private Button buttonShoot;
    private float shootCooldown;

    private GameObject tempHeldObject;
    private GameObject heldObject;
    private GameObject temp;

    [Header("Grid")]
    [SerializeField] private Vector2 topLeftPoint;
    [SerializeField] private Vector2 botRightPoint;
    private Vector2[,] gridPoints = new Vector2[10, 5];

    private bool holdingTower = false;

    private int basicResource = 3;
    [SerializeField] private TextMeshProUGUI textBasicResourceCount;

    private CooldownManager cooldownScript;
    // Start is called before the first frame update
    void Start()
    {
        //Adds 0 to show current resources at the beginning
        AddBasicResource(0);

        cooldownScript = GetComponent<CooldownManager>();
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
        if(temp == null && tower.GetComponent<TowerBasic>().GetResourceCost() <= basicResource)
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
        Cooldown(heldObject);
        holdingTower = false;
        Destroy(temp);
    }


    public void AddBasicResource(int add)
    {
        basicResource += add;
        textBasicResourceCount.text = basicResource.ToString();
    }

    private void Cooldown(GameObject tower)
    {
        cooldownScript.CanBuyTower(tower, false);
    }
}

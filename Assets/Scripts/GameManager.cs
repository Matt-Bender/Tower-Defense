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

    [Header("Hammer (Used to destroy towers)")]
    [SerializeField] private GameObject hammer;
    [SerializeField] private GameObject tempHammer;
    [SerializeField] private Button buttonHammer;

    private GameObject tempHeldObject;
    private GameObject heldObject;
    private GameObject temp;

    [Header("Grid")]
    [SerializeField] private Vector2 topLeftPoint;
    [SerializeField] private Vector2 botRightPoint;
    private Vector2[,] gridPoints = new Vector2[10, 5];

    private bool holdingTower = false;



    [Header("Resources")]
    [SerializeField] private TextMeshProUGUI textBasicResourceCount;
    //Default 3
    private int basicResource = 3;

    [SerializeField] private GameObject scrap;
    //Default 0
    private int scrapResource = 1;
    [SerializeField] private TextMeshProUGUI textScrapResourceCount;

    private CooldownManager cooldownScript;
    // Start is called before the first frame update
    void Start()
    {
        //Adds 0 to show current resources at the beginning
        AddBasicResource(0);
        AddScrapResource(0);

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
        }
    }
    //On Click tower to choose which you will build
    public void OnClick(GameObject tower, GameObject tempTower)
    {
        //If currently holding tower will destroy and replace with most recent clicked on tower...
        if(temp != null)
        {
            Destroy(temp);
        }
        //Only if you have enough resources otherwise will just keep your currently selected tower
        if(tower.GetComponent<TowerBasic>() != null)
        {
            if (tower.GetComponent<TowerBasic>().GetResourceCost() <= basicResource && tower.GetComponent<TowerBasic>().GetScrapCost() <= scrapResource)
            {
                holdingTower = true;
                heldObject = tower;
                tempHeldObject = tempTower;
                temp = Instantiate(tower, new Vector3(transform.position.x, transform.position.y, 5), tower.transform.rotation);
            }
        }
        else
        {
            holdingTower = true;
            heldObject = tower;
            tempHeldObject = tempTower;
            temp = Instantiate(tower, new Vector3(transform.position.x, transform.position.y, 5), tower.transform.rotation);
        }


    }

    public void GeneratorOnClick()
    {
        OnClick(generator, tempGenerator);
        
    }
    public void HammerOnClick()
    {
        OnClick(hammer, tempHammer);
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

    public void SetHeldTower(GameObject tempTower)
    {
        heldObject = tempTower;
    }

    public void TowerPlaced()
    {
        //Check if 
        Cooldown(heldObject);
        holdingTower = false;
        Destroy(temp);
    }

    //Changes / updates (in text on screen) basic resource
    public void AddBasicResource(int add)
    {
        basicResource += add;
        textBasicResourceCount.text = basicResource.ToString();
    }
    public int GetBasicResource()
    {
        return basicResource;
    }
    //Changes / updates(in text on screen) scrap resource
    public void AddScrapResource(int add)
    {
        scrapResource += add;
        textScrapResourceCount.text = scrapResource.ToString();
    }
    public int GetScrapResource()
    {
        return scrapResource;
    }

    public GameObject GetScrap()
    {
        return scrap;
    }

    private void Cooldown(GameObject tower)
    {
        cooldownScript.CanBuyTower(tower, false);
    }
}

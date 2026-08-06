using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject WeightPanel;
    public GameObject NoWeightPanel;
    public GameObject GrayPanel;
    public GameObject PayPanel;
    public GameObject ToMenuPanel;
    public FirstPersonController fpc;
    public GameObject Character;
    public float Distance;
    public Transform Pointer;
    public LayerMask LayerMask;
    public double MilkPrice;
    public double CheesePrice;
    public double WatermelonPrice;
    public double MeatPrice;
    public double BananaPrice;
    public double CherryPrice;
    Vector3 RayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    [SerializeField]
    private Text WeightInformation;
    public Text PriceInformation;

    protected virtual void Start()
    {
        ToMenuPanel.SetActive(false);
        WeightPanel.SetActive(false);
        GrayPanel.SetActive(false);
        NoWeightPanel.SetActive(false);
        PayPanel.SetActive(false);
        fpc = Character.GetComponent<FirstPersonController>();
        Ray ray = Camera.main.ScreenPointToRay(RayStartPosition);
    }
    protected virtual void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(RayStartPosition);
        PriceInformation.text = "";
        Debug.DrawRay(ray.origin, ray.direction * Distance, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Pointer.position = hit.point;
            if (Physics.Raycast(ray, Distance, LayerMask))
            {

                if (hit.transform.CompareTag("PickUp"))
                {

                    if (Input.GetKeyUp(KeyCode.R) && !IsPanelActive.AnotherPanelIsActive)
                    {
                        PriceInformation.text = "";
                        hit.transform.gameObject.layer = LayerMask.NameToLayer("Default");
						FirstPersonController.getInstance().cart.AddToCartObj(hit.transform.gameObject);
                        string productName = hit.transform.gameObject.name.ToString();

                        switch (productName)
                        {
                            case "Milk": Customer.ProductsInBascet.Add(new PieceProductInBascet() { Name = productName, PriceFor = MilkPrice }); Debug.Log(productName); break;
                            case "Meat": Customer.ProductsInBascet.Add(new WeightProductInBascet() { Name = productName, PriceFor = MeatPrice, Weight = 0 }); Debug.Log(productName); break;
                            case "Cheese": Customer.ProductsInBascet.Add(new PieceProductInBascet() { Name = productName, PriceFor = CheesePrice }); Debug.Log(productName); break;
                            case "Watermelon": Customer.ProductsInBascet.Add(new WeightProductInBascet() { Name = productName, PriceFor = WatermelonPrice, Weight = 0 }); Debug.Log(productName); break;
                            case "Cherry": Customer.ProductsInBascet.Add(new WeightProductInBascet() { Name = productName, PriceFor = CherryPrice, Weight = 0 }); Debug.Log(productName); break;
                            case "Banana": Customer.ProductsInBascet.Add(new WeightProductInBascet() { Name = productName, PriceFor = BananaPrice, Weight = 0 }); Debug.Log(productName); break;

                        }
                    }
                    switch (hit.transform.gameObject.name.ToString())
                    {
                        case "Milk": PriceInformation.text = "E: " + MilkPrice.ToString() + " $$"; break;
                        case "Cheese": PriceInformation.text = "E: " + CheesePrice.ToString() + " $$"; break;
                        case "Meat": PriceInformation.text = "E: " + MeatPrice.ToString() + " $$"; break;
                        case "Watermelon": PriceInformation.text = "E: " + WatermelonPrice.ToString() + " $$"; break;
                        case "Cherry": PriceInformation.text = "E: " + CherryPrice.ToString() + " $$"; break;
                        case "Banana": PriceInformation.text = "E: " + BananaPrice.ToString() + " $$"; break;
                    }
                }

				else if (hit.transform.CompareTag("Cart"))
				{
					PriceInformation.text = "Press R to get CART";

					if (Input.GetKeyUp(KeyCode.R))
					{
						hit.transform.gameObject.layer = LayerMask.NameToLayer("Default");
						FirstPersonController.getInstance().cart = hit.transform.GetComponent<Cart>();
						hit.transform.SetParent(transform.root);
						hit.transform.localPosition = new Vector3(0, -0.5f, 2f);
						hit.transform.localRotation = Quaternion.Euler(0, 90f, 0);                       
					}
				}
                /*
				else if (hit.transform.CompareTag("Weight"))
                {
                    PriceInformation.text = "E: " + "Weight products";
                    if (Input.GetKeyUp(KeyCode.E) && !IsPanelActive.AnotherPanelIsActive)
                    {
                        IsPanelActive.AnotherPanelIsActive = true;
                        WeightPanel.SetActive(true);
                        fpc.Stop();
                        Cursor.visible = true;
                        string temp = "";
                        foreach (Products product in Customer.ProductsInBascet)
                        {
                            try
                            {
                                WeightProductInBascet pr = (WeightProductInBascet)product;
                                temp += pr.Name + ": " + pr.Weight.ToString() + "\n";
                            }
                            catch (System.Exception e)
                            {

                            }

                        }
                        WeightInformation.text = temp;

                    }
                }
                */
                else if (hit.transform.CompareTag("Pay"))
                {
                    PriceInformation.text = "E: " + "Pay";
                    if (Input.GetKeyUp(KeyCode.R) && !IsPanelActive.AnotherPanelIsActive)
                    {
                        IsPanelActive.AnotherPanelIsActive = true;
                        FirstPersonController.getInstance().mouseLook.enabled = false;
						/*
                        int count = 0;
                        foreach (Products product in Customer.ProductsInBascet)
                        {
                            try
                            {
                                WeightProductInBascet pr = (WeightProductInBascet)product;
                                if (pr.Weight == 0)
                                {
                                    count++;
                                }
                                
                            }
                            catch (System.Exception e)
                            {
                                Debug.LogException(e);
                            }

                        }
                        if (count != 0 || Customer.ProductsInBascet.Count == 0)
                        {
                            NoWeightPanel.SetActive(true);
                            Cursor.visible = true;
                            fpc.Stop();
                        } else
                        {
                        */
						//PayPanel.SetActive(true);
                            Cursor.visible = true;
                            fpc.Stop();
                        //}
                    }
                }
            }
        }
        /*
        if (Input.GetKeyUp(KeyCode.Escape) && (WeightPanel.activeSelf))
        {
            WeightPanel.SetActive(false);
            Cursor.visible = false;
            fpc.Go();
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            ToMenuPanel.SetActive(true);
            Cursor.visible = true;
            fpc.Stop();
        }
        */
    }
    
}

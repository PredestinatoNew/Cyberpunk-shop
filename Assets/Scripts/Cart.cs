using UnityEngine;
using System.Collections.Generic;

public class Cart : MonoBehaviour
{
    public List<GameObject> slotsInCartObj;
    public bool[] slotsInCart;

    public void AddToCartObj(GameObject obj)
    {
        for (int i = 0; i < slotsInCart.Length; i++)
        {
            if (!slotsInCart[i])
            {
				obj.transform.SetParent(slotsInCartObj[i].transform);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localRotation = Quaternion.identity;
				slotsInCart[i] = true;
                break;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slotsInCart = new bool[slotsInCartObj.Count];
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

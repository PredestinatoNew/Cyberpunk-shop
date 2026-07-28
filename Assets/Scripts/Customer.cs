using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Customer
{
    public static string Name;
    public static int Age;
    public static int Balance;
    public static int Bonuses;
    public static ArrayList ProductsToBuy = new ArrayList();
    public static List<IActions> ProductsInBascet = new List<IActions>();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActions
{
    public double CalculatePrice();
}

public abstract class Products
{
    public string Name;
    public double PriceFor;
}

public class WeightProductInBascet: Products, IActions
{
    public double Weight;
    private double price;

    public double CalculatePrice()
    {
        price = Weight * this.PriceFor;
        return price;
    }
}

public class PieceProductInBascet: Products, IActions
{

    public double CalculatePrice()
    {
        return PriceFor;
    }
}

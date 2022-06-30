using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FoodStruct
{
    public Food_SO food;
    public int price;

    public FoodStruct(Food_SO foodItem, int foodPrice)
    {
        food = foodItem;
        price = foodPrice;

    }
}

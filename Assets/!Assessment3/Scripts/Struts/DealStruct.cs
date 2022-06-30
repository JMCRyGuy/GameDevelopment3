using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DealStruct
{
    public List<FoodStruct> foods;
    public int price;
    public DealStruct(List<FoodStruct> foodItems, int foodPrice)
    {
        foods = foodItems;
        price = foodPrice;

    }



}

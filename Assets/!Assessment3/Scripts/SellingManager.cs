using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellingManager : MonoBehaviour
{
    #region Variables
    [Header("Foods for sale Range")]
    public int foodMinimum = 1;
    public int foodLimit = 2;
    [Header("Deals for sale Range")]
    public int dealMinimum = 1;
    public int dealLimit = 2;
    [Header("Foods in deals Range")]
    public int dealFoodMinimum = 2;
    public int dealFoodLimit = 2;
    [Header("Foods in deals Range")]
    public float discountMinimumBP = 0.05f;
    public float discountLimitBP = 0.25f;
    [Header("Foods in deals Range")]
    public int budget;
    public int maxBudget;
    // BP = By percent




    public List<Food_SO> foodObjects;
    public List<CreateSeller> sellers;
    [Header("Misc Variables")]
    public CreateSeller currentSeller;
    public TextMeshProUGUI listTextRef;
    public TextMeshProUGUI budgetText;
    public List<TextMeshProUGUI> inventory;

    List<FoodStruct> foodComparisonList = new List<FoodStruct>();
    public Dictionary<Food_SO, int> cheepestFoodItems = new Dictionary<Food_SO, int>();
    public Dictionary<Food_SO, int> requiredFoodAndAmount = new Dictionary<Food_SO, int>();
    public Dictionary<Food_SO, int> currentFoodAndAmount = new Dictionary<Food_SO, int>();


    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
        SellerUpdate();
        








    }

    


    public void SellerUpdate()
    {
        for (int i = 0; i < sellers.Count; i++)
        {
            List<Food_SO> randomListFood = new List<Food_SO>(foodObjects); 
            int rF = Random.Range(foodMinimum, foodLimit);
            for (int x = 0; x < rF; x++)
            {
                
                Food_SO foodRandom = randomListFood[Random.Range(0, randomListFood.Count)];
                
                int priceRandom = Random.Range(foodRandom.minCost, foodRandom.maxCost);
                
                FoodStruct foodStrutInput = new FoodStruct(foodRandom, priceRandom);
                //print("Index:" + x + "/" + rF + foodRandom.foodName + priceRandom + "Food!");
                sellers[i].foodList.Add(foodStrutInput);
                foodComparisonList.Add(foodStrutInput);
                randomListFood.Remove(foodRandom);
                

            }

            int rD = Random.Range(dealMinimum, dealLimit);
            for (int x = 0; x < rD; x++)
            {
                int rDF = Random.Range(dealFoodMinimum, dealFoodLimit);
                float amount = 0f;
                List<FoodStruct> foodListRandom = new List<FoodStruct>();
                for (int y = 0; y < rDF; y++)
                {
                    int rFLF = Random.Range(0, sellers[i].foodList.Count);
                    //print(rFLF);
                    FoodStruct foodRef = sellers[i].foodList[rFLF];
                    foodListRandom.Add(foodRef);
                    //print(foodListRandom);
                    amount += foodRef.price;
                    
                }
                sellers[i].DealMake(foodListRandom, ((int)Random.Range(amount * (1 - discountMinimumBP), amount * (1 - discountLimitBP))));


            }
            


        }
        Invoke("ShopRequirements", 3f);





    }

    public void MakePurchace(int index)
    {
        if(index >= 3)
        {
            for (int i = 0; i < currentSeller.dealList[index].foods.Count; i++)
            {
                Food_SO foodRef = currentSeller.dealList[index].foods[i].food;
                if (currentFoodAndAmount.ContainsKey(foodRef))
                {


                    print("This");
                    currentFoodAndAmount[foodRef] = currentFoodAndAmount[foodRef] + 1;

                }
                else
                {
                    print("that");
                    currentFoodAndAmount.Add(foodRef, 1);

                }





            }
            budget -= currentSeller.dealList[index].price;


        }
        else
        {


            Food_SO foodRef = currentSeller.foodList[index].food;
            print(foodRef.foodName);
            if (currentFoodAndAmount.ContainsKey(foodRef))
            {
                print("This DF");
                currentFoodAndAmount[foodRef]++;

            }
            else
            {
                print("That DF");
                
                currentFoodAndAmount.Add(foodRef, 1);
                print(foodRef.foodName);

            }


        }
        
        budget -= currentSeller.dealList[index].price;
        
        InventoryUpdate();




    }

    void InventoryUpdate()
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (currentFoodAndAmount.ContainsKey(foodObjects[i]))
            {
                inventory[i].text = foodObjects[i].foodName + ":  " + currentFoodAndAmount[foodObjects[i]];
            }
            else
            {
                currentFoodAndAmount.Add(foodObjects[i], 0);
            }
            
            
        }
        budgetText.text = budget + "Y";




    }

    public void ShopRequirements()
    {


        for (int i = foodComparisonList.Count - 1; i >= 0; i--)
        {
            if(cheepestFoodItems.ContainsKey(foodComparisonList[i].food))
            {
                int newPriceCompare = foodComparisonList[i].price;
                if (cheepestFoodItems[foodComparisonList[i].food] > newPriceCompare)
                {
                    cheepestFoodItems[foodComparisonList[i].food] = newPriceCompare;
                    //print("Replace" + newPriceCompare + foodComparisonList[i].food.foodName);
                }
                //print("Keep" + newPriceCompare + foodComparisonList[i].food.foodName);


            }
            else
            {
                cheepestFoodItems.Add(foodComparisonList[i].food, foodComparisonList[i].price);
                //print("New" + foodComparisonList[i].price + foodComparisonList[i].food.foodName);
            }




        }
        for (int i = 0; i < foodObjects.Count; i++)
        {
            
            if(cheepestFoodItems.ContainsKey(foodObjects[i]))
            {
                //print(foodObjects[i].foodName + cheepestFoodItems[foodObjects[i]]);
                
                int rAF = Random.Range(0, 3);
                if (requiredFoodAndAmount.ContainsKey(foodObjects[i]))
                {
                    requiredFoodAndAmount[foodObjects[i]] = rAF;
                    
                }
                else
                {
                    requiredFoodAndAmount.Add(foodObjects[i], rAF);
                }
                listTextRef.text = listTextRef.text + foodObjects[i].foodName + ":" + rAF + "  ";
                print(i);
                budget += cheepestFoodItems[foodObjects[i]];



            }
            else
            {
                print("Null");
            }


        }

        InventoryUpdate();






    }







    void Update()
    {
        
    }
}

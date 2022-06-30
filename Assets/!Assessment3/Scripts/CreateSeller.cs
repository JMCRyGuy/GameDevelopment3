using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateSeller : MonoBehaviour
{
    public List<FoodStruct> foodList = new List<FoodStruct>();
    public List<DealStruct> dealList = new List<DealStruct>();

    public GameObject sellerPannel;
    public List<TextMeshProUGUI> textRefs;
    public GameObject truckPannel;
    public SellingManager sellManagerRef;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OpenMenu()
    {
        sellerPannel.SetActive(true);

        for (int i = 0; i < foodList.Count; i++)
        {
            if(textRefs.Count > i)
            {
                textRefs[i].text = foodList[i].food.foodName + "  Y" + foodList[i].price;

            }


        }
        for (int i = 0; i < dealList.Count; i++)
        {

            if (textRefs.Count > i)
            {
                textRefs[i+3].text = "  Y" + dealList[i].price;

                for (int x = 0; x < dealList[i].foods.Count; x++)
                {
                    if(x <= 0)
                    {
                        textRefs[i + 3].text = dealList[i].foods[x].food.foodName + textRefs[i + 3].text;
                    }
                    else
                    {
                        textRefs[i + 3].text = foodList[x].food.name + " + " + textRefs[i + 3].text;
                    }
                    print(textRefs[i + 3].text);

                }



            }

        }

        sellManagerRef.currentSeller = this;








    }
    
    
    
    
    public void FoodMake(Food_SO foodInput, int priceInput)
    {
        
        
        





    }





    public void DealMake(List<FoodStruct> foodsInput, int priceInput)
    {
        DealStruct dealStrutInput = new DealStruct(foodsInput, priceInput);
        dealList.Add(dealStrutInput);


    }











}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FoodManager : MonoBehaviour
{
    [SerializeField] private FoodSO[] foodSOArray;
    [SerializeField] private PillSO[] pillSOArray;
    public int numberOfFood = 3;
    public int numberOfPills = 4;
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

   private void GameManager_OnStateChanged(object sender, System.EventArgs e)
   {
       if (GameManager.Instance.IsCountdownToStart())
       {
           
           for (int i = 0; i < numberOfFood; i++)
           {
               SpawnFood();
           }
           for (int i = 0; i < numberOfPills; i++)
           {
               SpawnPills();
           }
          
           
       }
   }
   
   public void SpawnFood()
   {
       foreach (FoodSO foodSo in foodSOArray)
       {
              Vector3 spawnPosition = new Vector3(Random.Range(-26f, 10f),  Random.Range(-17f,8f) , 0);
          
           Vector3Int cellPosition = tilemap.WorldToCell(spawnPosition);
           TileBase tile = tilemap.GetTile(cellPosition);
           if (tile == null)
           {
               // Si aucune collision n'est détectée, instanciez l'objet à la position générée
               Instantiate(foodSo.prefab, spawnPosition, Quaternion.identity);
           }
           else
           {
                // Sinon, réessayez
                SpawnFood();
           }
       
       }
   }
   public void SpawnPills()
   {
       foreach (PillSO pillSo in pillSOArray)
       {
           Vector3 spawnPosition = new Vector3(Random.Range(-26f, 10f),  Random.Range(-17f,8f) , 0);
          
           Vector3Int cellPosition = tilemap.WorldToCell(spawnPosition);
           TileBase tile = tilemap.GetTile(cellPosition);
           if (tile == null)
           {
               // Si aucune collision n'est détectée, instanciez l'objet à la position générée
               Instantiate(pillSo.prefab, spawnPosition, Quaternion.identity);
           }
           else
           {
                // Sinon, réessayez
                SpawnPills();
           }
       
       }
   }
}

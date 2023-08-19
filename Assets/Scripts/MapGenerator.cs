using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;

public class MapGenerator : MonoBehaviour 
{

    [SerializeField]
    private int dims;

    [SerializeField]
    private float xOrg;
    [SerializeField]
    private float yOrg;
    
    private float chunkdims = 32.0F;
    private float scale = 1.1F;

    
    private CellMap map = new CellMap();
    

    public void generateNewMap()
    {
        if (xOrg == 0.0 && yOrg == 0.0){
            xOrg = Random.Range(-256.0F, 256.0F);
            yOrg = Random.Range(-256.0F, 256.0F);
        }
        for (var x = 0; x < dims; x++){
            for(var y = 0; y < dims; y++){
                float xCoord = xOrg + ((float)x) / chunkdims * scale;
                float yCoord = yOrg + ((float)y) / chunkdims * scale;
                map.BaseCells.Add(new Cell(x, y, (int)(Mathf.PerlinNoise(xCoord, yCoord)*8)));
            }
        }
        
        // export to json
        string export = JsonUtility.ToJson(map);
        File.WriteAllText(Application.persistentDataPath + "/Saves/save1/basemap.json", export);
    }

    void Start(){
        if(!Directory.Exists(Application.persistentDataPath + "/Saves")){
            var Saves = Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }
        if(!Directory.Exists(Application.persistentDataPath + "/Saves/save1")){
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves/save1");
            File.Create(Application.persistentDataPath + "/Saves/save1/basemap.json");
        }
    }

}

[System.Serializable]
public class Cell{
    public int x;
    public int y;
    public int height;

    public Cell(int xPos, int yPos, int cellHeight)
   {
      x = xPos;
      y = yPos;
      height = cellHeight;
   }
}
[System.Serializable]

public class CellMap{
    public List<Cell> BaseCells;
    public List<Cell> GroundCells;
    public CellMap(){
        BaseCells = new List<Cell>();
        GroundCells = new List<Cell>();
    }
}
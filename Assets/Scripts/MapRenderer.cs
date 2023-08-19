using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.IO;


public class MapRenderer : MonoBehaviour 
{

    [SerializeField]
    Tilemap tilemap;

    [SerializeField]
    TileBase[] tilepalette;


    void Start(){
        Redraw();
    }
    public void Redraw(){
        string rawText = File.ReadAllText(Application.persistentDataPath + "/Saves/save1/basemap.json");
        CellMap map = JsonUtility.FromJson<CellMap>(rawText);

        foreach (Cell cell in map.BaseCells){
            tilemap.SetTile(new Vector3Int(cell.x-8, cell.y-8, 0), tilepalette[cell.height]);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenManager : MonoBehaviour
{
    public GameObject blockPrefab;
    public float topSpace = 1f;
    public float spaceBetweenBlocks = 0.5f;
    public int numBlockRows = 4;

    Vector2 screenWidthSize;
    float blockHeight;
    float blockWidth;
    List<GameObject> allBlocks = new List<GameObject>();

    private void destroyAllBlocks()
    {
        foreach (GameObject block in allBlocks)
        {
            Destroy(block);
        }
    }

    public void generateBlocks()
    {
        destroyAllBlocks();

        for (int r = 1; r <= numBlockRows; r++)
        {
            {
                float yVal = screenWidthSize.y - r * (blockHeight / 2 + topSpace);
                float xVal = 0;
                Vector3 spawnPos = new Vector3(xVal, yVal, 10);
                GameObject newBlock = Instantiate(blockPrefab, spawnPos, Quaternion.identity);
                newBlock.name = "Block";
                allBlocks.Add(newBlock);
            }

            for (int i = 1;
                i * (spaceBetweenBlocks + blockWidth) < screenWidthSize.x &&
                -i * (spaceBetweenBlocks + blockWidth) > -screenWidthSize.x; 
                i++)
            {
                {
                    float yVal = screenWidthSize.y - r * (blockHeight / 2 + topSpace);
                    float xVal = i * (spaceBetweenBlocks + blockWidth);
                    Vector3 spawnPos = new Vector3(xVal, yVal, 10);
                    GameObject newBlock = Instantiate(blockPrefab, spawnPos, Quaternion.identity);
                    newBlock.name = "Block";
                    allBlocks.Add(newBlock);
                }

                {
                    float yVal = screenWidthSize.y - r * (blockHeight / 2 + topSpace);
                    float xVal = -i * (spaceBetweenBlocks + blockWidth);
                    Vector3 spawnPos = new Vector3(xVal, yVal, 10);
                    GameObject newBlock = Instantiate(blockPrefab, spawnPos, Quaternion.identity);
                    newBlock.name = "Block";
                    allBlocks.Add(newBlock);
                }
            }
        }
    }

    void Start()
    {
        blockHeight = blockPrefab.GetComponent<Renderer>().bounds.size.y;
        blockWidth = blockPrefab.GetComponent<Renderer>().bounds.size.x;
        screenWidthSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        generateBlocks();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class levelGen : MonoBehaviour
{
    public GameObject This;
    public Movement playerMovement;
    public score playerScore;
    //public GameObject one, two, three, four, five, six, seven, eight;
    public Rigidbody2D playerRb;
    //public BoxCollider2D oneE, twoE, threeE, fourE, fiveE, sixE, sevenE, eightE;
    //public ArrayList oneC = new ArrayList();
    //public ArrayList twoC = new ArrayList();
    //public ArrayList threeC = new ArrayList();
    //public ArrayList fourC = new ArrayList();
    //public ArrayList fiveC = new ArrayList();
    //public ArrayList sixC = new ArrayList();
    //public ArrayList sevenC = new ArrayList();
    //public ArrayList obstacles = new ArrayList();
    public ArrayList savedSpots = new ArrayList();
    public GameObject[] gameObjectList;
    public BoxCollider2D[] boxColliderList;
    public int blocksGenerated = -2;
    public float level = 5;
    private Vector2 spawnLoc = new Vector2(-6,-1);
    // Start is called before the first frame update
    void Start()
    {
        savedSpots.Add(spawnLoc.x-10);
        savedSpots.Add(spawnLoc.x-5);
        //oneC.Add(one);
        //oneC.Add(oneE);
        //obstacles.Add(oneC);
 
        //twoC.Add(two);
        //twoC.Add(twoE);
        //obstacles.Add(twoC);

        //threeC.Add(three);
        //threeC.Add(threeE);
        //obstacles.Add(threeC);

        //fourC.Add(four);
        //fourC.Add(fourE);
        //obstacles.Add(fourC);

        //fiveC.Add(five);
        //fiveC.Add(fiveE);
        //obstacles.Add(fiveC);

        //sixC.Add(six);
        //sixC.Add(sixE);
        //obstacles.Add(sixC);

        //sevenC.Add(seven);
        //sevenC.Add(sevenE);
        //obstacles.Add(sevenC);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(savedSpots[0].GetType());
        float savedSpot = (float)savedSpots[0];
        if (playerRb.transform.position.x > savedSpot){
        gen();
        }
    }

    //void Spawn(ArrayList list, BoxCollider2D temp1)
    //{
    //    GameObject spawningC = Instantiate((GameObject)list[0]);
    //    Destroy(spawningC, 10);
    //    savedSpots[0] = savedSpots[1];
    //    savedSpots[1] = spawnLoc.x;
    //    spawningC.transform.position = new Vector2(spawnLoc.x - .5f, spawnLoc.y);
    //    spawningC.transform.parent = This.transform;
    //    spawnLoc = spawnLoc + temp1.offset;
    //    level += temp1.offset.y;
    //    blocksGenerated++;
    //    playerMovement.increaseSpeed();
    //    playerScore.increaseScore();
    //}
    //void Spawn3(GameObject gameObject, BoxCollider2D temp1)
    //{
    //    GameObject spawningC = Instantiate(gameObject);
    //    Destroy(spawningC, 10);
    //    savedSpots[0] = savedSpots[1];
    //    savedSpots[1] = spawnLoc.x;
    //    gameObject.transform.position = new Vector2(spawnLoc.x - .5f, spawnLoc.y);
    //    gameObject.transform.parent = This.transform;
    //    spawnLoc = spawnLoc + temp1.offset;
    //    level += temp1.offset.y;
    //    blocksGenerated++;
    //    playerMovement.increaseSpeed();
    //    playerScore.increaseScore();
    //}

    void Spawn(GameObject gameObject, BoxCollider2D boxCollider)
    {
        GameObject spawningC = Instantiate(gameObject);
        Destroy(spawningC, 10);
        savedSpots[0] = savedSpots[1];
        savedSpots[1] = spawnLoc.x;
        spawningC.transform.position = new Vector2(spawnLoc.x - .5f, spawnLoc.y);
        spawningC.transform.parent = This.transform;
        Debug.Log("Object moved");
        spawnLoc = spawnLoc + boxCollider.offset;
        level += boxCollider.offset.y;
        blocksGenerated++;
        playerMovement.increaseSpeed();
        playerScore.increaseScore();
    }

    //void gen(){
    //    int up = 8-(int)level;
    //    int down = (int)level-1;
    //    ArrayList tempObstacles = new ArrayList();
    //    foreach(ArrayList list in obstacles){
    //        BoxCollider2D temp1 = (BoxCollider2D)list[1];
    //        if(temp1.offset.y <= 0 && temp1.offset.y*-1 <= down || temp1.offset.y >= 0 && temp1.offset.y <= up){
    //            tempObstacles.Add(list);
    //        }
    //    }
    //    System.Random r = new System.Random();
    //    int selectedGen = r.Next(0, tempObstacles.Count);
    //    //Debug.Log(tempObstacles[selectedGen]);
    //    Spawn3((GameObject)((ArrayList)tempObstacles[selectedGen])[0], (BoxCollider2D)((ArrayList)tempObstacles[selectedGen])[1]);

    //}

    void gen()
    {
        int up = 8 - (int)level;
        int down = (int)level - 1;
        ArrayList tempObstacles = new ArrayList();
        for (int i = 0; i < gameObjectList.Length; i++)
        {
            BoxCollider2D temp1 = boxColliderList[i];
            if (temp1.offset.y <= 0 && temp1.offset.y * -1 <= down || temp1.offset.y >= 0 && temp1.offset.y <= up)
            {
                tempObstacles.Add(i);
            }
        }
        System.Random r = new System.Random();
        int selectedGen = r.Next(0, tempObstacles.Count);
        Debug.Log(tempObstacles +""+ selectedGen);
        Spawn(gameObjectList[(int)tempObstacles[selectedGen]], (BoxCollider2D)boxColliderList[(int)tempObstacles[selectedGen]]);

    }
}  
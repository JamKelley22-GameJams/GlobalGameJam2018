using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowScriptV : MonoBehaviour
{

    public GameObject redBloodCellPrefab;
    //public GameObject GFX;
    public float minVal;
    public float maxVal;
    [Range(.11f, 1f)]
    public float spawnRate;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float chance = Random.Range(0f, 10f);
        if (chance >= 1 / spawnRate && !PauseMenu.gameIsPaused)
        {
            GameObject cell;
            cell = Instantiate(redBloodCellPrefab, new Vector3(-transform.lossyScale.x / 2 + transform.position.x, Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2) + transform.position.y, 0), transform.rotation);

            cell.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -Random.Range(minVal, maxVal));

            Color c = redBloodCellPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().color;
            c.a = Random.Range(.2f, .3f);
            redBloodCellPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().color = c;
            //GFX.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, Random.Range(.15f, .2f));
            //Debug.Log(cell.transform.GetChild(0).GetComponent<SpriteRenderer>().color);
            StartCoroutine(fadeCell(cell));


        }

    }

    IEnumerator fadeCell(GameObject o)
    {
        yield return new WaitForSeconds(5f);

        yield return new WaitForSeconds(5f);
        Destroy(o);
    }

}
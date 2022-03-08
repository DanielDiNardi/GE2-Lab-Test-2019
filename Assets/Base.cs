using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float tiberium = 0;

    public TextMeshPro text;

    public GameObject fighterPrefab;

    IEnumerator MineTiberium()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            tiberium = tiberium + 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
        {
            r.material.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
        }

        StartCoroutine(MineTiberium());
    }

    // Update is called once per frame
    void Update()
    {
        if(tiberium >= 10)
        {
            tiberium = tiberium - 10;

            foreach (Renderer r in fighterPrefab.GetComponentsInChildren<Renderer>())
            {
                r.material = GetComponent<Renderer>().material;
            }

            Instantiate(fighterPrefab, transform.position, transform.rotation);
        }

        text.text = "" + tiberium;
    }
}

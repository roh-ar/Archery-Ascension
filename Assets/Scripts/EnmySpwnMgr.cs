using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnmySpwnMgr : MonoBehaviour
{
    [SerializeField]
    private GameObject enmyPref;

    [SerializeField]
    private GameObject enmContainer;

    private bool isPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sroutn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator sroutn()
    {
        while (isPlayer==false)
        {
            Vector3 pos=new Vector3(Random.Range(-9.02f, 8.99f), 5.35f, 0);
            GameObject createdEnmy=Instantiate(enmyPref, pos, Quaternion.identity);
            createdEnmy.transform.parent = enmContainer.transform; 
            yield return new WaitForSeconds(6.0f);

        }
    }

    public void onPlayerlife()
    {
        
        isPlayer = true;
        Debug.Log(isPlayer);
    }


}

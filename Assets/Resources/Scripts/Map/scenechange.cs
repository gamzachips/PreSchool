using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{

    public float changetime = 3f;
    public float curtime = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;

        if(curtime> changetime)
        {
            ScneManager.Instance.ChangeMain();
            
        }
    }
}

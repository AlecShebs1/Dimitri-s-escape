using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPSHANIM : MonoBehaviour
{

    public Animator anim;
    [SerializeField]public GameObject ppsh;
    public GameObject rightHand;
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        ppsh = transform.gameObject;
        ppsh.transform.position = GameObject.FindGameObjectWithTag("PPSH").transform.position;

      
    }

    // Update is called once per frame
    void Update()
    {
        ppsh.transform.position = GameObject.FindGameObjectWithTag("PPSH").transform.position;

        if (ppsh.activeSelf == true && Input.GetKey(KeyCode.R)) 
        {
            anim.SetTrigger("reload");
        }   
    }
}

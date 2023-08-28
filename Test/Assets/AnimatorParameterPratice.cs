using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        animator.SetFloat("New Float", 3.1f);
        animator.SetInteger("New Int", 1);
        animator.SetBool("New Bool", true);
        animator.SetTrigger("New Trigger");


        animator.transform.forward = Vector3.forward;

        Resources.Load(string.Empty);
        Resources.UnloadAsset(null);
        //Resources.
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

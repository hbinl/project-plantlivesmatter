using UnityEngine;
using System.Collections;

public class LoadingAnimator : MonoBehaviour {
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("chainsaw-action", true);
    }
}

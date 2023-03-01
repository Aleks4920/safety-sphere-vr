using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnimatorController : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private TreeScript tree;
    private void Update()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsCut", tree.GetTreeState());
    }
}

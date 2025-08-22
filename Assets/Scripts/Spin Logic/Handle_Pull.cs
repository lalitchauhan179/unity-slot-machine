using UnityEngine;

public class HandleController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Call this when player pulls handle
    public void PullHandle()
    {
        animator.SetTrigger("Pull");
    }
}

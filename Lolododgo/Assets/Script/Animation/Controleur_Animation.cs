using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controleur_Animation : MonoBehaviour
{
    public void Start_animator_controler(Animator animator)
    {
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsShooting", false);
        animator.SetBool("Se_prepare_a_tirer", false);
    }


    public void setWalking(bool walk, Animator animator)
    {
        animator.SetBool("IsWalking", walk);
        animator.SetBool("IsShooting", false);
        animator.SetBool("Se_prepare_a_tirer", false);
    }

    public void setShooting(bool fight, Animator animator)
    {
        animator.SetBool("IsShooting", fight);
        animator.SetBool("IsWalking", false);
    }

    public void se_prepare_a_tirer(bool seprepare, Animator animator)
    {
        animator.SetBool("Se_prepare_a_tirer", seprepare);
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsShooting", false);
    }

    public new void animation(Unite unite_a_animer, Animator animator)
    {
        if (unite_a_animer.IsWalking)
        {
            setWalking(true, animator);
        }
        if (unite_a_animer.IsShooting)
        {
            setShooting(true, animator);
        }
        if (unite_a_animer.en_position_pour_tirer)
        {
            se_prepare_a_tirer(true, animator);
        }

        if(!unite_a_animer.IsWalking && !unite_a_animer.IsShooting && !unite_a_animer.en_position_pour_tirer)
        {
            setWalking(false, animator);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCfollow : MonoBehaviour
{
           //定义接收导航网络组件
           private UnityEngine.AI.NavMeshAgent nav;
           //定义目的地的方块
           public Transform target;
           void Start()
           {
               //赋值
               nav = this.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
           }
           void Update()
           {
               //设置目的地的位置为方块的位置
               nav.SetDestination(target.position);
           }
}    

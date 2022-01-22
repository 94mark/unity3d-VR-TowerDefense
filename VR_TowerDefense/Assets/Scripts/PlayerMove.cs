using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5; //이동 속도
    CharacterController cc; //CharacaterController 컴포넌트
    public float gravity = -20; //중력 가속도의 크기
    float yVelocity = 0; //수직 속도

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        //사용자의 입력에 따라 전후좌우로 이동
        //1. 사용자의 입력을 받는다
        float h = ARAVRInput.GetAxis("Horizontal");
        float v = ARAVRInput.GetAxis("Vertical");
        //2. 방향을 만든다
        Vector3 dir = new Vector3(h, 0, v);
        //2-1. 중력을 적용한 수직 방향 추가 v = v0 + at
        yVelocity += gravity * Time.deltaTime;
        //2-2. 바닥에 있을 경우, 수직 항력을 처리하기 위해 속도를 0으로 한다
        if(cc.isGrounded)
        {
            yVelocity = 0;
        }
        
        dir.y = yVelocity;
        //3. 이동
        cc.Move(dir * speed * Time.deltaTime);
    }
}

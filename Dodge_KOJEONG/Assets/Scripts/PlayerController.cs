using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        public Rigidbody playerRigidbody;
        public float speed = 8f;
        private int score = 0; // 플레이어의 스코어
        // public GameObject weapon; // 플레이어의 무기 오브젝트
        // private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        // 무기 오브젝트 찾기 (자식 오브젝트 중에서 찾거나, 인스펙터에서 직접 할당)
        // weapon = transform.Find("WeaponObject").gameObject;

        // animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        float xSpeed = xInput*speed;
        float zSpeed = zInput*speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

        // 플레이어가 A 키를 누르면 무기 휘두르기
        // if(Input.GetKeyDown(KeyCode.A))
        // {
        //     if(weapon != null)
        //         weapon.GetComponent<Weapon>().Swing();
        //         animator.SetTrigger("SwingWeapon"); // 애니메이터의 SwingWeapon 트리거를 활성화
        // }
    }

    public void Die(){
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }

    public void IncreaseScore()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if(gameManager != null){
            gameManager.IncreaseScore(10); // GameManager의 IncreaseScore 메소드를 호출하여 스코어를 10 증가시킵니다.
        }
        Debug.Log("Score increased! Current score: " + score);
    }
}

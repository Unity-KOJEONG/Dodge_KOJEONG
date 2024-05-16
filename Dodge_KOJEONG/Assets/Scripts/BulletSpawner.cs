using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    private int health = 100;
    private bool canSpawnBullets = true;

    // ȯȣ ���带 ������ ����
    public AudioClip cheerSound;

    // AudioSource ������Ʈ�� ������ ����
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
        // AudioSource ������Ʈ �ʱ�ȭ
        audioSource = gameObject.AddComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= spawnRate){
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

        // timeAfterSpawn�� ����
        if (!canSpawnBullets)
            return;

        timeAfterSpawn += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 오브젝트에 닿아 있는 상태에서 A키를 누르는 순간
        if (Input.GetKey(KeyCode.A))
        {
            // 랜덤 데미지 계산
            int damage = Random.Range(20, 51);
            // 체력 감소
            health -= damage;

            // 체력이 0 이하면 사망 처리
            if (health <= 0)
            {
                Die();
            }
        }
    }

    // �Ѿ� �̹߻� �޼���
    private void DisableBullets()
    {
        canSpawnBullets = false;
    }

    private void Die()
    {
        // ȯȣ ���� ���
        if (cheerSound != null)
        {
            audioSource.PlayOneShot(cheerSound);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    //衝突効果音
    public AudioClip audioClip1;

    void Start()
    {

    }

    void Update()
    {
        // キューブを移動させる
        // Time.deltaTimeは前フレームからの経過時間を返す
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BlockTag" || collision.gameObject.tag == "GroundTag")
        {
            GetComponent<AudioSource>().PlayOneShot(this.audioClip1);
        }
    }


}

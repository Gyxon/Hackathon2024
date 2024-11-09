using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentParticle : MonoBehaviour
{
    public float destroyTime;
    public string [] comments;
    private int commentID;
    public Text myText;
    // Start is called before the first frame update
    void Start()
    {
        commentID = Random.Range(0, comments.Length);
        myText.text = comments[commentID];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + (Random.Range(0.4f, 7.6f) * Time.deltaTime));
        Destroy(gameObject, destroyTime);
    }
}

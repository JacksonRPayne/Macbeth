using UnityEngine;

[System.Serializable]
public class Phrase {

    [TextArea(3, 10)]
    public string Content;
    public float DeliveryTime;
    public float ScrollSpeed;
}

[System.Serializable]
public class Sentence
{
    public Phrase[] Phrases;
}
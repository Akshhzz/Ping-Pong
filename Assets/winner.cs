using UnityEngine;
using UnityEngine.UI;   
public class winner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Text wintext;
    void Start()
    {
        if (logicscript.winner == 1)
        {
            wintext.text = "Player 1 Wins!";
        }
        else if (logicscript.winner == 2)
        {
            if (logicscript.istwoplayer)
            {
                wintext.text = "Player 2 Wins!";
            }
            else
            {
                wintext.text = "Computer Wins!";
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

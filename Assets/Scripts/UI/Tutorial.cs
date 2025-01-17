using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text affichage;
    public GameObject messageContainer;
    // Start is called before the first frame update
    void Start()
    {
        LancerTutoriel();
    }

    public void LancerTutoriel()
    {
        StartCoroutine(TutorielEnumerator());
    }

    void AfficherMessage(string contenuMessage)
    {
        affichage.GetComponent<Text>().text = contenuMessage;
        messageContainer.SetActive(true);
    }

    IEnumerator TutorielEnumerator()
    {
        AfficherMessage("Welcome to your base site. Your objective is\nto build a huge base to get more workers and money");
        yield return new WaitForSeconds(6);
        AfficherMessage("Asteorids are falling down pretty frequently on this\nplanet, you should protect your base from them");
        yield return new WaitForSeconds(6);
        AfficherMessage("You can use UP and DOWN arrows to go deeper\nunderground. The deeper your base is , the safer it is");
        yield return new WaitForSeconds(6);
        AfficherMessage("You can open the menu with the right button\nto buy new habitations / storage rooms / factories");
        yield return new WaitForSeconds(6);
        AfficherMessage("You can also call spaceships to import new resources\nand new workers, which can work in factories");
        yield return new WaitForSeconds(6);
        AfficherMessage("To obtain money, you should have at least 1 factory and\n1 worker. The more you have , the more money you earn");
        yield return new WaitForSeconds(6);
        messageContainer.SetActive(false);
    }
}

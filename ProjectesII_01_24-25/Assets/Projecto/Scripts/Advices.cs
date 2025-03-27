using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;
public class Advices : MonoBehaviour
{

    public int maxNumber = 18;
    // Start is called before the first frame update
    int numberOfAdvice; // This is in case we want to hardcode it
    public TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        int randomValue = Random.Range(0, maxNumber); // Número aleatorio entre 0 y 100

        switch (randomValue)
        {
            case 0:
                texto.text = "Tip 10: There are two words that will open many doors for you: “pull” and “push.”";
                break;

            case 1:
                texto.text = "Tip 23: Traffic cones scream from their utter sexual dissatisfaction.";
                break;

            case 2:
                texto.text = "Tip 160: As a Chinese philosopher once said: “Xinxanxu xuxa xinxin.” No idea what it means, but it’s definitely true.";
                break;

            case 3:
                texto.text = "Tip 104: When you meet someone, don’t judge them. Wait until they leave—then judge them.";
                break;

            case 4:
                texto.text = "Tip 76: If you like a girl, walk up and ask, “Excuse me, does this handkerchief smell like chloroform to you?” She’ll fall at your feet.";
                break;

            case 5:
                texto.text = "Tip 32: An American philosopher once said: “One extra-large cheeseburger with extra cheese, two large fries, and a giant-sized drink, please.”";
                break;

            case 6:
                texto.text = "Tip 94: If you see a priest talking to a child, call the police. 99% of the time, you’ll be right. The other 1%? Turned out it wasn’t a kid but a dwarf.";
                break;

            case 7:
                texto.text = "Tip 203: Spaniards are humans who love ham and killing bulls. You can spot them because they end every sentence with “OLE!”";
                break;

            case 8:
                texto.text = "Tip 905: Did you know the first man in space was Spanish? His name was Carrero Blanco. (Note: Dark historical reference—adjusted for clarity.)";
                break;
            case 9:
                texto.text = "Tip 5: Women can do many things: clean, cook, do laundry… Did I mention cook?";
                break;
            case 10:
                texto.text = "Tip 555: In a race, the one who runs the fastest usually wins.";
                break;
            case 11:
                texto.text = "Tip 38: Any resemblance to reality is intentional and meant to offend.";
                break;
            case 12:
                texto.text = "Tip 3: If a woman gets mad at you, she’s probably on her period.";
                break;
            case 13:
                texto.text = "Tip 44: “UNGAUNGA U-U-U-U-U UNGA!” which, in teenager-speak, means “BOOOOOOBS!”";
                break;
            case 14:
                texto.text = "Tip 8: Poop, a solid waste material, goes in a primitive device called toilet, instead of the common goth alien.";
                break;
            case 15:
                texto.text = "Tip 0.2: Mobile gamers are less “gamer” than console/PC players… and also less virgin.";
                break;
            case 16:
                texto.text = "Tip Happy Birthday: If you keep having birthdays, you’ll eventually die.";
                break;
            case 17:
                texto.text = "Tip 666: Never break someone’s heart—they only have one. Break their bones instead; there are 206 to choose from.";
                break;

            default:
                texto.text = "No hay consejo disponible para este valor.";
                break;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

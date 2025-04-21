using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;
using TMPro;

public class Advices : MonoBehaviour
{
    public int maxNumber = 18;
    public TextMeshProUGUI texto;

    void Start()
    {
        StartCoroutine(ShowRandomAdvice());
    }

    IEnumerator ShowRandomAdvice()
    {
        yield return LocalizationSettings.InitializationOperation;

        string idiomaActual = LocalizationSettings.SelectedLocale.Identifier.Code;
        int randomValue = Random.Range(0, maxNumber);

        if (idiomaActual == "en")
        {
            switch (randomValue)
            {
                case 0:
                    texto.text = "Tip 10: There are two words that will open many doors for you: �pull� and �push.�";
                    break;

                case 1:
                    texto.text = "Tip 23: Traffic cones scream from their utter sexual dissatisfaction.";
                    break;

                case 2:
                    texto.text = "Tip 160: As a Chinese philosopher once said: �Xinxanxu xuxa xinxin.� No idea what it means, but it�s definitely true.";
                    break;

                case 3:
                    texto.text = "Tip 104: When you meet someone, don�t judge them. Wait until they leave�then judge them.";
                    break;

                case 4:
                    texto.text = "Tip 76: If you like a girl, walk up and ask, �Excuse me, does this handkerchief smell like chloroform to you?� She�ll fall at your feet.";
                    break;

                case 5:
                    texto.text = "Tip 32: An American philosopher once said: �I'll have two number 9s, a number 9 large, a number 6 with extra dip, a number 7, two number 45s, one with cheese, and a large soda.�";
                    break;

                case 6:
                    texto.text = "Tip 94: If you see a priest talking to a child, call the police. 99% of the time, you�ll be right. The other 1%? Turned out it wasn�t a kid but a dwarf.";
                    break;

                case 7:
                    texto.text = "Tip 203: Spaniards are humans who love ham and killing bulls. You can spot them because they end every sentence with �OLE!�";
                    break;

                case 8:
                    texto.text = "Tip 905: Did you know the first man in space was Spanish? His name was Carrero Blanco. (Note: Dark historical reference�adjusted for clarity.)";
                    break;
                case 9:
                    texto.text = "Tip 5: Women can do many things: clean, cook, do laundry� Did I mention cook?";
                    break;
                case 10:
                    texto.text = "Tip 555: In a race, the one who runs the fastest usually wins.";
                    break;
                case 11:
                    texto.text = "Tip 38: Any resemblance to reality is intentional and meant to offend.";
                    break;
                case 12:
                    texto.text = "Tip 3: If a woman gets mad at you, she�s probably on her period.";
                    break;
                case 13:
                    texto.text = "Tip 44: �UNGAUNGA U-U-U-U-U UNGA!� which, in teenager-speak, means �BOOOOOOBS!�";
                    break;
                case 14:
                    texto.text = "Tip 8: Poop, a solid waste material, goes in a primitive device called toilet, instead of the common goth alien.";
                    break;
                case 15:
                    texto.text = "Tip 0.2: Mobile gamers are less �gamer� than console/PC players� and also less virgin.";
                    break;
                case 16:
                    texto.text = "Tip Happy Birthday: If you keep having birthdays, you�ll eventually die.";
                    break;
                case 17:
                    texto.text = "Tip 666: Never break someone�s heart�they only have one. Break their bones instead; there are 206 to choose from.";
                    break;

                default:
                    texto.text = "No hay consejo disponible para este valor.";
                    break;
            }
        }
        else if (idiomaActual == "es")
        {
            switch (randomValue)
            {
                case 0:
                    texto.text = "Consejo 10: Hay dos palabras que pueden abrir muchas puertas: �tira� y �empuja�";
                    break;

                case 1:
                    texto.text = "Consejo 23: Los conos de trafico gritan debido a su frustraci�n sexual en su vida diaria.";
                    break;

                case 2:
                    texto.text = "Consejo 160: Un sabio filosofo chino una vez dijo �Xinxanxu Aloz tles delicia�. Ni idea de que siginfica, pero seguro que es verdad.";
                    break;

                case 3:
                    texto.text = "Consejo 104: Cuando conozcas a alguien, �no los juzgues! Espera a que se vayan para poder juzgarlos.";
                    break;

                case 4:
                    texto.text = "Consejo 76: Si te gusta una chica, acercate a ella y preguntale, �Perdone, �este pa�uelo le huele a cloroformo?� Seguro que cae rendida a tus pies";
                    break;

                case 5:
                    texto.text = "Consejo 32: Un filosofo americano una vez dijo �Que sean dos 9, un 9 grande, un 6 con extra de salsa, un 7, dos 45, uno con queso y soda grande.�";
                    break;

                case 6:
                    texto.text = "Consejo 94: Si ves a un cura hablando con un ni�o, llama a la policia. el 99% de las veces acertar�s. Y el otro 1% resultara ser un enano.";
                    break;

                case 7:
                    texto.text = "Consejo 203: Sab�as que hay humanos que matan toros en el vasto universo de URANUS EXPRESS �. Puedes identificarlos ya que terminan las frases con un �OLE!� OLE!";
                    break;

                case 8:
                    texto.text = "Consejo 905: Probablemente lo sabr�s, pero el primer hombre en ir al espac�o fue un politico espa�ol llamado Carrero Blanco";
                    break;
                case 9:
                    texto.text = "Consejo 5: Las muejeres peuden hacer much�simas cosas como: Limpiar, cocinar, hacer la colada... cocinar... y... ehhhh...";
                    break;
                case 10:
                    texto.text = "Consejo 555: �Sab�as que el corredor mas r�pido en una carrera, en el 100% de las veces gana? Asi que si quieres ganar apuesta por el mas r�pido";
                    break;
                case 11:
                    texto.text = "Consejo 38: Cualquier parecido con la realidad ES intencionado y dise�ado para ofender.";
                    break;
                case 12:
                    texto.text = "Consejo 3: Si una mujer esta enfadada con usted. No se preocupe, probablemente este pasando por su ciclo menstrual";
                    break;
                case 13:
                    texto.text = "Consejo 44: �UUUUU-UUUUUUHHHH- AAAAAAAARGHHHH! UUUH UUUH UUUH� en adolescente significa �Pechos�";
                    break;
                case 14:
                    texto.text = "Consejo 8: Los excrementos, un material desechado por el cuerpo humano, va en un primitivo dispositivo llamado ba�o, en vez de ir en los aliens goticos comunes en URANUS EXPRESS �";
                    break;
                case 15:
                    texto.text = "Consejo 0.2: Los jugadores de telefono, son menos �gamers� que los de consola/PC... Aunque son menos virgenes :(";
                    break;
                case 16:
                    texto.text = "Consejo Feliz CUMplea�os: El 100% de las personas que sufren cumplea�os suelen morir.";
                    break;
                case 17:
                    texto.text = "Consejo 666: Nunca les rompas el coraz�n a la gente, solo tienen uno. Mejor rompeles los huesos; tienes 206 para escoger";
                    break;

                default:
                    texto.text = "No hay consejo disponible para este valor.";
                    break;
            }
        }
        else if (idiomaActual == "ca")
        {
            switch(randomValue)
            {
                case 0:
                    texto.text = "Consell 10: Hi ha dues paraules que poden obrir moltes portes: �estira� i �empeny�.";
                    break;

                case 1:
                    texto.text = "Consell 23: Els cons de tr�nsit criden per la seva frustraci� sexual acumulada.";
                    break;

                case 2:
                    texto.text = "Consell 160: Un savi fil�sof xin�s va dir un dia: �Xinxanxu Aloz tles delicia�. No tenim ni idea del que vol dir, per� segur que �s veritat.";
                    break;

                case 3:
                    texto.text = "Consell 104: Quan coneguis alg�, no el jutgis immediatament... Espera que marxi i llavors ja pots jutjar amb calma.";
                    break;

                case 4:
                    texto.text = "Consell 76: Si t�agrada una noia, acosta-t�hi i pregunta-li: �Perdona, aquest mocador fa olor a cloroform?� Segur que cau rendida.";
                    break;

                case 5:
                    texto.text = "Consell 32: Un fil�sof americ� va dir un dia: �Posa'm dos n�mero 9, un 9 gran, un 6 amb extra de salsa, un 7, dos 45, un amb formatge, i una beguda gran.�";
                    break;

                case 6:
                    texto.text = "Consell 94: Si veus un capell� parlant amb un nen, truca la policia. El 99% de les vegades encertar�s. I l'altre 1%? Era un nan.";
                    break;

                case 7:
                    texto.text = "Consell 203: Sabies que hi ha humans que maten toros i mengen pernil? Es fan dir espanyols, i solen acabar les frases amb un �OL�!�";
                    break;

                case 8:
                    texto.text = "Consell 905: El primer home a viatjar a l'espai va ser Carrero Blanco. No era astronauta, per� gaireb�.";
                    break;

                case 9:
                    texto.text = "Consell 5: Les dones poden fer moltes coses: netejar, cuinar, fer la bugada... He dit cuinar? Ehhh...";
                    break;

                case 10:
                    texto.text = "Consell 555: Sabies que en una cursa, el que corre m�s r�pid sol guanyar? Aix� que si vols apostar, aposta pel r�pid.";
                    break;

                case 11:
                    texto.text = "Consell 38: Qualsevol semblan�a amb la realitat �S intencionada i pensada per ofendre.";
                    break;

                case 12:
                    texto.text = "Consell 3: Si una dona est� enfadada amb tu, probablement �s perqu� t� el seu per�ode..";
                    break;

                case 13:
                    texto.text = "Consell 44: �UUUUU-UUUUUUHHHH- AAAAAAAARGHHHH! UUUH UUUH UUUH!� En idioma adolescent, aix� vol dir: �Pits�.";
                    break;

                case 14:
                    texto.text = "Consell 8: Els excrements, una subst�ncia s�lida rebutjada pel cos hum�, es dipositen en un dispositiu primitiu anomenat v�ter. No, no va dins d�un alien g�tic.";
                    break;

                case 15:
                    texto.text = "Consell 0.2: Els jugadors de m�bil s�n menys �gamers� que els de consola o PC... per� tenen m�s vida social.";
                    break;

                case 16:
                    texto.text = "Consell Aniversari Feli�: Si continues tenint aniversaris... acabar�s morint. Felicitats!";
                    break;

                case 17:
                    texto.text = "Consell 666: No trenquis mai un cor nom�s en tenim un. En canvi, pots trencar ossos n�hi ha 206 per triar.";
                    break;
            }
        }
        else
        {
            texto.text = "Language not detected!";
        }
    }
}
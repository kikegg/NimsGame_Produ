using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class animatica : MonoBehaviour
{

    public GameObject uno;
    public GameObject dos;
    public GameObject tres;
    public GameObject cuatro;
    public GameObject cinco;
  

    public int _int = 1;

    public GameObject nextbutton;


    public void talking()
	{

		_int = _int + 1;

		if (_int == 1) {

			uno.SetActive (true);
            

		} else if (_int == 2) {
			uno.SetActive (false);
			dos.SetActive (true);
		} else if (_int == 3) {
			uno.SetActive (false);
			dos.SetActive (false);
			tres.SetActive (true);
           
			;
		} else if (_int == 4) {
			uno.SetActive (false);
			dos.SetActive (false);
			tres.SetActive (false);
			cuatro.SetActive (true);
		} else if (_int == 5) {
			uno.SetActive (false);
			dos.SetActive (false);
			tres.SetActive (false);
			cuatro.SetActive (false);
			cinco.SetActive (true);
		} else if (_int == 6) {
			SceneManager.LoadScene ("Scene1");
		}
       
	}
}
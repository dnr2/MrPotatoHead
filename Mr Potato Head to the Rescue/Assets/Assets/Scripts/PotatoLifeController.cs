using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotatoLifeController : MonoBehaviour {

	public int initialLifePoints = 1;
	public int initialManaPoints = 50;
	public int lives = 1;
	public static int continues = 1;
	public Transform spawnPoint;
	public Text textoVida;
	public Text textoPizza;
	public float flashSpeed = 10f;
	public Color flashColor = new Color(1f, 0f, 0f, 0.5f);
	public GameObject prefabHpDiv;
	
	private bool isDead = false;
	private int lifePoints ;
	private int manaPoints ;
	private int points = 0;
	private bool invincible = false;
	private Slider HpBar;
	private Slider MpBar;
	private Image damageImage;
	private bool damaged = false;


	// Use this for initialization
	void Start () {	
		textoVida = GameObject.FindGameObjectWithTag("PotatoLifeText").GetComponent <Text>();
		textoVida.text = "x"+lives;
		textoPizza = GameObject.FindGameObjectWithTag("PizzaCounterText").GetComponent <Text>();
		textoPizza.text = "x"+points;
		//Debug.Log("Texto = "+textoVida.text);
		lifePoints = initialLifePoints;
		manaPoints = initialManaPoints;

		HpBar = GameObject.FindGameObjectWithTag("hpSlider").GetComponent <Slider>();
		HpBar.maxValue = lifePoints;
		HpBar.value = lifePoints;
		
		MpBar = GameObject.FindGameObjectWithTag("mpSlider").GetComponent <Slider>();
		MpBar.maxValue = manaPoints;
		MpBar.value = manaPoints;
		
		damageImage = GameObject.FindGameObjectWithTag("damageImg").GetComponent <Image>();
		
		Vector3 HpBarPosition = HpBar.transform.position;
		float HpBarSizeWidth = HpBar.fillRect.rect.width;
		float HpBarSizeHeight = HpBar.fillRect.rect.height;
		Debug.Log(HpBarSizeHeight);
		
		for(int i = 1; i < initialLifePoints; i++){
			Vector3 position;
			position.x = HpBarPosition.x + i*(HpBarSizeWidth/initialLifePoints);
			position.y = HpBarPosition.y+(HpBarSizeHeight/2);
			position.z = HpBarPosition.z;
			GameObject prefab = (GameObject)Instantiate(prefabHpDiv, position, Quaternion.identity);
			prefab.transform.SetParent(HpBar.transform);
			prefab.transform.position = position;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColor;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		// Reset the damaged flag.
		damaged = false;
	}
	
	void updateLives(int vidas){
		lives += vidas;
		textoVida.text = "x"+(lives);
	}
	
	void updateLifePointsAndBar(int val){
		if(lifePoints < initialLifePoints || val < 0){
			lifePoints += val;
			HpBar.value += val;
		}
	}
	
	public void updateManaPointsAndBar(int val){
		manaPoints += val;
		MpBar.value += val;
		manaPoints = Mathf.Min(manaPoints, initialManaPoints);
		MpBar.value = Mathf.Min(MpBar.value, initialManaPoints);
	}

	public int getMP(){
		return this.manaPoints;
	}

	void updatePizzaPointsAndText(int val){
		points += val;
		textoPizza.text = "x"+points;
		if(points%25 == 0){
			updateLives(1);
		}
	}


	void causeDamage(int val){
		damaged = true;
		if (!isDead) {
			Debug.Log( "atingido" );
			updateLifePointsAndBar(-val);
			if( lifePoints <= 0){
				PlayDeathAnimation();
				isDead = true;
				playerRespawn();
			}
		}
	}

	void playerRespawn(){
		//if still has lives.
		if (lives > 0) {

			//Debug.Log( "morreu.." );
	
			updateLives (-1);
			
			updateLifePointsAndBar(initialLifePoints);
			updateManaPointsAndBar(initialManaPoints);
			isDead = false;

			this.transform.position = spawnPoint.position;


		} else if (PotatoLifeController.continues > 0) {

			//Debug.Log( "usando coninue.." );

			//restart the level;
			PotatoLifeController.continues--;

			Debug.Log(Application.loadedLevelName);

			Application.LoadLevel(Application.loadedLevelName);
		} else {
			//game over, restart the game

			Debug.Log( "Game OVERR" );
			playGameOverAnimation();

			Application.LoadLevel("StartMenu");

		}
	
	}

	void OnTriggerEnter(Collider other) {

		//Debug.Log ("INVICIBLE IS " + invincible + " TAG is "  + other.tag);
		if (!invincible) {
			if (other.tag == "laserbean") {
				causeDamage (1);
				playSound();
				StartCoroutine (myWait (2));
				Destroy (other.gameObject);
			} else if (other.tag == "enemy") {
				causeDamage (1);
				Destroy (other.gameObject);
			}
			else if (other.tag == "hpItem") {
				updateLifePointsAndBar(1);
				Destroy (other.gameObject);
			}
			else if (other.tag == "mpItem") {
				updateManaPointsAndBar(25);
				Destroy (other.gameObject);
			}
			else if (other.tag == "estrela") {
				updatePizzaPointsAndText(1);
				Destroy (other.gameObject);
			}
			else if (other.tag == "lifeItem") {
				updateLives(1);
				Destroy (other.gameObject);
			}
			else if (other.tag == "continueItem") {
				continues++;
				Destroy (other.gameObject);
			}
			else if (other.tag == "Acido") {
				causeDamage(2);
			}

		}
	}

	void playSound(){

		//ira tentar tocar Audio Source componente (ver documentacao do Unity)
		if (audio != null) {
			AudioSource.PlayClipAtPoint(audio.clip, this.gameObject.transform.position );
		}
	}
	
	IEnumerator myWait(int seconds) {
		//Debug.Log("IVUNERAVIU");
		invincible = true;
		yield return new WaitForSeconds(seconds);
		invincible = false;
		//Debug.Log("VUNERAVIU");
	}

	void PlayDeathAnimation(){
	}

	void playGameOverAnimation(){	
	}

}

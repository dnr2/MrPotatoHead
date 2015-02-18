using UnityEngine;
using System.Collections;

public class PlayerAnimationInterface : MonoBehaviour
{
	public virtual void update(bool active){}
	public virtual void setCharacterMotor( CharacterMotor motor){}
	public virtual Animator getAnimator(){ return null; }
	public virtual SkinnedMeshRenderer getHatObj( ) { return null; }
}
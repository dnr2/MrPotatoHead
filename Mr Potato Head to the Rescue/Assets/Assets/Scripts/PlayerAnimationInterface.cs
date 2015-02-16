using UnityEngine;
using System.Collections;

public interface PlayerAnimationInterface 
{
	void update(bool active);
	Animator getAnimator();
	void setAnimator(Animator anim);
	void setCharacterMotor( CharacterMotor motor);
	void setAnimatorObj( GameObject obj );
	void setHatObj( SkinnedMeshRenderer obj );
	SkinnedMeshRenderer getHatObj( );
}
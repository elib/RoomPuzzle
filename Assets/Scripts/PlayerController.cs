﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public Transform 	mTargetPosition;
	public Player		mPlayer;

	public enum CharacterView
	{
		Cat,
		Kid,
		Grandma
	};
	CharacterView mCharacterView;

	public CharacterView GetView() { return mCharacterView; }
	// Use this for initialization
	void Start () 
	{
		SwitchView( CharacterView.Kid );
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( Input.GetMouseButtonDown( 0 ) )
		{
			Vector3 vWorldMousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			vWorldMousePosition.z = 0.0f;
			Debug.Log( vWorldMousePosition );
			mTargetPosition.position = vWorldMousePosition;
			mPlayer.WalkTo( vWorldMousePosition );
		}
	}

	void OnMouseDown() 
	{
	}

	public void SwitchView( CharacterView view )
	{
		mCharacterView = view;
		
		if ( view == CharacterView.Kid )
		{
			ShowKidView();
		}
		
		else if ( view == CharacterView.Grandma )
		{
			ShowGrandmaView();
		}
		
		else if ( view == CharacterView.Cat )
		{
			ShowCatView();
		}
	}
	
	void ShowKidView()
	{
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer( "Kid" );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Cat" ) );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Grandma" ) );
	}
	
	void ShowGrandmaView()
	{
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer( "Grandma" );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Kid" ) );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Cat" ) );
	}
	
	void ShowCatView()
	{
		Camera.main.cullingMask |= 1 << LayerMask.NameToLayer( "Cat" );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Kid" ) );
		Camera.main.cullingMask &=  ~( 1 << LayerMask.NameToLayer( "Grandma" ) );
	}
}

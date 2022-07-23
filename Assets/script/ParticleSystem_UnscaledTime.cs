﻿using UnityEngine;


/// <summary>
/// 該腳本會控制 ParticleSystem 的更新, 
/// 且不受 Time.timeScale 的影響. 
/// </summary>
public class ParticleSystem_UnscaledTime : MonoBehaviour
{
	// 該變數決定底下的子物件是否要一起更新
	public bool withChildren = true;


	// 自行更新運作的粒子系統
	new private ParticleSystem particleSystem;


	private void Awake()
	{
		this.particleSystem = GetComponent< ParticleSystem >();
	}


	private void Update()
	{
		// 更新粒子系統, 
		// Time.unscaledDeltaTime 可以解釋為不受 Time.timeScale 影響的 Time.deltaTime, 
		// 所以可以用來取代 Time.deltaTime, 來當作粒子系統運作時的依據
		if ( this.particleSystem != null )
			this.particleSystem.Simulate( Time.unscaledDeltaTime, this.withChildren, false );
	}

}
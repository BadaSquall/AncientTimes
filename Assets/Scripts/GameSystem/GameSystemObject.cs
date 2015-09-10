using System;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.GameSystem
{
	public abstract class GameSystemObject
	{
		#region Properties

		public delegate void DestroyHandler(GameObject objectToDestroy);
		public event DestroyHandler Destroy;

		#endregion Properties

		#region Constructor

		public GameSystemObject() { }

		#endregion Constructor

		#region Methods

		protected void RaiseDestroy(GameObject objectToDestroy) { Destroy(objectToDestroy); }

		#endregion Methods
	}

}
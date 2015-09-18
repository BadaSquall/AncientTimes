using System;
using UnityEngine;

namespace AncientTimes.Assets.Scripts.GameSystem
{
	public abstract class GameSystemObject
	{
		#region Properties

		public delegate void DestroyHandler(GameObject objectToDestroy);
		public event DestroyHandler Destroy;

        public delegate UnityEngine.Object InstantiateHandler(UnityEngine.Object objectToInstantiate);
        public event InstantiateHandler Instantiate;

		#endregion Properties

		#region Constructor

		public GameSystemObject() { }

		#endregion Constructor

		#region Methods

		protected void RaiseDestroy(GameObject objectToDestroy) { Destroy(objectToDestroy); }
        protected UnityEngine.Object RaiseInstantiate(UnityEngine.Object objectToInstantiate) { return Instantiate(objectToInstantiate); }

		#endregion Methods
	}
}
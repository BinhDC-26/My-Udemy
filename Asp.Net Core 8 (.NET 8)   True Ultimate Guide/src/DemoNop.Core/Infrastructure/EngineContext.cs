﻿using System.Runtime.CompilerServices;

namespace DemoNop.Core.Infrastructure
{
    public partial class EngineContext
    {
        #region Methods
        /// <summary>
        /// Create a static instance of the Nop engine.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create()
        {
            //create NopEngine as engine
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new DemoNopEngine());
        }

        /// <summary>
        /// Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.
        /// </summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }
        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the singleton Nop engine used to access Nop services.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Create();
                }

                return Singleton<IEngine>.Instance;
            }
        }
        #endregion Properties
    }
}

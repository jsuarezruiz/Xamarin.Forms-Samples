using System;

namespace Sample.MultiTargeting
{
    public static class CrossMultiTargeting
    {
        static Lazy<IMultiTargeting> implementation = 
			new Lazy<IMultiTargeting>(() => CreateMultiTargeting(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static bool IsSupported => implementation.Value == null ? false : true;

        public static IMultiTargeting Current
        {
            get
            {
                IMultiTargeting ret = implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        static IMultiTargeting CreateMultiTargeting()
        {
#if NETSTANDARD1_0 || NETSTANDARD2_0
            return null;
#else
            return new MultiTargetingImplementation();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly() =>
            new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
    }
}
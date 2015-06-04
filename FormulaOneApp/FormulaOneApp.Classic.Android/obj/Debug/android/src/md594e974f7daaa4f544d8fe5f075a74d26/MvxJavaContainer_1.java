package md594e974f7daaa4f544d8fe5f075a74d26;


public class MvxJavaContainer_1
	extends md594e974f7daaa4f544d8fe5f075a74d26.MvxJavaContainer
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Cirrious.CrossCore.Droid.MvxJavaContainer`1, Cirrious.CrossCore.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxJavaContainer_1.class, __md_methods);
	}


	public MvxJavaContainer_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxJavaContainer_1.class)
			mono.android.TypeManager.Activate ("Cirrious.CrossCore.Droid.MvxJavaContainer`1, Cirrious.CrossCore.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

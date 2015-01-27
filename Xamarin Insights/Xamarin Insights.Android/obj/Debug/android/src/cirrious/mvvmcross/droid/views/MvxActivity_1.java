package cirrious.mvvmcross.droid.views;


public abstract class MvxActivity_1
	extends cirrious.mvvmcross.droid.views.MvxActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Cirrious.MvvmCross.Droid.Views.MvxActivity`1, Cirrious.MvvmCross.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxActivity_1.class, __md_methods);
	}


	public MvxActivity_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxActivity_1.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Droid.Views.MvxActivity`1, Cirrious.MvvmCross.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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

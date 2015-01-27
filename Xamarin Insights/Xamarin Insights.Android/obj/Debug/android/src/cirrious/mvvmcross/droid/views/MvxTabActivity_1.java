package cirrious.mvvmcross.droid.views;


public class MvxTabActivity_1
	extends cirrious.mvvmcross.droid.views.MvxTabActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Cirrious.MvvmCross.Droid.Views.MvxTabActivity`1, Cirrious.MvvmCross.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxTabActivity_1.class, __md_methods);
	}


	public MvxTabActivity_1 () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxTabActivity_1.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Droid.Views.MvxTabActivity`1, Cirrious.MvvmCross.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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

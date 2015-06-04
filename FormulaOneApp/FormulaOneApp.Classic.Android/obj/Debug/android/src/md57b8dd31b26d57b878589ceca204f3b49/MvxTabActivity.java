package md57b8dd31b26d57b878589ceca204f3b49;


public abstract class MvxTabActivity
	extends md558d3f6ff0b1b93a8788ee4e30a21efd8.MvxEventSourceTabActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_setContentView:(I)V:GetSetContentView_IHandler\n" +
			"";
		mono.android.Runtime.register ("Cirrious.MvvmCross.Droid.Views.MvxTabActivity, Cirrious.MvvmCross.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxTabActivity.class, __md_methods);
	}


	public MvxTabActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxTabActivity.class)
			mono.android.TypeManager.Activate ("Cirrious.MvvmCross.Droid.Views.MvxTabActivity, Cirrious.MvvmCross.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void setContentView (int p0)
	{
		n_setContentView (p0);
	}

	private native void n_setContentView (int p0);

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

package crc64474ad098e2b571fb;


public class KeoBB_PlanNoActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("LoginNhanVien.KeoBB_PlanNoActivity, LoginNhanVien", KeoBB_PlanNoActivity.class, __md_methods);
	}


	public KeoBB_PlanNoActivity ()
	{
		super ();
		if (getClass () == KeoBB_PlanNoActivity.class)
			mono.android.TypeManager.Activate ("LoginNhanVien.KeoBB_PlanNoActivity, LoginNhanVien", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
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

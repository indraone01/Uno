#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.ApplicationModel.Email
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public   enum EmailFlagState 
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		Unflagged,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		Flagged,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		Completed,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		Cleared,
		#endif
	}
	#endif
}
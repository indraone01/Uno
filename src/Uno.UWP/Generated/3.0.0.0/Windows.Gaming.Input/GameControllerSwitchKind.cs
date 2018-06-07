#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Gaming.Input
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public   enum GameControllerSwitchKind 
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		TwoWay,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		FourWay,
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		EightWay,
		#endif
	}
	#endif
}
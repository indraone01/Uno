#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.Foundation.Diagnostics
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__
	[global::Uno.NotImplemented]
	#endif
	public  partial interface IErrorReportingSettings 
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		void SetErrorOptions( global::Windows.Foundation.Diagnostics.ErrorOptions value);
		#endif
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__
		global::Windows.Foundation.Diagnostics.ErrorOptions GetErrorOptions();
		#endif
	}
}
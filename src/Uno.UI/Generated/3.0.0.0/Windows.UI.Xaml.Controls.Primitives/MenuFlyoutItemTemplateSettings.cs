#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Controls.Primitives
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || false
	[global::Uno.NotImplemented]
	#endif
	public  partial class MenuFlyoutItemTemplateSettings : global::Windows.UI.Xaml.DependencyObject
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public  double KeyboardAcceleratorTextMinWidth
		{
			get
			{
				throw new global::System.NotImplementedException("The member double MenuFlyoutItemTemplateSettings.KeyboardAcceleratorTextMinWidth is not implemented in Uno.");
			}
		}
		#endif
		// Forced skipping of method Windows.UI.Xaml.Controls.Primitives.MenuFlyoutItemTemplateSettings.KeyboardAcceleratorTextMinWidth.get
	}
}

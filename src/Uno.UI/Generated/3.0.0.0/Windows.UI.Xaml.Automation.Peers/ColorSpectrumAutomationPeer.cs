#pragma warning disable 108 // new keyword hiding
#pragma warning disable 114 // new keyword hiding
namespace Windows.UI.Xaml.Automation.Peers
{
	#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
	[global::Uno.NotImplemented]
	#endif
	public  partial class ColorSpectrumAutomationPeer : global::Windows.UI.Xaml.Automation.Peers.FrameworkElementAutomationPeer
	{
		#if __ANDROID__ || __IOS__ || NET46 || __WASM__ || __MACOS__
		[global::Uno.NotImplemented]
		public ColorSpectrumAutomationPeer( global::Windows.UI.Xaml.Controls.Primitives.ColorSpectrum owner) : base(owner)
		{
			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.UI.Xaml.Automation.Peers.ColorSpectrumAutomationPeer", "ColorSpectrumAutomationPeer.ColorSpectrumAutomationPeer(ColorSpectrum owner)");
		}
		#endif
		// Forced skipping of method Windows.UI.Xaml.Automation.Peers.ColorSpectrumAutomationPeer.ColorSpectrumAutomationPeer(Windows.UI.Xaml.Controls.Primitives.ColorSpectrum)
	}
}

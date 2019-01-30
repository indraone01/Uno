using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Uno.UI.Media
{
	partial class NativeRenderTransformAdapter
	{
		partial void Apply(bool isSizeChanged, bool isOriginChanged)
		{
			throw new NotImplementedException("RenderTransform are not supported on this platform");
		}

		partial void Cleanup()
		{
			throw new NotImplementedException("RenderTransform are not supported on this platform");
		}
	}
}

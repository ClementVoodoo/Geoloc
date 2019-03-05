using System.Collections;
using System.Collections.Generic;
using Mapbox.Utils;
using UnityEngine;

namespace Voodoo.Mapbox.Utils
{
	public static class MapBoxUtilsExtended
	{
		public static Vector2d ToVector2d(this Vector2 _Vector2)
		{
			double x = _Vector2.x;
			double y = _Vector2.y;
			return new Vector2d(x,y);
		}

		public static Vector2 ToVector2(this Vector2d _Vector2D)
		{
			float x = (float)_Vector2D.x;
			float y = (float)_Vector2D.y;
			return new Vector2(x,y);
		}
	}
}
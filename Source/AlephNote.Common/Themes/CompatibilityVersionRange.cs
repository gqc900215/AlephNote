﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlephNote.Common.Themes
{
	public class CompatibilityVersionRange
	{
		public static readonly CompatibilityVersionRange ANY = new CompatibilityVersionRange(new Version(0, 0, 0, 0), new Version(999999, 0, 0, 0));

		public enum CompatibilityVersionRangeType { Greater, Equal }

		public readonly Version Min; // included
		public readonly Version Max; // excluded

		private CompatibilityVersionRange(Version v1, Version v2)
		{
			Min = v1;
			Max = v2;
		}
		
		public bool Includes(Tuple<int, int, int, int> v) => Includes(new Version(v.Item1, v.Item2, v.Item3, v.Item4));

		public bool Includes(Version v)
		{
			return v >= Min && (Max == null || v < Max);
		}

		/// <summary>
		/// Syntax reference
		/// https://stackoverflow.com/a/31845544/1761622
		/// </summary>
		public static CompatibilityVersionRange Parse(string v)
		{
			try
			{
				int? ANY = null;

				v = v.Trim().ToLower();

				if (v == "*")
				{
					Version min = new Version(0, 0, 0, 0);
					Version max = null;
					return new CompatibilityVersionRange(min, max);
				}

				bool isTilde = false;
				bool isCaret = false;

				if (v.StartsWith("~")) { isTilde = true; v = v.Substring(1); }
				if (v.StartsWith("^")) { isCaret = true; v = v.Substring(1); }

				if (!isTilde && !isCaret && v.Contains("-"))
				{
					var split = v.Split('-');

					var min = Version.Parse(split[0]);
					var max = Version.Parse(split[1]);
					return new CompatibilityVersionRange(min, new Version(max.Major, max.Minor, max.Build, max.Revision+1));
				}

				var parts = v.Split('.');
				if (parts.Length == 0 || parts.Length > 4) throw new Exception("Version needs to have between 1 and 4 parts");

				var p0 = (parts.Length > 0 && parts[0] != "x") ? int.Parse(parts[0]) : ANY; // Mayor
				var p1 = (parts.Length > 1 && parts[1] != "x") ? int.Parse(parts[1]) : ANY; // Minor
				var p2 = (parts.Length > 2 && parts[2] != "x") ? int.Parse(parts[2]) : ANY; // Build/Patch
				var p3 = (parts.Length > 3 && parts[3] != "x") ? int.Parse(parts[3]) : ANY; // Revision

				if (isTilde)
				{
					Version min = new Version(p0 ?? 0,  p1 ?? 0,    p2 ?? 0, p3 ?? 0);
					Version max = new Version(p0 ?? 0, (p1 ?? 0)+1, 0,       0      );
					return new CompatibilityVersionRange(min, max);
				}
				else if (isCaret)
				{
					Version min = new Version( p0 ?? 0,    p1 ?? 0, p2 ?? 0, p3 ?? 0);
					Version max = new Version((p0 ?? 0)+1, 0,       0,       0      );
					return new CompatibilityVersionRange(min, max);
				}
				else
				{
					if (p0 == null)
					{
						Version min = new Version(0, 0, 0, 0);
						Version max = null;
						return new CompatibilityVersionRange(min, max);
					}
					else if (p1 == null)
					{
						Version min = new Version(p0.Value, 0, 0, 0);
						Version max = new Version(p0.Value + 1, 0, 0, 0);
						return new CompatibilityVersionRange(min, max);
					}
					else if (p2 == null)
					{
						Version min = new Version(p0.Value, p1.Value, 0, 0);
						Version max = new Version(p0.Value, p1.Value + 1, 0, 0);
						return new CompatibilityVersionRange(min, max);
					}
					else if (p3 == null)
					{
						Version min = new Version(p0.Value, p1.Value, p2.Value, 0);
						Version max = new Version(p0.Value, p1.Value, p2.Value + 1, 0);
						return new CompatibilityVersionRange(min, max);
					}
					else
					{
						Version min = new Version(p0.Value, p1.Value, p2.Value, p3.Value);
						Version max = new Version(p0.Value, p1.Value, p2.Value, p3.Value + 1);
						return new CompatibilityVersionRange(min, max);
					}
				}
			}
			catch (Exception e)
			{
				throw new Exception($"Parsing version range '{v}' failed", e);
			}

		}

		public override string ToString()
		{
			if ((Min == null || Min == ANY.Min) && (Max == null || Max == ANY.Max)) return "*";

			if (Min != null && Min != ANY.Min && (Max == null || Max == ANY.Max)) return $"[{Min?.ToString()??"*"}]+";

			return $"[{Min?.ToString()??"*"}]-[{Max?.ToString()??"*"}]";
		}
	}
}

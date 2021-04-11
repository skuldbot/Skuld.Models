using System;

namespace Skuld.Models.Commands
{
	public struct ParameterSkuld : IEquatable<ParameterSkuld>
	{
		private string name;
		private bool optional;

		public string Name { get => name; set => name = value; }
		public bool Optional { get => optional; set => optional = value; }

		public override bool Equals(object obj)
		{
			return obj is ParameterSkuld skuld && Equals(skuld);
		}

		public bool Equals(ParameterSkuld other)
		{
			return Name == other.Name &&
				   Optional == other.Optional;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(Name, Optional);
		}

		public static bool operator ==(ParameterSkuld left, ParameterSkuld right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ParameterSkuld left, ParameterSkuld right)
		{
			return !(left == right);
		}
	}
}
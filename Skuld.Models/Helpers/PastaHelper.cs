using System;
using System.Collections.Generic;
using System.Linq;

namespace Skuld.Models.Helpers
{
	public static class PastaHelper
	{
		public static ulong GetPastaKarma(IEnumerable<IGrouping<ulong, PastaVotes>> groupedPastas, IEnumerable<Pasta> pastas)
		{
			if (groupedPastas is null) return 0;

			double upkarma = 0;
			double downkarma = 0;

			foreach (var group in groupedPastas)
			{
				double interactionAmount = pastas.Where(p => group.Any(pv => pv.PastaId == p.Id)).Count();

				int upVotes = group.Count(p => p.Upvote);
				int downVotes = group.Count(p => !p.Upvote);

				double weight = GetWeight(interactionAmount);

				upkarma += upVotes * weight;
				downkarma += downVotes * weight;
			}

			return (ulong)Math.Round(upkarma - (downkarma / 5));
		}

		static double GetWeight(double x)
		{
			double upper = 0.8;
			double lower = 0.2;
			double smooth = 0.45;
			double offset = 15;
			double expOperation = smooth * (x - offset);

			double denominator = 1 + Math.Exp(expOperation);

			return upper / denominator + lower;
		}
	}
}

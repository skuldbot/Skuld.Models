using Skuld.Models.Helpers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Skuld.Models.Tests
{
	public class KarmaTests
	{
		[Fact]
		public void TestKarma()
		{
			List<PastaVotes> votes = new()
			{
				new PastaVotes
				{
					PastaId = 1,
					Upvote = true,
					VoterId = 1
				},
				new PastaVotes
				{
					PastaId = 2,
					Upvote = false,
					VoterId = 1
				},
				new PastaVotes
				{
					PastaId = 3,
					Upvote = true,
					VoterId = 1
				},
				new PastaVotes
				{
					PastaId = 4,
					Upvote = false,
					VoterId = 1
				},
				new PastaVotes
				{
					PastaId = 5,
					Upvote = true,
					VoterId = 1
				},
				new PastaVotes
				{
					PastaId = 6,
					Upvote = false,
					VoterId = 1
				}
			};

			List<Pasta> pastas = new()
			{
				new()
				{
					Id = 1,
					Created = 0,
				},
				new()
				{
					Id = 2,
					Created = 0,
				},
				new()
				{
					Id = 3,
					Created = 0,
				},
				new()
				{
					Id = 4,
					Created = 0,
				},
				new()
				{
					Id = 5,
					Created = 0,
				},
				new()
				{
					Id = 6,
					Created = 0,
				},
			};

			var karma = PastaHelper.GetPastaKarma(votes.GroupBy(p => p.VoterId), pastas);

			Assert.Equal<ulong>(2, karma);
		}
	}
}

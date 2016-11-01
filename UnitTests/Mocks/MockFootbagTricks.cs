using Shred30.Common.Enums;
using Shred30.Common.Models.FootbagTrick;
using Shred30.Common.Models.FootbagTrick.Delays;
using System.Collections.Generic;

namespace Shred30.UnitTests.Mocks
{
	public class MockFootbagTricks
	{
		public static FootbagTrick Ripwalk = new FootbagTrick
		{
			TrickId = "1",
			Names = new List<string>() { "ripwalk" },
			Adds = 4,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Clipper
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Opposite,
				Surface = SurfaceType.Clipper
			}
		};

		public static FootbagTrick Blur = new FootbagTrick
		{
			TrickId = "2",
			Names = new List<string>() { "blur" },
			Adds = 4,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Clipper
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Same,
				Surface = SurfaceType.Toe
			}
		};

		public static FootbagTrick Dimwalk = new FootbagTrick
		{
			TrickId = "3",
			Names = new List<string>() { "dimwalk" },
			Adds = 4,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Toe
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Opposite,
				Surface = SurfaceType.Clipper
			}
		};

		public static FootbagTrick BlurryWhirl = new FootbagTrick
		{
			TrickId = "4",
			Names = new List<string>() { "blurry whirl" },
			Adds = 5,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Clipper
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Opposite,
				Surface = SurfaceType.Clipper
			}
		};

		public static FootbagTrick Barfly = new FootbagTrick
		{
			TrickId = "5",
			Names = new List<string>() { "barfly" },
			Adds = 4,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Clipper
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Opposite,
				Surface = SurfaceType.Clipper
			},
			IsDoubleDown = true
		};

		public static FootbagTrick Paradon = new FootbagTrick
		{
			TrickId = "6",
			Names = new List<string>() { "paradon" },
			Adds = 4,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Toe
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Opposite,
				Surface = SurfaceType.Clipper
			},
			IsDoubleDown = true
		};

		public static FootbagTrick DownDoubleDown = new FootbagTrick
		{
			TrickId = "7",
			Names = new List<string>() { "downdoubledown" },
			Adds = 4,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Clipper
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Same,
				Surface = SurfaceType.Clipper
			},
			IsDoubleDown = true
		};

		public static FootbagTrick DownOverDown = new FootbagTrick
		{
			TrickId = "8",
			Names = new List<string>() { "downoverdown" },
			Adds = 4,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Toe
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Same,
				Surface = SurfaceType.Clipper
			},
			IsDoubleDown = true
		};

		public static FootbagTrick AtomSmasher = new FootbagTrick
		{
			TrickId = "9",
			Names = new List<string>() { "atomsmasher" },
			Adds = 4,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Toe
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Opposite,
				Surface = SurfaceType.Toe
			},
			UseXDex = true
		};

		public static FootbagTrick Mirage = new FootbagTrick
		{
			TrickId = "10",
			Names = new List<string>() { "mirage" },
			Adds = 2,
			StartDelay = new Delay
			{
				Surface = SurfaceType.Either
			},
			EndDelay = new EndDelay
			{
				RelativeSide = RelativeSideType.Same,
				Surface = SurfaceType.Toe
			},
			HasSameSideVariant = true
		};
	}
}
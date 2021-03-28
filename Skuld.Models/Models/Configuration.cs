﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skuld.Models
{
	public class SkuldConfig
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string Id { get; set; }

		public SkuldConfig()
		{
			Id = Guid.NewGuid().ToString();
		}

		public bool IsDevelopmentBuild { get; set; } = false;

		#region Discord

		public string DiscordToken { get; set; } = null;
		public string Prefix { get; set; } = "vf.";
		public string AltPrefix { get; set; } = ".";

		#endregion Discord

		#region Websocket

		public string WebsocketHost { get; set; } = "0.0.0.0";
		public ushort WebsocketPort { get; set; } = 37821;
		public bool WebsocketSecure { get; set; } = false;

		#endregion Websocket

		#region BotPreferences

		public int PinboardThreshold { get; set; } = 5;
		public int PinboardDateLimit { get; set; } = 7;
		public ulong DailyAmount { get; set; } = 50;
		public float VoiceExpDeterminate { get; set; } = .002f;
		public ulong VoiceExpMinMinutes { get; set; } = 5;
		public ulong VoiceExpMaxGrant { get; set; } = 100000;
		public ulong IssueChannel { get; set; }
		public ulong StreakLimitDays { get; set; } = 1;

		#endregion BotPreferences

		#region APIConfig

		public string GithubClientUsername { get; set; } = "";
		public string GithubClientPassword { get; set; } = "";
		public long GithubRepository { get; set; } = 0;
		public string GoogleAPI { get; set; } = "";
		public string GoogleCx { get; set; } = "";
		public int STANDSUid { get; set; } = 0;
		public string STANDSToken { get; set; } = "";
		public string TwitchToken { get; set; } = "";
		public string TwitchClientID { get; set; } = "";
		public string ImgurClientID { get; set; } = "";
		public string ImgurClientSecret { get; set; } = "";
		public string NASAApiKey { get; set; } = "";
		public string DataDogHost { get; set; } = "";
		public ushort? DataDogPort { get; set; } = 8125;

		#endregion APIConfig

		#region BotListing

		public string DBotsOrgKey { get; set; } = "";
		public string DiscordGGKey { get; set; } = "";
		public string B4DToken { get; set; } = "";

		#endregion BotListing

		#region Twitter
		public string TwitterConKey { get; set; }
		public string TwitterConSec { get; set; }
		public string TwitterAccessTok { get; set; }
		public string TwitterAccessSec { get; set; }
		#endregion Twitter

		public string SkuldAPIBase { get; set; } = null;

		public string SkuldAPIToken { get; set; } = null;

		public string CachetBase { get; set; } = null;

		public string CachetToken { get; set; } = null;

		public int CachetShardGroup { get; set; } = -1;
	}
}
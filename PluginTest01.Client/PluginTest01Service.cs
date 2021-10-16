using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NFive.SDK.Client.Commands;
using NFive.SDK.Client.Communications;
using NFive.SDK.Client.Events;
using NFive.SDK.Client.Interface;
using NFive.SDK.Client.Services;
using NFive.SDK.Core.Diagnostics;
using NFive.SDK.Core.Models.Player;
using Gaston11276.PluginTest01.Client.Overlays;

namespace Gaston11276.PluginTest01.Client
{
	[PublicAPI]
	public class PluginTest01Service : Service
	{
		private PluginTest01Overlay overlay;

		public PluginTest01Service(ILogger logger, ITickManager ticks, ICommunicationManager comms, ICommandManager commands, IOverlayManager overlay, User user) : base(logger, ticks, comms, commands, overlay, user) { }

		public override async Task Started()
		{
			// Create overlay
			this.overlay = new PluginTest01Overlay(this.OverlayManager);

			// Attach a tick handler
			this.Ticks.On(OnTick);
		}

		private async Task OnTick()
		{
			this.Logger.Debug("Hello World!");
			// Do something every frame

			await Delay(TimeSpan.FromSeconds(1));
		}
	}
}

#region Copyright & License Information
/*
 * Copyright 2007-2014 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation. For more information,
 * see COPYING.
 */
#endregion

using OpenRA.Network;
using OpenRA.Widgets;

namespace OpenRA.Mods.RA.Widgets.Logic
{
	public class DisconnectWatcherLogic
	{
		[ObjectCreator.UseCtor]
		public DisconnectWatcherLogic(Widget widget, OrderManager orderManager)
		{
			var disconnected = false;
			widget.Get<LogicTickerWidget>("DISCONNECT_WATCHER").OnTick = () => 
			{
				if (!disconnected && orderManager.Connection.ConnectionState == ConnectionState.NotConnected)
				{
					Game.RunAfterTick(() =>
					{
						Ui.OpenWindow("CONNECTIONFAILED_PANEL", new WidgetArgs()
						{
							{ "orderManager", orderManager },
							{ "onAbort", null },
							{ "onRetry", null }
						});
					});

					disconnected = true;
				}
			};
		}
	}
}

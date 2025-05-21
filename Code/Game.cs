using Sandbox.Network;

namespace StylesheetReproduction;

public class Game: Component, Component.INetworkListener, ISceneStartup
{
	[Property]
	public GameObject PlayerPrefab { get; private set; }

	void ISceneStartup.OnHostInitialize()
	{
		Networking.CreateLobby(new LobbyConfig()
		{
			DestroyWhenHostLeaves = true,
			MaxPlayers = 2,
		});
	}

	void INetworkListener.OnActive( Connection connection )
	{
		var player = PlayerPrefab.Clone();
		player.Name = connection.DisplayName;
		player.NetworkSpawn(connection);
	}
}

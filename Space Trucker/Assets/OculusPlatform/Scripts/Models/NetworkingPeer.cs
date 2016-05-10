namespace Oculus.Platform.Models
{
  using UnityEngine;
  using System;
  using System.ComponentModel;

  public enum PeerConnectionState : uint
  {
    [Description("UNKNOWN")]
    Unknown=0,

    [Description("CONNECTED")]
    Connected,

    [Description("TIMEOUT")]
    Timeout,
  };

  public class NetworkingPeer
  {
    public NetworkingPeer(UInt64 id, PeerConnectionState state) {
      ID = id;
      State = state;
    }

    public UInt64 ID { get; private set; }
    public PeerConnectionState State { get; private set; }
  }
}

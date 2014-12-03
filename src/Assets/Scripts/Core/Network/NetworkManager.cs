using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

public sealed partial class NetworkManager
{
	private class NetPacket
	{
		public Boolean Cancelled { get; set; }
		public Exception Error { get; set; }
		public Int32 Opcode { get; set; }
		public Byte[] Data { get; set; }
		
		public NetPacket(Boolean cancelled, Exception error, Int32 opcode, Byte[] data)
		{
			this.Cancelled = cancelled;
			this.Error = error;
			this.Opcode = opcode;
			this.Data = data;
		}
	}

	private Uri m_ServerUri = new Uri("http://182.254.202.167:8088/service.php");
	private const String SESSION_KEY = "WarriorHeart";
	private const String OPCODE_KEY = "opcode";
	private String m_SessionId = String.Empty;
	private WebClient m_WebClient = new WebClient();
	private Queue m_PacketQueue = Queue.Synchronized(new Queue());
	private IDictionary<Int32, IPacketHandler> m_PacketHandlers = new Dictionary<Int32, IPacketHandler>();
	
	private static NetworkManager instance = null;
	public static NetworkManager Instance
	{
		get
		{
			if (null == instance)
			{
				instance = new NetworkManager();
			}
			
			return instance;
		}
	}

	private NetworkManager ()
	{
		m_WebClient.UploadDataCompleted += new UploadDataCompletedEventHandler(OnUploadDataCompleted);

		// register event
	}

	public void SetServerUrl(String url)
	{
		if (String.IsNullOrEmpty(url))
		{
			m_ServerUri = null;
			return;
		}

		m_ServerUri = new Uri(url);
	}

	public void Send(byte[] packet)
	{
		if (m_ServerUri == null)
		{
			Debug.LogError("Network: Server URI is not available!");
			return;
		}

		if (m_WebClient.IsBusy)
		{
			Debug.LogWarning("Network: WebClient is busy!");
			return;
		}

		try
		{
			Debug.Log ("Send packet:" + System.Text.Encoding.Default.GetString (packet));
			//m_WebClient.Headers.Set(SESSION_KEY, m_SessionId);
			m_WebClient.Headers.Set(SESSION_KEY, "roshantu");
			m_WebClient.UploadDataAsync(m_ServerUri, packet);
			//EventManager.Instance.DispatchEvent(Event.EventDefine.ConnectStart);
		}
		catch (Exception e)
		{
			Debug.LogWarning("Network: Upload data exception: " + e.Message);
		}
	}
	
	public void Update()
	{
		lock (m_PacketQueue)
		{
			if (m_PacketQueue.Count > 0)
			{
				// EventManager.Instance.DispatchEvent(EventDefine.ConnectFinish);
			}

			while (m_PacketQueue.Count > 0)
			{
				NetPacket netPacket = m_PacketQueue.Dequeue() as NetPacket;
				if (netPacket == null)
				{
					Debug.LogWarning("Network: A null-packet found!");
					continue;
				}

				if (netPacket.Cancelled)
				{
					Debug.LogWarning("Network: Upload data cancelled!");
					continue;
				}

				if (netPacket.Error != null)
				{
					Debug.LogWarning("Network: Upload data exception: " + netPacket.Error.Message);
					continue;
				}

				if (netPacket.Data == null)
				{
					Debug.LogWarning("Network: Invalid packet data!");
					continue;
				}

				if (!m_PacketHandlers.ContainsKey(netPacket.Opcode))
				{
					Debug.LogWarning("Network: A valid packet found (OPCODE=" + netPacket.Opcode + "), but there is no handler, you must forget RegisterHandler!");
					continue;
				}

				m_PacketHandlers[netPacket.Opcode].Handle(netPacket.Data);
			}
		}
	}

	private void RegisterHandler(IPacketHandler handler)
	{
		Int32 opcode = handler.GetOpcode();
		if (m_PacketHandlers.ContainsKey(opcode))
		{
			Debug.LogWarning("Network: Exist same handler (OPCODE=" + opcode + ") already!");
			return;
		}

		m_PacketHandlers.Add(opcode, handler);
	}

	private void OnUploadDataCompleted(object sender, UploadDataCompletedEventArgs args)
	{
		Int32 opcode = 0;
		if (m_WebClient.ResponseHeaders != null)
		{
			m_SessionId = m_WebClient.ResponseHeaders.Get(SESSION_KEY);
			String opcodeStr = m_WebClient.ResponseHeaders.Get(OPCODE_KEY);
			Int32.TryParse(opcodeStr, out opcode);
		}

		lock (m_PacketQueue)
		{
			m_PacketQueue.Enqueue(new NetPacket(args.Cancelled, args.Error, opcode, args.Result));
		}
	}
	
}



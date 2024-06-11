﻿using System;
using System.IO.Pipes;
using System.Threading.Tasks;
using LenovoLegionToolkit.Lib.Utils;
using ProtoBuf;

namespace LenovoLegionToolkit.Lib.Automation.CmdLine;

public class CmdLineIPCClient
{
    private readonly NamedPipeClientStream _pipe = new(".", "LenovoLegionToolkit-IPC-0", PipeDirection.InOut, PipeOptions.None);

    public CmdLineQuickActionRunState State { get; private set; }
    public string? Errmsg { get; private set; }

    public async Task RunQuickActionAsync(string quickActionName)
    {
        if (!CmdLineIPCServer.CheckPipeExists())
        {
            if (Log.Instance.IsTraceEnabled)
                Log.Instance.Trace($"IPC server hasn't been started.");

            State = CmdLineQuickActionRunState.ServerNotRunning;
            return;
        }

        try
        {
            await ConnectToIPCServerAsync();
        }
        catch (Exception ex)
        {
            if (Log.Instance.IsTraceEnabled)
                Log.Instance.Trace($"Pipe connect failed.", ex);

            State = CmdLineQuickActionRunState.PipeConnectFailed;
            Errmsg = ex.Message;
            return;
        }

        if (Log.Instance.IsTraceEnabled)
            Log.Instance.Trace($"Pipe connected, sending Quick Action call: \"{quickActionName}\"...");

        var omsgpack = new IPCMessagePack()
        {
            QuickActionName = quickActionName
        };
        Serializer.SerializeWithLengthPrefix(_pipe, omsgpack, PrefixStyle.Base128);

        var imsgpack = Serializer.DeserializeWithLengthPrefix<IPCMessagePack>(_pipe, PrefixStyle.Base128);

        if (Log.Instance.IsTraceEnabled)
            Log.Instance.Trace($"Response received.");

        if (imsgpack is null)
        {
            if (Log.Instance.IsTraceEnabled)
                Log.Instance.Trace($"Deserialize failed.");

            State = CmdLineQuickActionRunState.Undefined;
        }
        else
        {
            State = imsgpack.State;
            Errmsg = imsgpack.Error;

            if (Log.Instance.IsTraceEnabled)
            {
                switch (imsgpack.State)
                {
                    case CmdLineQuickActionRunState.ActionRunFailed:
                        Log.Instance.Trace($"Run Quick Action failed due to following reason: {imsgpack.Error ?? string.Empty}");
                        break;
                    case CmdLineQuickActionRunState.ActionNotFound:
                        Log.Instance.Trace($"Quick Action not found.");
                        break;
                    case CmdLineQuickActionRunState.DeserializeFailed:
                        Log.Instance.Trace($"Server failed to deserialize request.");
                        break;
                    case CmdLineQuickActionRunState.Ok:
                        Log.Instance.Trace($"Run Quick Action successfully.");
                        break;
                    default:
                        Log.Instance.Trace($"Undefined response received");
                        break;
                }
            }
        }
    }

    private async Task ConnectToIPCServerAsync()
    {
        while (true)
        {
            try
            {
                await _pipe.ConnectAsync(500);
                return;
            }
            catch (TimeoutException)
            {
                if (!CmdLineIPCServer.CheckPipeExists())
                {
                    throw new OperationCanceledException();
                }
            }
        }
        throw new OperationCanceledException();
    }
}

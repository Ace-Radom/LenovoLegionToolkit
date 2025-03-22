﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.Graphics.Gdi;
using Windows.Win32.UI.WindowsAndMessaging;

namespace LenovoLegionToolkit.WPF.Windows.Utils;

public class NativeLayeredWindow : NativeWindow, IDisposable
{
    private byte _alpha = 250;
    private bool _disposed;
    private Size _size = new(350, 50);
    private Point _pos = new(50, 50);

    public Size Size
    {
        get { return _size; }
        set
        {
            if (Handle != nint.Zero)
            {
                UpdateWindowSizePosition(_pos.X, _pos.Y, value.Width, value.Height);
                RECT rect = new();
                PInvoke.GetWindowRect((HWND)Handle, out rect);
                _size = new(rect.Width, rect.Height);
                UpdateLayeredWindow();
            }
            else
            {
                _size = value;
            }
        }
    }

    public int Width
    {
        get { return _size.Width; }
        set { _size.Width = value; }
    }

    public int Height
    {
        get { return _size.Height; }
        set { _size.Height = value; }
    }

    public Point Position
    {
        get { return _pos; }
        set
        {
            if (Handle != nint.Zero)
            {
                UpdateWindowSizePosition(value.X, value.Y, _size.Width, _size.Height);
                RECT rect = new();
                PInvoke.GetWindowRect((HWND)Handle, out rect);
                _pos = new(rect.left, rect.top);
                UpdateLayeredWindow();
            }
            else
            {
                _pos = value;
            }
        }
    }

    public void Show()
    {
        if (Handle == nint.Zero)
            CreateLayeredWindow();

        PInvoke.ShowWindow((HWND)Handle, SHOW_WINDOW_CMD.SW_SHOWNOACTIVATE);
    }

    public void Hide()
    {
        if (Handle == nint.Zero)
            return;

        PInvoke.ShowWindow((HWND)Handle, SHOW_WINDOW_CMD.SW_HIDE);
    }

    public void Close()
    {
        Hide();
        Dispose();
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            DestroyHandle();
            _disposed = true;
        }
        GC.SuppressFinalize(this);
    }

    private void CreateLayeredWindow()
    {
        var style = WINDOW_STYLE.WS_POPUP;
        var exStyle = WINDOW_EX_STYLE.WS_EX_TOPMOST |
            WINDOW_EX_STYLE.WS_EX_TOOLWINDOW |
            WINDOW_EX_STYLE.WS_EX_LAYERED |
            WINDOW_EX_STYLE.WS_EX_NOACTIVATE |
            WINDOW_EX_STYLE.WS_EX_TRANSPARENT;
        CreateParams cp = new()
        {
            Caption = "LenovoLegionToolkit-NativeLayeredWindow",
            X = Position.X,
            Y = Position.Y,
            Height = Size.Height,
            Width = Size.Width,
            Parent = nint.Zero,
            Style = (int)style,
            ExStyle = (int)exStyle
        };
        CreateHandle(cp);
        UpdateLayeredWindow();
    }

    protected virtual void Paint(PaintEventArgs e) { }

    private void UpdateLayeredWindow()
    {
        Bitmap bitmap = new(Size.Width, Size.Height, PixelFormat.Format32bppArgb);
        using Graphics graphics = Graphics.FromImage(bitmap);
        Rectangle cr = new(0, 0, Size.Width, Size.Height);
        Paint(new(graphics, cr));
        var hdcDst = PInvoke.GetDC(HWND.Null);
        var hdcSrc = PInvoke.CreateCompatibleDC(hdcDst);
        var hbitmap = bitmap.GetHbitmap(Color.FromArgb(0));
        var hObject = SelectObject(hdcSrc, hbitmap);
        SIZE size = new(Size.Width, Size.Height);
        Point ptDst = new(Position.X, Position.Y);
        Point ptSrc = new(0, 0);
        COLORREF colorRef = new(0); // rgbBlack
        BLENDFUNCTION blend = new()
        {
            BlendOp = (byte)PInvoke.AC_SRC_OVER,
            BlendFlags = 0,
            SourceConstantAlpha = _alpha,
            AlphaFormat = (byte)PInvoke.AC_SRC_ALPHA
        };
        PInvoke.UpdateLayeredWindow((HWND)Handle, hdcDst, ptDst, size, hdcSrc, ptSrc, colorRef, blend, UPDATE_LAYERED_WINDOW_FLAGS.ULW_ALPHA);
        SelectObject(hdcSrc, hObject);
        _ = PInvoke.ReleaseDC(HWND.Null, hdcDst);
        PInvoke.DeleteObject((HGDIOBJ)hbitmap);
        PInvoke.DeleteDC(hdcSrc);
    }

    private void UpdateWindowSizePosition(int x, int y, int width, int height)
    {
        if (Position.X != x || Position.Y != y || Size.Width != width || Size.Height != height)
        {
            if (Handle != nint.Zero)
            {
                SET_WINDOW_POS_FLAGS flags = 0;
                if (Position.X == x && Position.Y == y)
                {
                    flags |= SET_WINDOW_POS_FLAGS.SWP_NOMOVE;
                }
                if (Size.Width == width && Size.Height == height)
                {
                    flags |= SET_WINDOW_POS_FLAGS.SWP_NOSIZE;
                }
                PInvoke.SetWindowPos((HWND)Handle, HWND.Null, x, y, width, height, flags);
            }
            else
            {
                Size = new(width, height);
                Position = new(x, y);
            }
        }
    }

    [DllImport("gdi32.dll", CharSet = CharSet.Auto)]
    private static extern nint SelectObject(nint hDC, nint hObject);
}

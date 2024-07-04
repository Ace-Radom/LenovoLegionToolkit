using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace LenovoLegionToolkit.WPF.Windows.Utils;

public class NotificationWindowAoT : Form
{
    private const uint WS_POPUP = 0x80000000;
    private const int WS_EX_TOOLWINDOW = 0x00000080;
    private const int WS_EX_NOACTIVATE = 0x08000000;
    private const int WS_EX_TOPMOST = 0x00000008;

    public NotificationWindowAoT()
    {
        InitializeComponent();
    }

    protected override CreateParams CreateParams
    {
        get
        {
            CreateParams cp = base.CreateParams;
            unchecked
            {
                cp.Style |= (int)WS_POPUP;
            }
            cp.ExStyle |= WS_EX_TOOLWINDOW | WS_EX_NOACTIVATE | WS_EX_TOPMOST;
            return cp;
        }
    }

    private void InitializeComponent()
    {
        FormBorderStyle = FormBorderStyle.None;
        Name = "LLT_NotificationWindowAoT";
        Text = "LLT_NotificationWindowAoT";
        Load += NotificationWindowAoT_Load;
        ElementHost
        ResumeLayout(false);
    }

    private void NotificationWindowAoT_Load(object sender, EventArgs e)
    {
        BackColor = Color.Black;
        TransparencyKey = Color.Black;
    }
}

using UnityEngine;
using System.Diagnostics;
public class LinuxConsole
{
   public static void OpenTerminal()
    {
        ProcessStartInfo start = new ProcessStartInfo("gnome-terminal");
        Process.Start(start);
    }
}

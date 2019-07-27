﻿using System;
using System.Runtime.InteropServices;

namespace AutoLaudCron
{
    class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        static void Main(string[] args)
        {
            var handle = GetConsoleWindow();
            TimerStart timerStart = new TimerStart();
            ShowWindow(handle, SW_HIDE);
            while (true)
            {
                timerStart.OnTimedEvent();
         
            }
        }
    }
}
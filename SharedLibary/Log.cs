﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedLibrary
{
    public class Log
    {
        public enum Level
        {
            All,
            Debug,
            Production,
            None,
        }

        public Log(IFile logf, Level mode, int port)
        {
            logFile = logf;
            logMode = mode;
            Identifier = port;
        }

        public void Write(String line)
        {
            Write(line, Level.Debug);
        }

        public void Write(String line, Level lv)
        {
            String Line = String.Format("{1} - [{0}]: {2}", Identifier, getTime(), line);
            switch (logMode)
            {
                case Level.All:
                    if (lv == Level.All || lv == Level.Debug || lv == Level.Production)
                        Console.WriteLine(Line);
                    break;
                case Level.Debug:
                    if (lv == Level.All || lv == Level.Debug)
                        Console.WriteLine(Line);
                    break;
                case Level.Production:
                    if (lv == Level.Production)
                        Console.WriteLine(Line);
                    break;
            }

            logFile.Write(Line);
        }

        private string getTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        private IFile logFile;
        private Level logMode;
        private int Identifier;
    }
}
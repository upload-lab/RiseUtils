
using System;
using System.Collections;
using System.Diagnostics;

namespace RiseUtils
{
  internal class RiseUtils
  {
    public static bool isValidDLLs(int id)
    {
      Process processById = Process.GetProcessById(id);
      if (processById == null)
        return true;
      bool flag = false;
      try
      {
        string lower1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToLower();
        foreach (ProcessModule module in (ReadOnlyCollectionBase) processById.Modules)
        {
          try
          {
            string lower2 = module.FileName.ToLower();
            if (lower2.StartsWith(lower1))
            {
              flag = true;
              Console.WriteLine("Not allowed #3: " + module.FileName);
            }
            string lower3 = module.ModuleName.ToLower();
            if (lower3.Contains("hack") || lower3.Contains("speed") || (lower3.Contains("cheat") || lower3.Contains("click")))
            {
              flag = true;
              Console.WriteLine("Not allowed #1: " + module.FileName);
            }
            if (!lower3.Equals("javaw.exe"))
            {
              if (!lower3.Equals("java.exe"))
              {
                if (lower2.Contains(".exe"))
                {
                  flag = true;
                  Console.WriteLine("Not allowed #2: " + module.FileName);
                }
              }
            }
          }
          catch (Exception ex)
          {
          }
        }
      }
      catch (Exception ex)
      {
        return true;
      }
      return !flag;
    }

    public static bool isCheatEngineRunning()
    {
      foreach (Process process in Process.GetProcesses())
      {
        try
        {
          if (process.ProcessName.ToLower().Contains("cheatengine"))
            return true;
        }
        catch (Exception ex)
        {
        }
      }
      return false;
    }
  }
}

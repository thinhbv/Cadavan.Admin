using System;
using System.Collections.Generic;
using System.Configuration;

/// <summary>
/// Summary description for Constant
/// </summary>
public class Constant
{
    public static string ADMIN_PATH = ConfigurationSettings.AppSettings["ADMIN_PATH"];

    public Constant()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}

﻿// Copyright (C) 2014-2015, Codeplex user AlphaCentaury
// All rights reserved, except those granted by the governing license of this software. See 'license.txt' file in the project root for complete license information.

using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: AssemblyFileVersion(SolutionVersion.AssemblyFileVersion)]
[assembly: AssemblyInformationalVersion(SolutionVersion.AssemblyInformationalVersion)]
[assembly: AssemblyProduct(SolutionVersion.AssemblyProduct)]
[assembly: AssemblyCompany("http://movistartv.codeplex.com")]
[assembly: AssemblyTrademark("")]

internal static class SolutionVersion
{
    public const string DefaultAssemblyVersion = "1.0.2000.000";
    public const string AssemblyFileVersion = "1.0.2000.000";
    public const string AssemblyInformationalVersion = "1.0.2000.000";
    public const string AssemblyProduct = "MovistarTV DVB-IPTV software decoder" + " (v" + ProductVersion + ")";
    public const string ProductVersion = "1.0.0 RC 0 \"Wolf 424\" QFE 1";
} // class SolutionVersion
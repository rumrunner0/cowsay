using System;


namespace CreativeTrager.CowSay.Demo.Entities;
[Flags] internal enum EnvironmentExitCode : int 
{
	Success = 0,
	UnknownError = 1,
	InvalidInputData = 2
}

﻿using System;
using System.Threading.Tasks;

namespace Rumble.Cowsay;

/// <summary>
/// Entity that echoes phrases.
/// </summary>
public interface IEchoEntity
{
	/// <summary>
	/// Echoes a phrase.
	/// </summary>
	/// <param name="phrase">The phrase to be echoed by the entity</param>
	/// <param name="maxLineLength">The max length of the line</param>
	/// <returns>Formatted string that represents the entity echoing the phrase</returns>
	/// <exception cref="ArgumentNullException">Thrown when <paramref name="phrase"/> is null</exception>
	/// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="maxLineLength"/> is out of allowed range</exception>
	Task<string> Echo(string phrase, int maxLineLength);
}
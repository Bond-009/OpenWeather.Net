#!/bin/sh
cd test/OpenWeather.Net.Tests
dotnet restore && dotnet test -f netstandard1.1 -c Release

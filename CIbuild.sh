#!/bin/sh
cd test/OpenWeather.Net.Tests
dotnet restore && dotnet test -c Release

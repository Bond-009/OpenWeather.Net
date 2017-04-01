#!/bin/sh
dotnet restore && dotnet build OpenWeather.Net.sln -c Release

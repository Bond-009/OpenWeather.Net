#!/bin/sh
cd test/OpenWeather.Net.Tests
dotnet restore && dotnet xunit

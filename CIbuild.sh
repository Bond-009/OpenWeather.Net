#!/bin/sh
dotnet restore && dotnet build $TRAVIS_SOLUTION -c Release
cd test/OpenWeather.Net.Tests
dotnet restore && dotnet xunit -c Release

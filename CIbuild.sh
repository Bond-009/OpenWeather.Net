#!/bin/sh
dotnet restore && dotnet build $TRAVIS_SOLUTION
cd test/OpenWeather.Net.Tests
dotnet restore && dotnet xunit

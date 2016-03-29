#!/bin/sh
echo "unit test~~~~~~~~~~~~~~~~"

xbuild ./YOYO.NUnitTest/YOYO.NUnitTest.csproj
nunit-console ./YOYO.NUnitTest/bin/Debug/YOYO.NUnitTest.dll

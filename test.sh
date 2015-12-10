#!/bin/sh
echo "unit test~~~~~~~~~~~~~~~~"

xbuild ./YOYO.NUnitTest/YOYO.NUnitTest.csproj
/Library/Frameworks/Mono.framework/Versions/4.2.1/bin/nunit-console ./YOYO.NunitTest/bin/Debug/YOYO.NunitTest.dll

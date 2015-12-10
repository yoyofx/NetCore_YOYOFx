#!/bin/sh
exec xbuild ./YOYO.NUnitTest/YOYO.NUnitTest.csproj
exec /Library/Frameworks/Mono.framework/Versions/4.2.1/bin/nunit-console ./YOYO.NunitTest/bin/Debug/YOYO.NunitTest.dll

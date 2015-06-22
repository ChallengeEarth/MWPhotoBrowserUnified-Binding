XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/MWPhotoBrowser.xcodeproj
TARGET=MWPhotoBrowser

all: libMWPhotoBrowser.a

libMWPhotoBrowser-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libMWPhotoBrowser-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@
	
libMWPhotoBrowser-arm64.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libMWPhotoBrowser.a: libMWPhotoBrowser-i386.a libMWPhotoBrowser-armv7.a libMWPhotoBrowser-arm64.a
	lipo -create -output $@ $^

clean:
	-rm -f *.a *.dll
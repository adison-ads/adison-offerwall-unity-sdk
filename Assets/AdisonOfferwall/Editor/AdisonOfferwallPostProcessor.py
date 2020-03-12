#!/usr/bin/python

import sys
from mod_pbxproj import XcodeProject

pathToProjectFile = sys.argv[1] + '/Unity-iPhone.xcodeproj/project.pbxproj'
pathToNativeCodeFiles = sys.argv[2]

# open the project
project = XcodeProject.Load( pathToProjectFile )

project.add_folder( pathToNativeCodeFiles, excludes=["^.*\.meta$"] )

# set a Other Linker Flags
project.add_other_ldflags(['-ObjC'])

# save the project, otherwise your changes won't be picked up by Xcode
if project.modified:
    project.save()

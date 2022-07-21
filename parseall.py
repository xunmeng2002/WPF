#!python2
#!coding:utf-8

import xml.etree.cElementTree as ET
import sys
import re
import os

def NeedPump(model, tpl, dest):
    if not os.path.exists(dest):
        return True
    destMtime = os.stat(dest).st_mtime
    if os.stat(tpl).st_mtime > destMtime:
        return True
    for item in model.split(" "):
        if os.stat(item).st_mtime > destMtime:
            return True
    return False

def Search(path, destFileName, exclude, destPaths):
    for fileName in os.listdir(path):
        if fileName in exclude:
            continue
        fullFileName = os.path.join(path, fileName)
        if os.path.isfile(fullFileName) and fileName == destFileName:
            destPaths.append(fullFileName)
        if os.path.isdir(fullFileName):
            Search(fullFileName, destFileName, exclude, destPaths)

def DoParse(fileName):
    root = ET.parse(fileName).getroot()
    for node in root:
        script = node.get("script")
        sources = node.get("sources")
        dest = node.get("dest")
        if NeedPump(sources, script, dest):
            print("%s %s %s" % (script, dest, sources))
            if os.system("python %s %s %s" % (script, dest, sources)) != 0:
                exit()


if __name__ == "__main__":
    exclude = ['.sv', '.vs', 'build', 'out']
    parsefiles = []
    Search(".", "parselist.xml", exclude, parsefiles)
    for parsefile in parsefiles:
        DoParse(parsefile)

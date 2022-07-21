#!python2
#coding:utf-8

import xml.etree.cElementTree as ET
import sys
import re
import os


def Search(path, destFileName, exclude, destPaths):
    for fileName in os.listdir(path):
        if fileName in exclude:
            continue
        fullFileName = os.path.join(path, fileName)
        if os.path.isfile(fullFileName) and fileName == destFileName:
            destPaths.append(fullFileName)
        if os.path.isdir(fullFileName):
            Search(fullFileName, destFileName, exclude, destPaths)
			
def clear(pumpfile):
    root = ET.parse(pumpfile).getroot()
    for node in root:
        dest = node.get("dest")
        if os.path.exists(dest):
            print("delete %s" % dest)
            os.remove(dest)
	
if __name__ == "__main__":
    exclude = ['inttools']
    parsefiles = []
    Search(".","parselist.xml", exclude, parsefiles)
    for parsefile in parsefiles:
        clear(parsefile)

    pumpfiles = []
    Search(".","pumplist.xml", exclude, pumpfiles)
    for pumpfile in pumpfiles:
        clear(pumpfile)
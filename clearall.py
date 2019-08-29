#!python2
#coding:utf-8

import xml.etree.cElementTree as ET
import sys
import re
import os

def search(path, word):
	"""Search specified file in a directory
	Args:
		path: directory path to be searched
		word: file whose name contains "word" is we needed
	Returns:
		A list for file names
	"""
	found = []
	for filename in os.listdir(path):
		fp = os.path.join(path, filename)
		if os.path.isfile(fp) and word in filename:
			found.append(fp)
		elif os.path.isdir(fp):
			found.extend( search(fp, word))
	return found
			
def clear(file_name):
	"""Pump files according to a pump.list file
	Args:
		file_name: a pump.list file
	Returns:
	"""
	dir = os.path.dirname(file_name)
	dir = dir.replace("\\", "/")
	
	root = ET.parse(file_name).getroot()
	for p in root:
		dest = dir + "/" + p.get("dest")
		if os.path.exists(dest):
			print "delete %s" % dest
			os.remove(dest)
	
if __name__ == "__main__":
	pumpfiles = search("source","pumplist.xml")
	if pumpfiles:
		for file in pumpfiles:
			clear(file)
	
	pumpfiles = search("target","pumplist.xml")
	if pumpfiles:
		for file in pumpfiles:
			clear(file)
			
	pumpfiles = search("test","pumplist.xml")
	if pumpfiles:
		for file in pumpfiles:
			clear(file)
			
	pumpfiles = search("tool","pumplist.xml")
	if pumpfiles:
		for file in pumpfiles:
			clear(file)
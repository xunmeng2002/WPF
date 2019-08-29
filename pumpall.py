#!python2
#!coding:utf-8

import xml.etree.cElementTree as ET
import sys
import re
import os

def filenewer(file1, file2):
	"""Check which file is newer
	Args:
		file1[string]:file name
		file2[string]:file name
	Returns:
		bool: true-file1 is newer than file2
			  false-file1 is not newer than file2
	"""
	if not os.path.exists(file2):
		return True
	if not os.path.exists(file1):
		return False;
	return os.stat(file1).st_mtime > os.stat(file2).st_mtime

def search(path, word, exclude):
	"""Search specified file in a directory
	Args:
		path: directory path to be searched
		word: file whose name contains "word" is we needed
		exclude: directory or file to exclude
	Returns:
		A list for file names
	"""
	found = []
	for filename in os.listdir(path):
		if filename in exclude:
			continue
		fp = os.path.join(path, filename)
		if os.path.isfile(fp) and word in filename:
			found.append(fp)
		elif os.path.isdir(fp):
			found.extend( search(fp, word, exclude))
	return found
			
def do_pump(file_name):
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
		tpl = dir + "/" + p.get("tpl")
		modellist = []
		modelstr = ""
		for model in p.get("model").split(" "):
			modelstr += dir + "/" + model + " "
			modellist.append(dir + "/" + model)
		
		modelnew = False
		for model in modellist:
			if filenewer(model,dest):
				modelnew = True
				break
		
		if modelnew or filenewer(tpl, dest): 
			print "pump %s %s %s" % (dest, tpl, modelstr)
			if os.system("python pump.py %s %s %s" % (dest, tpl, modelstr)) <> 0:
				exit()
	
if __name__ == "__main__":
	#旧的目录
	olddir = os.getcwd()
	
	#首先生成Model
	os.chdir("./datamodel")
	if os.system("python gen.py") <> 0:
		exit(-1)
	
	os.chdir(olddir)
	exclude = ['inttools']
	pumpfiles = search(".", "pumplist.xml", exclude)
	if pumpfiles:
		for file in pumpfiles:
			do_pump(file)
			
	os.chdir("./sql")
	if (os.system("python gensql.py")) <> 0:
		exit(-1)
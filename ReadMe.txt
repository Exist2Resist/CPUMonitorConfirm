To be used with PRTG Monitor.

Used to monitor a server instance for CPU usage. 
Takes 4 parameters, lower cpu limit, upper cpu limit, user name, password.
Alerts are triggered based on the the threshold of upper and lower CPU limit set by command line switches. 
If threshold dips below lower or rises above upper CPU limit the user name and password
are used to log into the website and check weather or not this was triggered by low/high usage or if the 
server is being locked by SQL queries/reports.

Usage example: file.exe 35 92 username Passw0rd!
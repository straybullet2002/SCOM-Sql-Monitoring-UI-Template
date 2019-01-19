# SCOM-Sql-Monitoring-UI-Template
The Management Pack for SCOM 2012R2+ enables you to create SQL-based monitors and rules directly from OpsMgr console.

## Features
* 2 and 3 state unit monitor templates, collection and alert rule templates
* SQL and Windows authentication
* Consecutive samples condition and scheduler filter

# Quick Start
1. Download [Management Pack Bundle](/ManagementPack/Test.SqlMonitor.MP.mpb)
2. Import the management pack into SCOM
3. Depending on chosen authentication method create Windows or Simple Run As account and bind it to "Impersonation Run As Profile (OleDb)" or "Simple Run As Profile (OleDb)" respectively


Template locations:
![Template locations](/Images/MonitorsAndRules.jpg?raw=true)
![Query and connection](/Images/ConstructQuery.jpg?raw=true)
![Schedule filtering](/Images/MonitorScheduleFilter.jpg?raw=true)
![Expression filtering](/Images/MonitorExpressionError.jpg?raw=true)
![Alert configuration](/Images/MonitorAlert.jpg?raw=true)

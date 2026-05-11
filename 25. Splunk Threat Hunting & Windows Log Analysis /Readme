# Splunk Threat Hunting & Windows Log Analysis

This project presents practical examples of Windows log analysis and threat hunting performed in Splunk Enterprise.  
The focus is on detecting suspicious behavior, investigating system activity, and building searches that help identify potential security incidents inside a Windows environment.

The repository contains example detections, SPL queries, and investigation workflows based on Windows Security logs and Sysmon telemetry.

---

# Project Goals

- Analyze Windows and Sysmon logs in Splunk
- Investigate suspicious process execution
- Detect abnormal network connections
- Identify unusual authentication activity
- Use statistical analysis to detect anomalies
- Practice threat hunting techniques used in SOC environments

---

# Detection & Investigation Scenarios

## Process Creation Monitoring

Analysis of Sysmon Event ID 1 to investigate process execution and parent-child relationships.

Examples include:
- suspicious PowerShell activity,
- WMIC execution,
- account creation commands,
- unusual command-line arguments.

Example query:

```spl
index=windowslogs EventID=1
| table _time ParentProcessId ProcessId ParentCommandLine CommandLine
| reverse
```

---

## Windows Logon Analysis

Investigation of successful logons using Event ID 4624.

The analysis includes:
- logon types,
- authentication methods,
- elevated privileges,
- service and network logons.

Example query:
index=windowslogs EventID=4624


---

## Network Connection Detection

Monitoring outbound connections using Sysmon Event ID 3.

Investigated fields:
- destination IP,
- destination port,
- protocol,
- associated process image.

Example query:
index=windowslogs DestinationIp=172.18.39.6 AND DestinationPort=135


---

## Source IP Analysis

Review of the most common source IP addresses appearing in logs.

Example query:
index=windowslogs
| top SourceIp


---

## IP Geolocation Enrichment

Using geolocation data to analyze the origin of IP addresses.

Example query:
index=windowslogs
| iplocation SourceIp
| stats count by Region

---

## Process Risk Scoring

Basic risk scoring applied to processes frequently associated with suspicious activity.

Examples:
- powershell.exe
- wmic.exe
- net.exe

Example query:
index=windowslogs
| lookup image_riskscore Image OUTPUT RiskScore
| stats count by Image RiskScore
| sort - RiskScore

---

## VPN Login Anomaly Detection

Detection of unusual VPN activity based on user behavior and login locations.

The analysis includes:
- rare country logins,
- unusual login frequency,
- anomalous login times.

Example query:
index=vpnlogs
| eventstats count as logins_by_user by user
| eventstats count as logins_by_user_country by user src_country
| eval country_freq=logins_by_user_country/logins_by_user
| where country_freq < 0.1


---

## Statistical Anomaly Detection

Use of z-score calculations to identify unusual login hours for users.

Example query:
index=vpnlogs
| eval hour=tonumber(strftime(_time,"%H")) + tonumber(strftime(_time,"%M"))/60
| eventstats avg(hour) as typical_hour stdev(hour) as stdev_hour by user
| eval zscore=abs(hour - typical_hour) / stdev_hour
| where zscore > 3

---

# Technologies Used

- Splunk Enterprise
- Sysmon
- Windows Event Logs
- SPL (Search Processing Language)

---

# Skills Demonstrated

- Threat Hunting
- Log Analysis
- SIEM Investigation
- Detection Engineering
- Windows Security Monitoring
- SPL Query Development
- Security Event Correlation
- Network Traffic Analysis

---

# Future Improvements

- MITRE ATT&CK mapping
- Sigma rule integration
- Correlation searches
- Splunk dashboards
- Alert automation
- Threat intelligence enrichment

---

# Notes

The project was created in a lab environment for educational and portfolio purposes.

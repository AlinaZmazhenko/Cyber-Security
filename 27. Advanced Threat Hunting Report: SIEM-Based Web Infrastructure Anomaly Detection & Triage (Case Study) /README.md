# Advanced Threat Hunting Report: SIEM-Based Web Infrastructure Anomaly Detection & Triage (Case Study)

## 🎯 Executive Summary
This repository contains a structured, high-tier forensic investigation analyzing web server telemetry and infrastructure logs ingested into an enterprise **Splunk SIEM** platform. 
The primary objective of this case study is to demonstrate advanced threat-hunting methodologies using **Search Processing Language (SPL)** to identify distributed anomalies, 
flag brute-force/directory-traversal attempts, establish baseline behavioral deviations, and build proactive alerting logic for Security Operations Centers (SOC).

---

## 🔍 Investigation Matrix & SIEM Analysis

### Phase I: Identity Triage & Remote Access Baseline
To map out infrastructure exposure, user authentication volume across the remote gateway was audited. Utilizing volume-based statistical aggregation (`| stats count by Username`), 
telemetry from the VPN server index was cross-examined to isolate anomalous behavior from normal baseline operations:
* **Observation:** Standard user accounts (e.g., `Sarah`, `Olivia`, `Matthew`) exhibited predictable interactive connection counts ranging between 8 to 11 sessions over the sampled timeline.
* **Security Context:** Establishing this analytical baseline allows for the rapid detection of compromised credentials or "impossible travel" anomalies within decentralized architectures.

### Phase II: Web Traffic Volume Attribution
An evaluation of public-facing endpoints was conducted via source IP tracking (`index=web_logs | stats count by Source_IP | sort - count`) to pinpoint potential Denial of Service (DoS) origins or automated vulnerability scanning:
* **Key Finding:** Ingress traffic was highly distributed across key public nodes, with `10.0.0.1` peaking at 2,048 events, followed closely by secondary assets (`192.0.2.1`, `192.168.0.1`) hovering near 2,006 events. 
* **Tactical Verdict:** The tight, symmetrical distribution of connection counts suggests systematic automated interaction rather than human-driven traffic, hinting at a structured endpoint scanning sequence or synchronized microservices routing.

### Phase III: Statistical Anomaly Detection & Baseline Deviation
The core forensic focus targeted the `/payments.html` application uri, evaluating instances returning HTTP `404 Not Found` response codes. Advanced SPL windowing and event calculations were introduced to derive the mathematical average of hourly hits:
```splunk
index=web_logs URI=/payments.html status_code=404
| bin _time span=1h
| stats count AS hits BY _time
| eventstats avg(hits) AS avg_hits
| eval avg_hits=round(avg_hits, 1)
```
<img width="1313" height="854" alt="siem_metric_01_user_baseline" src="https://github.com/user-attachments/assets/fa10a628-b24d-42a7-9602-cda1dbc0b4e7" />
<img width="1318" height="538" alt="siem_metric_02_ingress_volume_attribution" src="https://github.com/user-attachments/assets/09968aed-a5ad-48bb-834d-e6cdeb9bbb84" />
<img width="1312" height="984" alt="siem_metric_03_statistical_baseline_averages" src="https://github.com/user-attachments/assets/24b4167d-bbb4-48f7-803c-e5231e91ffd7" />
<img width="1315" height="543" alt="siem_metric_04_deviation_alert_triage" src="https://github.com/user-attachments/assets/6c827ee9-11e5-4993-86f7-66d55efc9e4e" />
<img width="1311" height="1108" alt="siem_metric_05_infrastructure_dashboard_analytics" src="https://github.com/user-attachments/assets/2643ddfc-edc7-4354-8456-84477aa8a677" />






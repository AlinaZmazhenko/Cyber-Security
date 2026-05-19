# Advanced Threat Investigation Report: Targeted Intrusion & Data Exfiltration Analysis (Case Study)

## 🎯 Executive Summary
This repository contains a comprehensive cyber forensic investigation and incident response analysis detailing a sophisticated multi-stage targeted attack (APT simulation) 
against a proprietary industrial enterprise framework. 

The primary objective of this case study is to demonstrate advanced methodologies in **Digital Forensics and Incident Response (DFIR)**, indicators of compromise (IoC) triaging,
privilege escalation analysis, and data exfiltration defense. This technical breakdown serves as a structural blueprint for security operations centers (SOC) to detect stealthy 
insider threats and post-exploitation maneuvers within enterprise Linux environments.

---

## 🔍 Attack Lifecycle & Technical Breakdown

### Phase I: Initial Compromise & Perimeter Breach
* **Vector:** Spear-Phishing Campaign utilizing a weaponized document architecture (`invoice_Q1_2075.ods`).
* **Compromised Identity:** Corporate asset `j.morgan@robbco.com`.
* **Threat Actor Attribution Indicators:** Forensic log analysis identified the external sender as `akeane@poseidonenergy.net` via parsed email headers (`email_invoice.eml`).

### Phase II: Persistence Mechanisms & C2 Infrastructure
Upon achieving initial execution, the adversary established stealth persistence layers to bypass standard endpoint detection and response (EDR) solutions:
* **Staging Loader:** Deployed a hidden volatile script at `/tmp/.syncd` to download second-stage payloads from a remote command-and-control (C2) server (`http://10.0.0.66/payload.sh`).
* **Interactive Backdoor:** Configured a persistent reverse shell via a masqueraded binary `/tmp/.x`, routing telemetry and raw interactive control to `10.0.0.66:4444` under user context constraints.

### Phase III: Privilege Escalation & Lateral Movement
Forensic triage of system authentication logs and shell history (`.bash_history`) uncovered an abuse of Misconfigured Sudo Privileges. 
The adversary leveraged high-privilege access via text-editor binaries to modify system-wide configuration files:
```bash
sudo nano /home/r.house/.ssh/authorized_keys
```
<img width="1003" height="897" alt="01_incident_report" src="https://github.com/user-attachments/assets/da84c40c-4432-4ab9-bb4a-77ae46de7399" />
<img width="1012" height="595" alt="02_ai_file_anomalies_scan" src="https://github.com/user-attachments/assets/bde7b824-7a65-46b9-a624-850ee91a50e2" />
<img width="1004" height="466" alt="03_rhouse_sudo_denied" src="https://github.com/user-attachments/assets/51799cd8-f87a-4f98-89a7-4d71732a6016" />
<img width="790" height="300" alt="04_rhouse_bash_history" src="https://github.com/user-attachments/assets/60db8023-8626-4a43-ad02-e5b8d5e7cac3" />
<img width="1200" height="904" alt="05_phishing_email_source" src="https://github.com/user-attachments/assets/a09b882e-9e78-49d3-8242-7532cc13d2bb" />
<img width="1196" height="87" alt="06_phishing_email_source" src="https://github.com/user-attachments/assets/5f088ce1-afcb-41dd-adbf-8cc82a776382" />




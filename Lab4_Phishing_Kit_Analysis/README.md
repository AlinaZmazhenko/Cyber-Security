# Lab 4 – Phishing Kit Analysis & Infrastructure Investigation

## Objective
Analyze a real-world phishing kit to identify its components, infrastructure, indicators of compromise (IOCs), and associated attacker techniques.

## Case Overview
A phishing email contained an HTML attachment that redirected the victim to a malicious website hosting a phishing kit archive.

## Tools Used
- curl
- VirusTotal
- Linux CLI
- HTML source code analysis
- SSL certificate inspection
- Hashing utilities (sha256sum)

## Analysis Steps

### 1. HTML Attachment Analysis
The attached HTML file contained a meta refresh redirect to a phishing URL.
<img width="892" height="332" alt="html_redirect_code_analysis png " src="https://github.com/user-attachments/assets/b4c32c45-8232-4eac-9790-93e9debe6f98" />
<img width="1226" height="844" alt="cyberchef_defang_phishing_url png " src="https://github.com/user-attachments/assets/0d1020ff-ad57-4b0f-927d-a5d0bf6468db" />



### 2. Phishing Kit Discovery
Directory indexing revealed a ZIP archive containing the phishing kit.

### 3. Archive Retrieval
The phishing kit archive was downloaded safely using command-line tools.

### 4. Hash Analysis
The SHA256 hash of the archive was calculated and submitted to VirusTotal.
<img width="735" height="483" alt="phishing_kit_download_and_sha256 png " src="https://github.com/user-attachments/assets/0f271c72-5d4f-467b-b220-da2ae36e5d04" />


### 5. Malware Classification
Multiple security vendors identified the archive as a phishing and credential harvesting toolkit.

### 6. Infrastructure Analysis
Associated domains, IP addresses, and hosting infrastructure were identified.
<img width="1127" height="1137" alt="vt_update365_zip_relations png " src="https://github.com/user-attachments/assets/11fb59d8-ce35-46e2-ae4e-0ba7276692df" />
<img width="1020" height="1150" alt="vt_update365_zip_overview png " src="https://github.com/user-attachments/assets/389654bf-2a65-4b7b-8a64-9ae52cb7ec4a" />



### 7. SSL Certificate Analysis
The SSL certificate used by the phishing domain was reviewed to determine first observed date.

## Indicators of Compromise (IOCs)

- Phishing domain
- ZIP archive hash (SHA256)
- Associated IP addresses

## Conclusion
This lab demonstrates hands-on phishing kit analysis, including infrastructure mapping and malware intelligence enrichment, simulating a real SOC investigation workflow.

## Skills Demonstrated
- Phishing analysis
- Malware triage
- Threat intelligence
- IOC extraction
- Linux command-line analysis

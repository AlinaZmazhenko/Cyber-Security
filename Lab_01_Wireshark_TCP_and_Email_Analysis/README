# Lab 1 – Network Traffic & Email Analysis (Wireshark)

## Objective
Analyze network traffic and email-related data using Wireshark to identify suspicious behavior, failed connections, and potential security incidents, simulating SOC Tier 1 responsibilities.

---

## Tools Used
- Wireshark
- PCAP file (provided in lab)
- Wireshark Display Filters & IMF analysis

---

## Scenario
A SOC analyst received a PCAP file containing network and email traffic.
The task was to investigate:
- Repeated failed TCP connection attempts
- SMTP / email-related activity
- A suspicious email attachment (`attachment.scr`)

---


## Investigation Methodology
Wireshark display filter documentation was consulted to correctly apply
SMTP filters, including `smtp.response.code`, ensuring accurate identification
of mail server responses during analysis.

<img width="1684" height="1096" alt="Screenshot 2026-01-07 at 16 44 44" src="https://github.com/user-attachments/assets/4caaae27-cf31-433a-a5b6-150a2ab009b1" />

## Investigation Steps

### 1. TCP Traffic Analysis
- Filtered TCP traffic to identify repeated SYN retransmissions and RST responses.
- Observed multiple failed connection attempts from internal host `10.12.19.101` to external IP addresses.
- Analyzed TCP handshake behavior to assess possible misconfiguration or blocked services.

### 2. Email & SMTP Analysis
- Filtered traffic using `smtp` and `imf` display filters.
- Identified email traffic containing a suspicious attachment (`attachment.scr`).
- Analyzed Internet Message Format (IMF) headers to determine the email client used.
- Reviewed SMTP response codes and commands.
  
 <img width="2553" height="1319" alt="Screenshot 2026-01-07 at 18 13 08" src="https://github.com/user-attachments/assets/99937e00-8f4a-4286-afa4-a8bae62e208d" />

<img width="2560" height="1354" alt="Screenshot 2026-01-07 at 17 39 44" src="https://github.com/user-attachments/assets/fc976971-3eb3-499e-a12f-7e578af1e199" />



### 3. Findings
- Repeated TCP retransmissions indicated unsuccessful connection attempts.
- SMTP traffic revealed an email containing an executable attachment (`.scr`), which is commonly associated with malware.
- Email headers indicated the email client used to send the message.
  
SMTP response code 220 responses from legitimate mail servers,
indicating normal email delivery behavior and successful SMTP handshakes.
These responses serve as a baseline for comparison with blocked or suspicious messages.

  <img width="1192" height="1039" alt="Screenshot 2026-01-07 at 17 00 20" src="https://github.com/user-attachments/assets/43bc0ac2-8230-4d30-a071-6fbc8a79f801" />

SMTP response code 552 indicating that the email message
was blocked by the mail server due to content presenting a potential
security risk.

<img width="1305" height="1266" alt="Screenshot 2026-01-07 at 17 09 31" src="https://github.com/user-attachments/assets/0eacedfb-dd8f-43e5-8a68-464b6694ebec" />


---

## Conclusion
Based on the analysis, the traffic showed indicators that require further investigation.
The suspicious email should be escalated according to SOC procedures, and the affected host should be reviewed for potential compromise.

---

## SOC Actions (Simulated)
- Escalate the incident to Tier 2 for deeper investigation.
- Recommend endpoint scan of the affected host.
- Monitor for additional suspicious email activity.

#
#   Author: MLO
#   Date: 12.10.2017
#   Purpose: turn on Internet on Client-PC (remote).  (disable Port 80/443 per Firewall)
#

$computers = @("WS-KL-U01R01-11")
$computers |%{
    # Exec
  Invoke-Command -ComputerName WS-KL-U01R01-11 -ScriptBlock {
  New-NetFirewallRule -DisplayName "Disabling / Enable Port 80" -Action Allow -Direction Outbound -Profile Any -Protocol tcp -RemotePort 80
  New-NetFirewallRule -DisplayName "Disabling / Enable Port 443" -Action Allow -Direction Outbound -Profile Any -Protocol tcp -RemotePort 443
  Set-NetFirewallRule -DisplayName "Disabling / Enable Port 80" -Action Allow
  Set-NetFirewallRule -DisplayName "Disabling / Enable Port 443" -Action Allow
  }
}

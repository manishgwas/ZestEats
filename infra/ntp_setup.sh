# NTP time sync for Ubuntu
sudo apt-get update
sudo apt-get install -y ntp
sudo systemctl enable ntp
sudo systemctl start ntp
sudo ntpq -p

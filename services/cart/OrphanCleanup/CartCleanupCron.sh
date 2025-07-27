#!/bin/bash
# Cron job to clean up stale carts
# Run daily at midnight
redis-cli --scan --pattern '*' | while read key; do
  redis-cli DEL "$key"
done
